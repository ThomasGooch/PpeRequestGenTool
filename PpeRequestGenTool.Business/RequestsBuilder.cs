﻿using PpeRequestGenTool.Data.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;
using PpeRequestGenTool.DataAccess;
using System.Text.RegularExpressions;
using System.Globalization;

namespace PpeRequestGenTool.Business
{
    public class RequestsBuilder : IRequestsBuilder
    {
        private static IConfigurationBuilder _builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        private static IConfigurationRoot _config = _builder.Build();

        #region Fields

        public int NumberOfRequest { get; set; }
        public FileSettings FileSettingsProp { get; set; }
        public string[] FirstNamesList { get; set; }
        public string[] LastNamesList { get; set; }
        public UniqueRecordDict UniqueRecord { get; set; }
        public Dictionary<string, string> UniqueDictionary { get; set; }
        #endregion
        public RequestsBuilder()
        {
            FileSettingsProp = new FileSettings();
            NumberOfRequest = int.Parse(_config.GetSection("numOfReq").Value);
            FirstNamesList = GetNames("first_names.csv");
            LastNamesList = GetNames("last_names.csv");
            UniqueRecord = new UniqueRecordDict(_config.GetSection("filePath").Value + "_dictionary.txt");
            UniqueDictionary = new Dictionary<string, string>();
        }

        #region PublicMethods

        public IEnumerable<string> CreateRecords(string requestStr)
        {

            if (bool.Parse(_config.GetSection("SmartHop").Value))
            {
                var parsedObj = new SmartHopRequest();
                var result = new List<string>();
                for (int i = 0; i < NumberOfRequest; i++)
                {
                    // create altered string
                    string _record = "";
                    var flag = false;
                    while (!flag)
                    {
                        _record = AlterRequestString(parsedObj.ParseRequestString(requestStr), requestStr, i);
                        flag = CheckForUniqueness(_record);
                    }
                    result.Add(_record);
                }
                UniqueRecord.PushToUniqueRecordDict(UniqueDictionary);
                return result;
            }
            else
            {
                var parsedObj = new RxVaccineRequest();

                var result = new List<string>();
                for (int i = 0; i < NumberOfRequest; i++)
                {
                    // create altered string
                    string _record = "";
                    var flag = false;
                    while (!flag)
                    {
                        _record = AlterRequestString(parsedObj.ParseRequestString(requestStr), requestStr, i);
                        flag = CheckForUniqueness(_record);
                    }
                    result.Add(_record);
                }
                UniqueRecord.PushToUniqueRecordDict(UniqueDictionary);
                return result;
            }



        }


        private bool CheckForUniqueness(string record)
        {
            // make smarthop addition
            if (bool.Parse(_config.GetSection("SmartHop").Value))
            {
                var parser = new SmartHopRequest();
                var obj = parser.ParseRequestString(record);
                var key = obj.FirstName + obj.LastName + obj.DateOfBirth + obj.ZipCode;
                if (File.Exists(UniqueRecord.FilePath) && UniqueDictionary.ContainsKey(key))
                {
                    return false;
                }
                else
                {
                    UniqueDictionary.Add(key, "");
                    return true;
                }
            }
            else
            {
                var parser = new RxVaccineRequest();
                var obj = parser.ParseRequestString(record);
                var key = obj.FirstName + obj.LastName + obj.DateOfBirth + obj.ZipCode;
                if (File.Exists(UniqueRecord.FilePath) && UniqueDictionary.ContainsKey(key))
                {
                    return false;
                }
                else
                {
                    UniqueDictionary.Add(key, "");
                    return true;
                }
            }


        }

