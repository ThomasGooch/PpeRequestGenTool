using PpeRequestGenTool.DataAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace PpeRequestGenTool.IntegrationTests
{
    public class BatchCollectionFileBuilderIntegrationTests
    {

        [Fact]
        public void Build_batch_collection_file_with_content()
        {
            //arrange
            var batchNumber = "0001";
            var batchPath = $"c://tests//test";
            var batchFile = new BatchFileBuilder(batchPath, batchNumber);
            var _sut = new BatchCollectionFileBuilder(batchPath);
            //act
            _sut.WriteToBatchCollection(batchFile.BatchPath);
            //assert
            Assert.True(File.ReadAllLines(_sut.BatchCollectionPath)[0] == batchNumber);
            File.Delete(_sut.BatchCollectionPath);
            File.Delete(batchFile.BatchPath);
        }

        [Fact]
        public void Remove_batch_from_batch_collection_file()
        {
            //arrange
            var batchNumber = "6001";
            var batchPath = $"c://tests//test";
            var batchFile = new BatchFileBuilder(batchPath, batchNumber);
            var listOfText = new List<string>() { "foo", "bar" };
            batchFile.WriteToBatch(listOfText);

            var batchNumber2 = "0002";
            var batchPath2 = $"c://tests//test";
            var batchFile2 = new BatchFileBuilder(batchPath2, batchNumber2);
            var listOfText2 = new List<string>() { "tommy", "betty" };
            batchFile.WriteToBatch(listOfText);
            batchFile2.WriteToBatch(listOfText2);

            var _sut = new BatchCollectionFileBuilder(batchPath);
            _sut.WriteToBatchCollection(batchFile.BatchPath);
            _sut.WriteToBatchCollection(batchFile2.BatchPath);

            //act
            _sut.RemoveBatchByBatchNumber(batchFile.BatchNum);

            //assert
            Assert.False(File.ReadAllLines(_sut.BatchCollectionPath)[0] == batchNumber);
            File.Delete(_sut.BatchCollectionPath);
            File.Delete(batchFile.BatchPath);
            File.Delete(batchFile2.BatchPath);
        }

        [Fact]
        public void Build_final_output_file()
        {
            //arrange
            var batchNumber = "0001";
            var batchPath = $"c://tests//test";
            var batchFile = new BatchFileBuilder(batchPath, batchNumber);
            var listOfText = new List<string>() { "foo", "bar" };
            

            var batchNumber2 = "0002";
            var batchPath2 = $"c://tests//test";
            var batchFile2 = new BatchFileBuilder(batchPath2, batchNumber2);
            var listOfText2 = new List<string>() { "tommy", "betty" };
            batchFile.WriteToBatch(listOfText);
            batchFile2.WriteToBatch(listOfText2);

            var _sut = new BatchCollectionFileBuilder(batchPath);
            _sut.WriteToBatchCollection(batchFile.BatchPath);
            _sut.WriteToBatchCollection(batchFile2.BatchPath);
           
            //act
            _sut.CreateFinalOutputFile();
            //assert
            Assert.True(File.Exists(batchPath+"_output.txt"));
            File.Delete(batchPath + "_output.txt");
            File.Delete(_sut.BatchCollectionPath);
            File.Delete(batchFile.BatchPath);
            File.Delete(batchFile2.BatchPath);
        }
    }
}
