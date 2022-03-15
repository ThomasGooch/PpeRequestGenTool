using System;
using System.IO;
using System.Threading.Channels;
using McMaster.Extensions.CommandLineUtils;
using PpeRequestGenTool.Business;
using PpeRequestGenTool.Data.Model;
using Spectre.Console;

namespace PpeRequestGenTestTool.Console
{
    class Program
    {

        public static void Main(string[] args)
        {
            var app = new CommandLineApplication<Program>();
            
            #region global-arguments-options

            var inputFileOption = app.Option<string>("-o|--output", "Output file path (working directory)", CommandOptionType.SingleValue);//.IsRequired();
            var verboseOption = app.Option("-v|--verbose", "Display operation details", CommandOptionType.NoValue);

            #endregion

            #region commands

            app.Command("create",
                create =>
                {
                    var template = Template.GetTemplate;
                    var request = new RxVaccineRequest().ParseRequestString(template);
                    var requestBuilder = new RequestsBuilder();
                    var list = requestBuilder.CreateRecords(request, template);
                    requestBuilder.AddRecordsToBatch(list);
                });


            app.Command("delete",
                delete =>
                {
                    System.Console.WriteLine("enter batch file path: ");
                    var batchPathToDelete = System.Console.ReadLine();
                    try
                    {
                        File.Delete(batchPathToDelete);
                    }
                    catch (Exception e)
                    {
                        System.Console.WriteLine("Error deleting file: "+e);
                        throw;
                    }
                    
                });

            app.Command("update",
                update =>
                {
                    System.Console.WriteLine("enter batch path: ");
                    var batchIdToUpdate = System.Console.ReadLine();
                    var requestBuilder = new RequestsBuilder();
                    requestBuilder.UpdateRecordsInBatch(batchIdToUpdate);
                });
            app.Command("addBatchToCollection",
                addBatchToCollection =>
                {
                    System.Console.WriteLine("enter batch file path: ");
                    var batchPathToAddToCollection = System.Console.ReadLine();
                    var requestBuilder = new RequestsBuilder();
                    requestBuilder.AddBatchToCollection(batchPathToAddToCollection);

                });
            app.Command("deleteBatchFromCollection",
                deleteBatchFromCollection =>
                {
                    System.Console.WriteLine("enter batchId: ");
                    var batchPathToDeleteFromCollection = System.Console.ReadLine();
                    var requestBuilder = new RequestsBuilder();
                    requestBuilder.RemoveBatchFromCollection(batchPathToDeleteFromCollection);
                });
            app.Command("createCollectionOutput",
                createCollectionOutput =>
                {
                    var requestBuilder = new RequestsBuilder();
                    requestBuilder.CreateFinalOutput();
                });

            app.Command("print",
                print =>
                {
                    var tailOptions = print.Option<bool>("-t|--tail", "Show n rows from the tail.", CommandOptionType.NoValue);

                    var rowOption = print.Option<int>("-r|--rows", "Number of rows to show", CommandOptionType.SingleValue);

                    print.HelpOption("-? | -h | --help");

                    print.OnExecute(() =>
                    {
                        var inputFile = GetInputFile(inputFileOption);

                        // Zero = all rows
                        var rows = rowOption.HasValue() ? Math.Abs(rowOption.ParsedValue) : 0;

                        if (verboseOption.HasValue())
                            AnsiConsole.Console.Write(tailOptions.HasValue() && rows > 0
                                ? $"Print {rows} records from the tail."
                                : $"Print {rows} records from the top.");

                        // print file
                        AnsiConsole.Console.Write("print.");
                    });
                });

            #endregion
            
            app.HelpOption("-h|--help|-?");
            app.Execute(args);

            

            while (AnsiConsole.Console.Input.ReadKey(true).Key != ConsoleKey.Enter) { }
        }

        private static string GetInputFile(CommandOption<string> inputOption)
        {
            var inputFile = inputOption.ParsedValue;
            if (!Path.IsPathFullyQualified(inputOption.ParsedValue))
                inputFile = Path.GetFullPath(inputOption.ParsedValue);

            if (!File.Exists(inputFile))
                AnsiConsole.Console.Write("File not found.");

            return inputFile;
        }
    }


    public static class Template
    {
        public static string GetTemplate
        {
            get
            {
                return "226T2210407111ZG0352610014D0B1362001    1013366554477     20210203          AM04C2A1234567890C3001C1372001C60AM01C419681231C50CAFN1234567890CBLN1234567890CM401South Main StreetCNSmall TownCOGACP30024AM07EM1D21234567890E103D711877001126E70D30D50D60D80DE20210202DF0NX1DK2EUEVEX1234567890AM03EZ01DB2345678911AM11D9{DC{DQ{DU{DN00D0B11A012233445566     20210202AM21ANPF3AUTHNUMUF1UH01FQMESSAGEAM22EM1D21234567AM23F5{F6{F7{F9{FM0FI{";
            }
        }
    }

}