        public string CreateRecordsByTemplate(string templateBatchId)
        {
            if (bool.Parse(_config.GetSection("SmartHop").Value))
            {
                var request = new SmartHopRequest();
                var path = Path.Join(_config.GetSection("filePath").Value + templateBatchId + ".txt");
                var listOfRecords = File.ReadLines(path);
                var listOfUpdatedRecords = new List<string>();
                foreach (var record in listOfRecords)
                {
                    if (record.Length > 5)
                    {
                        var _record = request.ParseRequestString(record);
                        listOfUpdatedRecords.Add(UpdateARecord(_record, record));
                    }

                }

                var batch = new BatchFileBuilder(_config.GetSection("filePath").Value, _config.GetSection("batchId").Value);
                batch.WriteToBatch(listOfUpdatedRecords, bool.Parse(_config.GetSection("CustomResponseAdded").Value));
                return batch.BatchPath;
            }
            else {
                var request = new RxVaccineRequest();
                var path = Path.Join(_config.GetSection("filePath").Value + templateBatchId + ".txt");
                var listOfRecords = File.ReadLines(path);
                var listOfUpdatedRecords = new List<string>();
                foreach (var record in listOfRecords)
                {
                    if (record.Length > 5)
                    {
                        var _record = request.ParseRequestString(record);
                        listOfUpdatedRecords.Add(UpdateARecord(_record, record));
                    }

                }

                var batch = new BatchFileBuilder(_config.GetSection("filePath").Value, _config.GetSection("batchId").Value);
                batch.WriteToBatch(listOfUpdatedRecords, false);
                return batch.BatchPath;
            }

        }

        public string AddRecordsToBatch(IEnumerable<string> list)
        {
            var batch = new BatchFileBuilder(FileSettingsProp.FilePath, FileSettingsProp.BatchId);
            batch.WriteToBatch(list, bool.Parse(_config.GetSection("CustomResponseAdded").Value));
            return batch.BatchPath;

        }

        public void UpdateRecordsInBatch(string batchPath)
        {
            if (!File.Exists(batchPath))
            {
                Console.WriteLine("FILE DOES NOT EXIST! cannot update.");
                return;
            }

            if (bool.Parse(_config.GetSection("SmartHop").Value))
            {
                // we want to go through each row and update accordingly
                var request = new SmartHopRequest();
                var batchNumber = string.Empty;
                var match = Regex.Match(batchPath, "[0-9]{4}");
                if (match.Success)
                {
                    batchNumber = match.Captures[0].Value;
                }
                var listOfRecords = File.ReadLines(batchPath).Skip(1);
                var listOfUpdatedRecords = new List<string>();
                foreach (var record in listOfRecords)
                {
                    if (record.StartsWith("D0B")) continue;
                    var _record = request.ParseRequestString(record);
                    listOfUpdatedRecords.Add(UpdateARecord(_record, record));
                }
                if (File.Exists(_config.GetSection("filePath").Value + ".txt"))
                {
                    RemoveBatchFromCollection(batchNumber);
                }

                try
                {
                    File.Delete(batchPath);
                }
                catch (IOException e)
                {
                    Console.WriteLine("error updating batch records: " + e);
                    throw;
                }
                var batch = new BatchFileBuilder(_config.GetSection("filePath").Value, batchNumber);
                batch.WriteToBatch(listOfUpdatedRecords, bool.Parse(_config.GetSection("CustomResponseAdded").Value));
            }
            else
            {
                // we want to go through each row and update accordingly
                var request = new RxVaccineRequest();
                var batchNumber = string.Empty;
                var match = Regex.Match(batchPath, "[0-9]{4}");
                if (match.Success)
                {
                    batchNumber = match.Captures[0].Value;
                }
                var listOfRecords = File.ReadLines(batchPath).Skip(1);
                var listOfUpdatedRecords = new List<string>();
                foreach (var record in listOfRecords)
                {
                    var _record = request.ParseRequestString(record);
                    listOfUpdatedRecords.Add(UpdateARecord(_record, record));
                }
                if (File.Exists(_config.GetSection("filePath").Value + ".txt"))
                {
                    RemoveBatchFromCollection(batchNumber);
                }

                try
                {
                    File.Delete(batchPath);
                }
                catch (IOException e)
                {
                    Console.WriteLine("error updating batch records: " + e);
                    throw;
                }
                var batch = new BatchFileBuilder(_config.GetSection("filePath").Value, batchNumber);
                batch.WriteToBatch(listOfUpdatedRecords, bool.Parse(_config.GetSection("CustomResponseAdded").Value));
            }

        }

