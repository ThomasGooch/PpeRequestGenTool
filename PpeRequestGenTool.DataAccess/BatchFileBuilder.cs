using System;
using System.Collections.Generic;
using System.IO;

namespace PpeRequestGenTool.DataAccess
{
    public class BatchFileBuilder : IBatchFileBuilder
    {
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

        public void WriteToBatch(IEnumerable<string> list)
        {

            try
            {
                using (StreamWriter sw = File.AppendText(BatchPath))
                {
                    foreach (var line in list)
                    {
                        sw.WriteLine(line);
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
