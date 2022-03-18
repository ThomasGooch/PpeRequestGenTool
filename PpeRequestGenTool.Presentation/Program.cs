
using System;
using System.IO;
using PpeRequestGenTool.Business;
using PpeRequestGenTool.Data.Model;
using System.Text.RegularExpressions;


namespace PpeRequestGenTool.Presentation
{
    class Program
    {
        private static RequestsBuilder requestBuilder = new RequestsBuilder();
       

        static void Main(string[] args)
        {
            AppMenu();
        }

        private static void AppMenu()
        {
            Console.WriteLine("======================");
            Console.WriteLine("Welcome to Ppe Request Generator Tool");
            Console.WriteLine("======================");
            Console.WriteLine("1. create a batch");
            Console.WriteLine("2. peek at a batch");
            Console.WriteLine("3. delete a batch");
            Console.WriteLine("4. update a batch");
            Console.WriteLine("5. push batches to collection");
            Console.WriteLine("6. peek at the collection");
            Console.WriteLine("7. remove batch from the collection");
            Console.WriteLine("8. create final test file");
            Console.WriteLine("9. QUIT()");
            Console.WriteLine("======================");
            Choice();
        }

        private static void Choice()
        {
            string menuChoice;
            if (!IsValidPath(requestBuilder.FileSettingsProp.FilePath))
            {
                Console.WriteLine("======================");
                Console.WriteLine("INVALID FilePath within appsettings.");
                Console.WriteLine("======================");
                menuChoice = "9";
            }
            else
            {
                Console.WriteLine("file path to be used: " + requestBuilder.FileSettingsProp.FilePath);
                Console.WriteLine("please make a selection: (1-8) or (9) to quit:");
                menuChoice = Console.ReadLine();
            }

            switch (menuChoice)
            {
                case "1":
                    CreateBatch(false);
                    break;
                case "2":
                    PeekAtBatch();
                    break;
                case "3":
                    DeleteABatch();
                    break;
                case "4":
                    CreateBatch(true);
                    break;
                case "5":
                    PushBatchesToCollection();
                    break;
                case "6":
                    PeekAtTheCollection();
                    break;
                case "7":
                    RemoveBatchesFromTheCollection();
                    break;
                case "8":
                    CreateFinalTestFile();
                    break;
                case "9":
                    Exit();
                    break;
                default:
                    Console.WriteLine("Your choice is invalid: " + menuChoice);
                    AppMenu();
                    break;
            }
        }

        private static void Exit()
        {
            Environment.Exit(0);
        }

        private static void CreateFinalTestFile()
        {
            Console.WriteLine("Ready to create final test file?: (T/F)");
            var createOutput = Console.ReadLine();
            if (createOutput.ToLower() == "t" && !File.Exists(requestBuilder.FileSettingsProp.FilePath + "_output.txt"))
            {
                requestBuilder.CreateFinalOutput();
                Console.WriteLine("Test File Created: " + requestBuilder.FileSettingsProp.FilePath + "_output.txt");
            }
            else if (File.Exists(requestBuilder.FileSettingsProp.FilePath + "_output.txt"))
            {
                Console.WriteLine("File already exists, please delete from folder: " +
                                  requestBuilder.FileSettingsProp.FilePath + "_output.txt");
            }
            else
            {
                Console.WriteLine("Output File Creation Aborted.");
            }

            Console.WriteLine("Press Enter to CONTINUE: ");
            Console.ReadLine();
            AppMenu();
        }

        private static void RemoveBatchesFromTheCollection()
        {
            Console.WriteLine("Any batches need to be deleted from the collection?(001,002,003,...)");
            var batchesForDeletionFromCollectionStr = Console.ReadLine();
            var batchesForDeletionFromCollectionToArray = batchesForDeletionFromCollectionStr.Split(",");
            if (batchesForDeletionFromCollectionToArray.Length > 0)
            {
                foreach (var batch in batchesForDeletionFromCollectionToArray)
                {
                    requestBuilder.RemoveBatchFromCollection(batch);
                }

                requestBuilder.PeekAtCollection();
            }

            Console.WriteLine("Press Enter to CONTINUE: ");
            Console.ReadLine();
            AppMenu();
        }

        private static void PeekAtTheCollection()
        {
            requestBuilder.PeekAtCollection();
            Console.WriteLine("Press Enter to CONTINUE: ");
            Console.ReadLine();
            AppMenu();
        }

        private static void PushBatchesToCollection()
        {
            Console.WriteLine("Any batches ready for collection? (0001,0002,0003,...)");
            var batchesForCollectionStr = Console.ReadLine();
            var batchesForCollectionToArray = batchesForCollectionStr.Split(",");
            if (batchesForCollectionToArray.Length > 0 && !string.IsNullOrWhiteSpace(batchesForCollectionToArray[0]))
            {
                foreach (var batch in batchesForCollectionToArray)
                {
                    var _path = Path.Join(requestBuilder.FileSettingsProp.FilePath + batch.Trim() + ".txt");
                    requestBuilder.AddBatchToCollection(_path);
                }
            }
            else
            {
                Console.WriteLine("Missing/Invalid Entry");
            }

            Console.WriteLine("Press Enter to CONTINUE: ");
            Console.ReadLine();
            AppMenu();
        }