        public string AddBatchToCollection(string batchFilePath)
        {
            var batchCollection = new BatchCollectionFileBuilder(_config.GetSection("filePath").Value);
            batchCollection.WriteToBatchCollection(batchFilePath);
            return batchCollection.BatchCollectionPath;
        }

        public void PeekAtBatch(string batchPath)
        {
            if (File.Exists(batchPath))
            {
                var list = File.ReadAllLines(batchPath).ToList();
                var totalLines = list.Count;
                Console.WriteLine("==========================");
                Console.WriteLine("for batch: " + list[0] + " there are " + (totalLines - 1) + " total records.");
                Console.WriteLine("==========================");
                foreach (var record in list.Skip(1).Take(5))
                {
                    Console.WriteLine(record);
                }
                Console.WriteLine("==========================");
                Console.WriteLine("do you wish to see all records? (T/F)");
                var decision = Console.ReadLine();
                if (decision.ToLower() == "t")
                {
                    Console.WriteLine("============ALL RECORDS============");
                    foreach (var record in list.Skip(1))
                    {
                        Console.WriteLine(record);
                    }
                    Console.WriteLine("==========================");
                }
            }
            else
            {
                Console.WriteLine("Invalid batchId: " + batchPath);
            }

        }

        public void PeekAtCollection()
        {
            if (File.Exists(_config.GetSection("filePath").Value + ".txt"))
            {
                var list = File.ReadAllLines(_config.GetSection("filePath").Value + ".txt").ToList();
                var totalBatches = list.Count(x => Regex.IsMatch(x, "^[0-9]{4}$"));
                var listOfBatches = list.Where(x => Regex.IsMatch(x, "^[0-9]{4}$")).ToList();
                var totalLines = list.Count - totalBatches;
                Console.WriteLine("=============CURRENT COLLECTION=============");
                Console.WriteLine("for the collection there are " + totalLines + " total records.");
                Console.WriteLine("for the collection there are " + totalBatches + " total batches.");
                Console.WriteLine("==========COLLECTION BATCH LIST==========");
                foreach (var record in listOfBatches)
                {
                    Console.WriteLine(record);
                }
                Console.WriteLine("==========================");
            }
            else
            {
                Console.WriteLine("Collection has not yet been created. Push a Batch to Collection for creation. ");
            }


        }

        public void RemoveBatchFromCollection(string batchNumber)
        {
            var batchCollection = new BatchCollectionFileBuilder(_config.GetSection("filePath").Value);
            batchCollection.RemoveBatchByBatchNumber(batchNumber);
        }

        public void CreateFinalOutput()
        {
            var batchCollection = new BatchCollectionFileBuilder(_config.GetSection("filePath").Value);
            batchCollection.CreateFinalOutputFile();
        }

        #endregion




        #region PrivateMethods

