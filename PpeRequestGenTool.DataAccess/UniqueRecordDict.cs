using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;


namespace PpeRequestGenTool.DataAccess
{
    public class UniqueRecordDict : IUniqueRecordDict
    {
        public string FilePath { get; set; }

        public UniqueRecordDict(string filePath)
        {
            FilePath = filePath;
        }
       

        public void PushToUniqueRecordDict(Dictionary<string,string> record)
        {
            File.AppendAllText(FilePath, JsonConvert.SerializeObject(record));
        }

        public Dictionary<string, string> ReadUniqueRecordDict()
        {
            return JsonConvert.DeserializeObject<Dictionary<string, string>>
                (File.ReadAllText(FilePath));
        }
       
    }
}
