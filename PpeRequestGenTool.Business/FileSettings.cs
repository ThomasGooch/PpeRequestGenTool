using Microsoft.Extensions.Configuration;
using System.IO;

namespace PpeRequestGenTool.Business
{
    public class FileSettings
    {
        private static IConfigurationBuilder _builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        private static IConfigurationRoot _config = _builder.Build();
        public string DobMax { get; set; } = _config.GetSection("DobMax").Value;
        public string DobMin { get; set; } = _config.GetSection("DobMin").Value;
        public string BatchId { get; set; } = _config.GetSection("BatchId").Value;
        public string TemplateBatchId { get; set; } = _config.GetSection("templateBatchId").Value;
        public string FilePath { get; set; } = _config.GetSection("filePath").Value;
        public string Sequence { get; set; } = _config.GetSection("sequence").Value;
        public int NumberOfRequests { get; set; } = int.Parse(_config.GetSection("numOfReq").Value);
        public string RxNumPrefix { get; set; } = _config.GetSection("rxNumPrefix").Value;

        public FileSettings() { }

    }
}