        private string[] GetNames(string path)
        {
            var names = File.ReadLines(path);
            return names.ToArray();
        }
        private string RetrieveRandomFirstName()
        {
            var random = new Random();
            int index = random.Next(FirstNamesList.Count());
            var result = FirstNamesList[index];
            return result;
        }
        private string RetrieveRandomLastName()
        {
            var random = new Random();
            int index = random.Next(LastNamesList.Count());
            var result = LastNamesList[index];
            return result;
        }
        private string RetrieveRandomPersonCode()
        {
            var result = CreateRandomDigits(3);
            return result;
        }
        private string RetrieveRandomZipCode()
        {
            var result = CreateRandomDigits(9);
            return result;
        }
        private string CreateRandomDigits(int value)
        {
            var random = new Random();
            var result = string.Empty;
            for (int i = 0; i < value; i++)
                result = string.Concat(result, random.Next(10).ToString());
            return result;
        }
        private string extractPrefix(string slice, string setting)
        {
            var _slice = slice.Substring(2);
            var result = string.Empty;
            var prefix = string.Empty;
            var match = Regex.Match(_slice, "^[a-zA-Z]*");
            if (match.Success)
            {
                prefix = match.Captures[0].Value;
            }

            if (!string.IsNullOrWhiteSpace(prefix))
            {
                result = slice.Replace(prefix, setting);
            }
            else
            {
                result = slice.Substring(0, 2) + setting + _slice;
            }

            return result;
        }
        private string RetrieveRandomDate(string max, string min, string type)
        {
            var outputDateFormat = "yyyyMMdd";
            var today = DateTime.Now;
            if (type == "birth")
            {
                var start = today.AddYears(int.Parse(min));
                var end = today.AddYears(int.Parse(max));
                var gen = new Random(Guid.NewGuid().GetHashCode());
                var range = (int)(end - start).TotalDays;
                var result = start.AddDays(gen.Next(range)).ToString(outputDateFormat);
                return result;
            }
            else
            {
                var start = today.AddDays(int.Parse(min));
                var end = today.AddDays(int.Parse(max));
                var gen = new Random(Guid.NewGuid().GetHashCode());
                var range = (int)(end - start).TotalDays;
                var result = start.AddDays(gen.Next(range)).ToString(outputDateFormat);
                return result;
            }
        }
        private string FindDateByChange(string date, string value)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            var outputDateFormat = "yyyyMMdd";
            var _date = DateTime.ParseExact(date.Substring(2), outputDateFormat, provider);
            var result = _date.AddDays(int.Parse(value)).ToString(outputDateFormat);
            return result;
        }
        private string IncrementValue(int number)
        {
            long result = long.Parse(_config.GetSection("sequence").Value) + number;
            return result.ToString();
        }
        private string FindRequestLength(string v)
        {
            string fmt = "0000.##";
            var etxIndex = v.IndexOf((char)3) + 1;
            return (etxIndex - int.Parse(_config.GetSection("requestStartPoint").Value)).ToString(fmt);
        }
        private string AlterRequestString(BaseRequest parsedObj, string requestStr, int count)
        {

            //when given an object we need it to be found as a smarthop or an rxvaccinerequest

            var smartHopReq = parsedObj as SmartHopRequest;
            var rxVaccineReq = parsedObj as RxVaccineRequest;

            if (smartHopReq != null)
            {
                var result = new StringBuilder(requestStr);
                var fieldSettings = _config.GetSection("editableFields");
                //var requestLength = requestStr.Substring(16, 4);
                if (!string.IsNullOrEmpty(smartHopReq.FirstName))
                {
                    result.Replace(smartHopReq.FirstName, "CA" + RetrieveRandomFirstName()); 
                }
                if (!string.IsNullOrEmpty(smartHopReq.LastName))
                {
                    result.Replace(smartHopReq.LastName, "CB" + RetrieveRandomLastName()); 
                }
                if (!string.IsNullOrEmpty(smartHopReq.RxNumber))
                {
                    result.Replace(smartHopReq.RxNumber, "D2" + fieldSettings.GetSection("rxNumberPrefix").Value + IncrementValue(count)); 
                }
                if (!string.IsNullOrEmpty(smartHopReq.CardholderId) && fieldSettings.GetSection("cardholderIdPrefix").Value != "SKIP" )
                {
                    result.Replace(smartHopReq.CardholderId, "C2" + fieldSettings.GetSection("cardholderIdPrefix").Value + IncrementValue(count));
                }
                if (!string.IsNullOrEmpty(smartHopReq.PersonCode))
                {
                    if (!(fieldSettings.GetSection("personCode").Value == "SKIP" || fieldSettings.GetSection("personCode").Value == "RANDOM"))
                    {
                        result.Replace(smartHopReq.PersonCode, "C3" + fieldSettings.GetSection("personCode").Value);
                    }
                    else if (fieldSettings.GetSection("personCode").Value == "RANDOM")
                    {
                        result.Replace(smartHopReq.PersonCode, "C3" + RetrieveRandomPersonCode());
                    } 
                }
                if (!string.IsNullOrEmpty(smartHopReq.SccCode))
                {
                    result.Replace(smartHopReq.SccCode, "DK" + fieldSettings.GetSection("sccCode").Value); 
                }
                if (!string.IsNullOrEmpty(smartHopReq.DateOfBirth))
                {
                    result.Replace(smartHopReq.DateOfBirth, "C4" + RetrieveRandomDate(_config.GetSection("DobMax").Value, _config.GetSection("DobMin").Value, "birth")); 
                }
                if (!string.IsNullOrEmpty(smartHopReq.ZipCode))
                {
                    result.Replace(smartHopReq.ZipCode, "CP" + RetrieveRandomZipCode()); 
                }
                if (!string.IsNullOrEmpty(smartHopReq.NdcCode) && fieldSettings.GetSection("ndc").Value != "SKIP")
                {
                    result.Replace(smartHopReq.NdcCode, "D7" + fieldSettings.GetSection("ndc").Value);
                }
                //var adjustedLength = FindRequestLength(result.ToString());
                //result.Replace(requestLength, adjustedLength);
                return result.ToString();
            }
            else
            {
                var result = new StringBuilder(requestStr);
                var fieldSettings = _config.GetSection("editableFields");
                var requestLength = requestStr.Substring(16, 4);
                result.Replace(rxVaccineReq.FirstName, "CA" + RetrieveRandomFirstName());
                result.Replace(rxVaccineReq.LastName, "CB" + RetrieveRandomLastName());
                result.Replace(rxVaccineReq.RxNumber, "D2" + fieldSettings.GetSection("rxNumberPrefix").Value + IncrementValue(count));
                if (fieldSettings.GetSection("cardholderIdPrefix").Value != "SKIP")
                {
                    result.Replace(rxVaccineReq.CardholderId, "C2" + fieldSettings.GetSection("cardholderIdPrefix").Value + IncrementValue(count));
                }
                if (!(fieldSettings.GetSection("personCode").Value == "SKIP" || fieldSettings.GetSection("personCode").Value == "RANDOM"))
                {
                    result.Replace(rxVaccineReq.PersonCode, "C3" + fieldSettings.GetSection("personCode").Value);
                }
                else if (fieldSettings.GetSection("personCode").Value == "RANDOM")
                {
                    result.Replace(rxVaccineReq.PersonCode, "C3" + RetrieveRandomPersonCode());
                }
                result.Replace(rxVaccineReq.SccCode, "DK" + fieldSettings.GetSection("sccCode").Value);
                //result.Replace(rxVaccineReq.DateOfService, "D1" + RetrieveRandomDate(_config.GetSection("DosMax").Value, _config.GetSection("DosMin").Value, "service"));
                result.Replace(rxVaccineReq.DateOfBirth, "C4" + RetrieveRandomDate(_config.GetSection("DobMax").Value, _config.GetSection("DobMin").Value, "birth"));
                result.Replace(rxVaccineReq.ZipCode, "CP" + RetrieveRandomZipCode());
                result.Replace(rxVaccineReq.Override, "EV" + fieldSettings.GetSection("override").Value);
                if (fieldSettings.GetSection("ndc").Value != "SKIP")
                {
                    result.Replace(rxVaccineReq.NdcCode, "D7" + fieldSettings.GetSection("ndc").Value);
                }
                var adjustedLength = FindRequestLength(result.ToString());
                result.Replace(requestLength, adjustedLength);
                return result.ToString();
            }

        }
        private string UpdateARecord(BaseRequest parsedObj, string requestStr)
        {
            var smartHopReq = parsedObj as SmartHopRequest;
            var rxVaccineReq = parsedObj as RxVaccineRequest;

            if (smartHopReq != null)
            {
                var result = new StringBuilder(requestStr);
                var fieldSettings = _config.GetSection("duplicateBatch");
                //var requestLength = requestStr.Substring(16, 4);
                if (!string.IsNullOrEmpty(smartHopReq.FirstName) && fieldSettings.GetSection("firstName").Value != "SKIP")
                {
                    result.Replace(smartHopReq.FirstName, "CA" + RetrieveRandomFirstName());
                }
                if (!string.IsNullOrEmpty(smartHopReq.LastName) && fieldSettings.GetSection("lastName").Value != "SKIP")
                {
                    result.Replace(smartHopReq.LastName, "CB" + RetrieveRandomLastName());
                }
                if (!string.IsNullOrEmpty(smartHopReq.RxNumber) && fieldSettings.GetSection("rxNumberPrefix").Value != "SKIP")
                {
                    var _extract = extractPrefix(smartHopReq.RxNumber, fieldSettings.GetSection("rxNumberPrefix").Value);
                    result.Replace(smartHopReq.RxNumber, _extract);
                }
                if (!string.IsNullOrEmpty(smartHopReq.CardholderId) && fieldSettings.GetSection("cardholderIdPrefix").Value != "SKIP")
                {
                    var _extract = extractPrefix(smartHopReq.CardholderId, fieldSettings.GetSection("cardholderIdPrefix").Value);
                    result.Replace(smartHopReq.CardholderId, _extract);
                }
                if (!string.IsNullOrEmpty(smartHopReq.SccCode) && fieldSettings.GetSection("sccCode").Value != "SKIP")
                {
                    result.Replace(smartHopReq.SccCode, "DK" + fieldSettings.GetSection("sccCode").Value);
                }
                if (!string.IsNullOrEmpty(smartHopReq.NdcCode) && fieldSettings.GetSection("ndc").Value != "SKIP")
                {
                    result.Replace(smartHopReq.NdcCode, "D7" + fieldSettings.GetSection("ndc").Value);
                }
                if (!string.IsNullOrEmpty(smartHopReq.PersonCode))
                {
                    if (!(fieldSettings.GetSection("personCode").Value == "SKIP" || fieldSettings.GetSection("personCode").Value == "RANDOM"))
                    {
                        result.Replace(smartHopReq.PersonCode, "C3" + fieldSettings.GetSection("personCode").Value);
                    }
                    else if (fieldSettings.GetSection("personCode").Value == "RANDOM")
                    {
                        result.Replace(smartHopReq.PersonCode, "C3" + RetrieveRandomPersonCode());
                    } 
                }
                if (!string.IsNullOrEmpty(smartHopReq.DateOfBirth))
                {
                    if (!(fieldSettings.GetSection("dob").Value == "SKIP" || fieldSettings.GetSection("dob").Value == "RANDOM"))
                    {
                        // find increment or decrement
                        var _change = FindDateByChange(smartHopReq.DateOfBirth, fieldSettings.GetSection("dob").Value);
                        result.Replace(smartHopReq.DateOfBirth, "C4" + _change);
                    }
                    else if (fieldSettings.GetSection("dob").Value == "RANDOM")
                    {
                        result.Replace(smartHopReq.DateOfBirth, "C4" + RetrieveRandomDate(fieldSettings.GetSection("DobMin").Value, fieldSettings.GetSection("DobMax").Value, "birth"));
                    } 
                }


                if (!string.IsNullOrEmpty(smartHopReq.ZipCode))
                {
                    if (!(fieldSettings.GetSection("zipcode").Value == "SKIP" || fieldSettings.GetSection("zipcode").Value == "RANDOM"))
                    {
                        result.Replace(smartHopReq.ZipCode, "CP" + fieldSettings.GetSection("zipcode").Value);
                    }
                    else if (fieldSettings.GetSection("zipcode").Value == "RANDOM")
                    {
                        result.Replace(smartHopReq.ZipCode, "CP" + RetrieveRandomZipCode());
                    } 
                }


                //var adjustedLength = FindRequestLength(result.ToString());
                //result.Replace(requestLength, adjustedLength);
                return result.ToString();
            }
            else
            {
                var result = new StringBuilder(requestStr);
                var fieldSettings = _config.GetSection("duplicateBatch");
                var requestLength = requestStr.Substring(16, 4);
                if (fieldSettings.GetSection("firstName").Value != "SKIP")
                {
                    result.Replace(rxVaccineReq.FirstName, "CA" + RetrieveRandomFirstName());
                }
                if (fieldSettings.GetSection("lastName").Value != "SKIP")
                {
                    result.Replace(rxVaccineReq.LastName, "CB" + RetrieveRandomLastName());
                }
                if (fieldSettings.GetSection("rxNumberPrefix").Value != "SKIP")
                {
                    var _extract = extractPrefix(rxVaccineReq.RxNumber, fieldSettings.GetSection("rxNumberPrefix").Value);
                    result.Replace(rxVaccineReq.RxNumber, _extract);
                }
                if (fieldSettings.GetSection("cardholderIdPrefix").Value != "SKIP")
                {
                    var _extract = extractPrefix(rxVaccineReq.CardholderId, fieldSettings.GetSection("cardholderIdPrefix").Value);
                    result.Replace(rxVaccineReq.CardholderId, _extract);
                }
                if (fieldSettings.GetSection("sccCode").Value != "SKIP")
                {
                    result.Replace(rxVaccineReq.SccCode, "DK" + fieldSettings.GetSection("sccCode").Value);
                }
                if (fieldSettings.GetSection("override").Value != "SKIP")
                {
                    result.Replace(rxVaccineReq.Override, "EV" + fieldSettings.GetSection("override").Value);
                }
                if (fieldSettings.GetSection("ndc").Value != "SKIP")
                {
                    result.Replace(rxVaccineReq.NdcCode, "D7" + fieldSettings.GetSection("ndc").Value);
                }
                if (!(fieldSettings.GetSection("personCode").Value == "SKIP" || fieldSettings.GetSection("personCode").Value == "RANDOM"))
                {
                    result.Replace(rxVaccineReq.PersonCode, "C3" + fieldSettings.GetSection("personCode").Value);
                }
                else if (fieldSettings.GetSection("personCode").Value == "RANDOM")
                {
                    result.Replace(rxVaccineReq.PersonCode, "C3" + RetrieveRandomPersonCode());
                }

                //if (!(fieldSettings.GetSection("dos").Value == "SKIP" || fieldSettings.GetSection("dos").Value == "RANDOM"))
                //{
                //    // find increment or decrement
                //    var _change = FindDateByChange(rxVaccineReq.DateOfService, fieldSettings.GetSection("dos").Value);
                //    result.Replace(rxVaccineReq.DateOfService, "D1" + _change);
                //}
                //else if (fieldSettings.GetSection("dos").Value == "RANDOM")
                //{
                //    result.Replace(rxVaccineReq.DateOfService, "D1" + RetrieveRandomDate(fieldSettings.GetSection("DosMin").Value, fieldSettings.GetSection("DosMax").Value, "service"));
                //}

                if (!(fieldSettings.GetSection("dob").Value == "SKIP" || fieldSettings.GetSection("dob").Value == "RANDOM"))
                {
                    // find increment or decrement
                    var _change = FindDateByChange(rxVaccineReq.DateOfBirth, fieldSettings.GetSection("dob").Value);
                    result.Replace(rxVaccineReq.DateOfBirth, "C4" + _change);
                }
                else if (fieldSettings.GetSection("dob").Value == "RANDOM")
                {
                    result.Replace(rxVaccineReq.DateOfBirth, "C4" + RetrieveRandomDate(fieldSettings.GetSection("DobMin").Value, fieldSettings.GetSection("DobMax").Value, "birth"));
                }


                if (!(fieldSettings.GetSection("zipcode").Value == "SKIP" || fieldSettings.GetSection("zipcode").Value == "RANDOM"))
                {
                    result.Replace(rxVaccineReq.ZipCode, "CP" + fieldSettings.GetSection("zipcode").Value);
                }
                else if (fieldSettings.GetSection("zipcode").Value == "RANDOM")
                {
                    result.Replace(rxVaccineReq.ZipCode, "CP" + RetrieveRandomZipCode());
                }


                var adjustedLength = FindRequestLength(result.ToString());
                result.Replace(requestLength, adjustedLength);
                return result.ToString();
            }


        }



        #endregion
    }
}

