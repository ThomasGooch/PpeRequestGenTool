using System;
using System.Collections.Generic;
using System.IO;

namespace PpeRequestGenTool.DataAccess
{
    public class BatchFileBuilder : IBatchFileBuilder
    {
        private const string CUSTOM_RESPONSE = "D0B11A012233445566     20210202AM21ANRF3AUTHNUMUF1UH01FQMESSAGEAM22EM1D21234567AM23F5{F6{F7{F9{FM0FI{";

        public string BatchNum { get; set; }
        public string BatchPath { get; set; }

        public BatchFileBuilder() { }

        public BatchFileBuilder(string path, string number)
        {
            BatchNum = number;
            BatchPath = path + BatchNum + ".txt";
            this.CreateFile(BatchPath);
        }

        public bool CreateFile(string batchPath)
        {
            
            string text = BatchNum + "\n";
            if (!File.Exists(BatchPath))
            {
                File.WriteAllText(BatchPath, text);
                return true;
            }
            else
            {
                Console.WriteLine("file with batch already exists, please delete if necessary: " + BatchPath);
                return false;
            }

        }

        public void WriteToBatch(IEnumerable<string> list, bool addResponse)
        {

            try
            {
                using (StreamWriter sw = File.AppendText(BatchPath))
                {
                    

                    foreach (var line in list)
                    {
                        sw.WriteLine(line);
                        if (addResponse && !line.StartsWith("D0B"))
                        {
                            sw.WriteLine(CUSTOM_RESPONSE);
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("file not written: " + e);
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine("really bad error writing file: " + e);
                throw;
            }
        }
    }
}
