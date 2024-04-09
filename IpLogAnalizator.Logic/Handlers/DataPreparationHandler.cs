using IpLogAnalizator.Core.Constants;
using IpLogAnalizator.Core.Enums;
using IpLogAnalizator.Core.Exceptions;
using IpLogAnalizator.Core.Extensions;
using IpLogAnalizator.Core.Interfaces;
using IpLogAnalizator.Core.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IpLogAnalizator.Logic.Handlers
{
    public class DataPreparationHandler : BaseHandler, IHandler
    {
        public DataPreparationHandler(ILogger logger) : base(logger)
        {
        }

        public override async Task ModuleExecuteAsync(HandlerContext context)
        {
            ArgumentNullException.ThrowIfNull(context.Data, nameof(context.Data));

            var logs = (context.Data[Key.Parse] as List<Log>);

            if (logs?.Any() != true)
            {
                throw new DataNullOrEmptyException("log list is null or empty");
            }

            Func<Log, bool> predicate = (log) => true;

            if (context.Setting?.AddressStart != null)
            {
                predicate = predicate.And(log => log.IpInt >= context.Setting.AddressStartInt);
            }

            if (context.Setting?.AddressMask != null && context.Setting?.AddressStart != null)
            {
                predicate = predicate.And(log => log.IpInt <= context.Setting.AddressMaskInt);
            }

            if (context.Setting?.StartDate != null)
            {
                var start = context.Setting?.StartDate.Value.Date;
                predicate = predicate.And(log => log.Date != null && log.Date.Value.Date >= start);
            }

            if (context.Setting?.EndDate != null)
            {
                var end = context.Setting?.EndDate.Value.Date;
                predicate = predicate.And(log => log.Date != null && end >= log.Date.Value.Date);
            }

            Func<IGrouping<long?, Log>, string> mapper = (group) =>
            {
                var log = group.FirstOrDefault();
                var ip = log?.Ip.ToString();
                var dates = group.Select(gr => gr.Date?.ToString(FormatConstants.FullDateFormat)).ToList();
                var count = group.Count();
                return $"IP: {ip} REQUEST_COUNT: {count} DATES: {string.Join(";", dates)}";
            };

            var result = logs.Where(predicate)
                .GroupBy(log => log.IpInt)
                .Select(group => mapper(group))
                .ToArray();

            context.Data[Key.Result] = result;
            await Task.CompletedTask;
        }
    }
}