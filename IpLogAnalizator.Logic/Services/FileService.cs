using IpLogAnalizator.Core.Constants;
using IpLogAnalizator.Core.Interfaces;
using IpLogAnalizator.Core.Models;
using IpLogAnalizator.Core.Enums;
using IpLogAnalizator.Core.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IpLogAnalizator.Logic.Services
{
    public class FileService : IFileService
    {
        public async Task<IList<ParseResult>> GetLogFromFileAsync(string path)
        {
            var regexIp = new Regex(PatternConstants.IpPattern);

            var regexDate = new Regex(PatternConstants.DatePattern);

            var lines = await File.ReadAllLinesAsync(path);

            return lines.Select(line => GetLog(line, regexIp, regexDate)).ToList();
        }

        public async Task SaveDataAsync(string path, string[] lines)
        {
            if (!Path.HasExtension(path))
            {
                var fileName = $"{DateTime.Now.ToString(FormatConstants.FileNameFormat)}.txt";
                path = Path.Combine(path, fileName);
            }
            var directoryPath = Path.GetDirectoryName(path);

            var _ = Directory.CreateDirectory(directoryPath);

            await File.WriteAllLinesAsync(path, lines);
        }

        private ParseResult GetLog(string src, Regex regexIp, Regex regexDate)
        {
            var parseResult = new ParseResult();

            parseResult.Source = src;

            if (src == null)
            {
                parseResult.Error = "line is null or empty";
                parseResult.IsError = true;
                return parseResult;
            }

            var ipMath = regexIp.Match(src);
            var dateMath = regexDate.Match(src);

            var log = new Log();

            if (!ipMath.Success || !dateMath.Success)
            {
                parseResult.Error = "date or ip not found or has incorrect format";
                parseResult.IsError = true;
                return parseResult;
            }

            log.Ip = IPAddress.Parse(ipMath.Value);
            log.Date = dateMath.Value.TryToParse(FormatConstants.FullDateFormat);

            parseResult.Log = log;
            return parseResult;

        }
    }
}
