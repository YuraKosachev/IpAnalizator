using IpLogAnalizator.Implementation.Constants;
using IpLogAnalizator.Implementation.Enums;
using IpLogAnalizator.Implementation.Exceptions;
using IpLogAnalizator.Implementation.Extensions;
using IpLogAnalizator.Interfaces;
using IpLogAnalizator.Models;

namespace IpLogAnalizator.Implementation.Handlers
{
    public class DataPreparationHandler : BaseHandler, IHandler
    {
        public DataPreparationHandler(IAppFactory appFactory) : base(appFactory)
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

            var result = logs.Where(predicate)
                .GroupBy(log => log.IpInt)
                .Select(group =>
                {
                    var log = group.FirstOrDefault();
                    var ip = log.Ip.ToString();
                    var dates = string.Join(";", group.Select(gr => gr.Date.Value.ToString(FormatConstants.FullDateFormat)).ToList());
                    var count = group.Count();
                    return $"ip: {ip} request count: {count} dates: {dates}";
                })
                .ToArray();

            context.Data[Key.Result] = result;
            await Task.CompletedTask;
        }
    }
}