        private static void DeleteABatch()
        {
            Console.WriteLine("Any batches for deletion? (0001,0002,0003,...)");
            var batchesForDeletionStr = Console.ReadLine();
            var batchesForDeletionToArray = batchesForDeletionStr.Split(",");
            if (batchesForDeletionToArray.Length > 0 && File.Exists(requestBuilder.FileSettingsProp.FilePath + ".txt"))
            {
                foreach (var batch in batchesForDeletionToArray)
                {
                    requestBuilder.RemoveBatchFromCollection(batch);
                }
            }

            if (batchesForDeletionToArray.Length > 0)
            {
                foreach (var batch in batchesForDeletionToArray)
                {
                    if (File.Exists(requestBuilder.FileSettingsProp.FilePath + batch + ".txt"))
                    {
                        File.Delete(requestBuilder.FileSettingsProp.FilePath + batch + ".txt");
                        Console.WriteLine("File Deleted: " + requestBuilder.FileSettingsProp.FilePath + batch + ".txt");
                    }
                    else
                    {
                        Console.WriteLine("File never existed: " + requestBuilder.FileSettingsProp.FilePath + batch +
                                          ".txt");
                    }

                }
            }

            Console.WriteLine("Press Enter to CONTINUE: ");
            Console.ReadLine();
            AppMenu();
        }

        private static void PeekAtBatch()
        {
            Console.WriteLine("Please enter batchId to peek inside: (0001)");
            var batchId = Console.ReadLine();
            var batchIdPath = requestBuilder.FileSettingsProp.FilePath + batchId + ".txt";
            requestBuilder.PeekAtBatch(batchIdPath);
            Console.WriteLine("Press Enter to CONTINUE: ");
            Console.ReadLine();
            AppMenu();
        }

        private static void CreateBatch(bool toUpdate)
        {

            var update = toUpdate;
            var fileExists = File.Exists(requestBuilder.FileSettingsProp.FilePath +
                                         requestBuilder.FileSettingsProp.BatchId + ".txt");
            if (fileExists && !update)
            {
                Console.WriteLine("this file already exists. please choose UPDATE (4).");
                Console.WriteLine(" ");
                Console.WriteLine("Press Enter to CONTINUE: ");
                Console.ReadLine();
                AppMenu();
            }
            else if (requestBuilder.FileSettingsProp.TemplateBatchId == string.Empty && !fileExists && !update)
            {
                Console.WriteLine("templateId is EMPTY, paste in request string for new batch: ");
                var template = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(template))
                {
                    Console.WriteLine("You have submitted an empty string.");
                    Console.WriteLine("Press Enter to CONTINUE: ");
                    Console.ReadLine();
                    AppMenu();
                }

                

                var listOfRecords = requestBuilder.CreateRecords(template);
                var pathToBatch = requestBuilder.AddRecordsToBatch(listOfRecords);
                // peek into file
                requestBuilder.PeekAtBatch(pathToBatch);


            }
            else if (fileExists)
            {
                Console.WriteLine("Confirm updating file: " + requestBuilder.FileSettingsProp.FilePath +
                                  requestBuilder.FileSettingsProp.BatchId + ".txt" + " ? (T/F)");
                var confirmUpdate = Console.ReadLine();
                if (confirmUpdate.ToLower() == "t")
                {
                    requestBuilder.UpdateRecordsInBatch(requestBuilder.FileSettingsProp.FilePath +
                                                        requestBuilder.FileSettingsProp.BatchId + ".txt");
                    requestBuilder.PeekAtBatch(requestBuilder.FileSettingsProp.FilePath +
                                               requestBuilder.FileSettingsProp.BatchId + ".txt");
                }
                else
                {
                    Console.WriteLine("Update Aborted");
                    Console.WriteLine(" ");
                    Console.WriteLine("Press Enter to CONTINUE: ");
                    Console.ReadLine();
                    AppMenu();
                }

            }
            else
            {
                Console.WriteLine("templateId: " + requestBuilder.FileSettingsProp.TemplateBatchId);
                if (File.Exists(requestBuilder.FileSettingsProp.FilePath +
                                requestBuilder.FileSettingsProp.TemplateBatchId + ".txt"))
                {
                    try
                    {
                        var path = requestBuilder.CreateRecordsByTemplate(requestBuilder.FileSettingsProp
                            .TemplateBatchId);
                        requestBuilder.PeekAtBatch(path);
                    }
                    catch (IOException e)
                    {
                        Console.WriteLine("Error reading template: " + e);
                        throw;
                    }
                }
                else
                {
                    Console.WriteLine("Template file DOESN't EXIST: " +
                                      requestBuilder.FileSettingsProp.TemplateBatchId);
                }
            }
            Console.WriteLine("Press Enter to CONTINUE: ");
            Console.ReadLine();
            AppMenu();
        }

        private static bool IsValidPath(string path)
        {
            var r = new Regex(@"^(?:[a-zA-Z]\:|\\\\[\w\]+\\[\w$]+)\\(?:[\w]+\\)*\w([\w])+$");
            var result = r.IsMatch(path);
            return result;
        }
    }
}
