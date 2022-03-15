using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace PpeRequestGenTool.DataAccess
{
    public class BatchCollectionFileBuilder : IBatchCollectionFileBuilder
    {
        public string BatchCollectionPath { get; set; }

        public BatchCollectionFileBuilder() { }

        public BatchCollectionFileBuilder(string path)
        {
            BatchCollectionPath = path + ".txt";
        }



        //add batches to file
        public void WriteToBatchCollection(string batchFilePath)
        {
            if (File.Exists(batchFilePath))
            {
                try
                {
                    bool check = CheckBatchForDuplicate(batchFilePath);
                    if (!check)
                    {
                        File.AppendAllText(BatchCollectionPath, File.ReadAllText(batchFilePath));
                        Console.WriteLine("batch pushed to collection.");
                    }
                    else
                    {
                        Console.WriteLine("batch already present in collection: " + batchFilePath);
                        Console.WriteLine("If updating, remove before pushing");
                    }

                }
                catch (IOException e)
                {
                    Console.WriteLine("error appending batch to collection: " + e);
                    throw;
                }
                catch (Exception e)
                {
                    Console.WriteLine("VERY BAD error appending batch to collection: " + e);
                    throw;
                }
            }
            else
            {
                Console.WriteLine("BatchId entered DOES NOT EXIST: " + batchFilePath);
            }


        }

        private bool CheckBatchForDuplicate(string batchPath)
        {
            var result = false;
            var batchNumber = string.Empty;
            var match = Regex.Match(batchPath, "[0-9]{4}");
            if (match.Success)
            {
                batchNumber = match.Captures[0].Value;
            }

            if (File.Exists(BatchCollectionPath))
            {
                result = File.ReadAllLines(BatchCollectionPath).Contains(batchNumber);
            }
            
            return result;
        }

        //remove a batch from the file
        public void RemoveBatchByBatchNumber(string batchNum)
        {
            var path = BatchCollectionPath.Replace(".txt", batchNum + ".txt");
            if (File.Exists(BatchCollectionPath) && File.Exists(path))
            {
                try
                {
                    string[] collection = System.IO.File.ReadAllLines(BatchCollectionPath);
                    string[] batchToRemove = System.IO.File.ReadAllLines(path);

                    // Create the query. Note that method syntax must be used here.  
                    IEnumerable<string> differenceQuery =
                        collection.Except(batchToRemove);

                    File.WriteAllLines(BatchCollectionPath, differenceQuery);
                }
                catch (IOException e)
                {
                    Console.WriteLine("error removing batch to collection: " + e);
                    throw;
                }
                catch (Exception e)
                {
                    Console.WriteLine("VERY BAD error removing batch to collection: " + e);
                    throw;
                }
            }
            else
            {
                Console.WriteLine("Batch and/or Collection DO NOT EXIST");
            }

        }

        public void CreateFinalOutputFile()
        {
            var filePath = BatchCollectionPath.Replace(".txt", "_output.txt");
            if (!File.Exists(filePath))
            {
                try
                {
                    using (StreamWriter sw = File.AppendText(filePath))
                    {
                        foreach (var line in File.ReadAllLines(BatchCollectionPath))
                        {
                            if (!Regex.IsMatch(line, "^[0-9]{4}$"))
                            {
                                sw.WriteLine(line);
                            }
                        }
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine("Error writing output file: " + e);
                    throw;
                }
                catch (Exception e)
                {
                    Console.WriteLine("BIG Error writing output file: " + e);
                    throw;
                }
            }
            else
            {
                Console.WriteLine("Final Output File ALREADY EXISTS, DELETE ON YOUR SYSTEM: " + filePath);
            }

        }
    }
}
