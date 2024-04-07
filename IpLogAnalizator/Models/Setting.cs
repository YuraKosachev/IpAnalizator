using CommandLine;
using IpLogAnalizator.Implementation.Constants;
using IpLogAnalizator.Implementation.Extensions;
using System.Net;
using System.Text.Json.Serialization;


namespace IpLogAnalizator.Models
{
    public class Setting
    {
        [Option("file-log", HelpText = "log file path")]
        [JsonPropertyName("file-log")]
        public string? FileLog { get; set; }

        [Option("file-output", HelpText = "log file output path")]
        [JsonPropertyName("file-output")]
        public string? FileOutput { get; set; }

        [Option("address-start", HelpText = "log file output path")]
        [JsonPropertyName("address-start")]
        public string? AddressStartFormat { get; set; }

        [Option("address-mask", HelpText = "log file output path")]
        [JsonPropertyName("address-mask")]
        public string? AddressMaskFormat { get; set; }

        [Option("time-start", HelpText = "start date")]
        [JsonPropertyName("time-start")]
        public string? StartDateFormat { get; set; }

        [Option("time-end", HelpText = "end date")]
        [JsonPropertyName("time-end")]
        public string? EndDateFormat { get; set; }

        public IPAddress? AddressStart
        {
            get
            {
                return AddressStartFormat?.TryToParse();
            }
        }

        public IPAddress? AddressMask
        {
            get
            {
                return AddressMaskFormat?.TryToParse();
            }
        }

        public long? AddressStartInt { get { return AddressStart?.ToInt(); } }
        public long? AddressMaskInt { get { return AddressMask?.ToInt(); } }
        public DateTime? StartDate { get { return string.IsNullOrEmpty(StartDateFormat) ? null : StartDateFormat.TryToParse(FormatConstants.ShortDateFormat); } }
        public DateTime? EndDate { get { return string.IsNullOrEmpty(EndDateFormat) ? null : EndDateFormat.TryToParse(FormatConstants.ShortDateFormat); } }
    }
}

//--file - log — путь к файлу с логами
//--file-output — путь к файлу с результатом
//--address-start —  нижняя граница диапазона адресов, необязательный параметр, по умолчанию обрабатываются все адреса
//--address-mask — маска подсети, задающая верхнюю границу диапазона десятичное число
//--time-start —  нижняя граница временного интервала
//--time - end — верхняя граница временного интервала.

//
