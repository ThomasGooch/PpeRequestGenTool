using System.Collections.Generic;
using PpeRequestGenTool.DataAccess;
using System.IO;
using System.Linq;
using Xunit;

namespace PpeRequestGenTool.IntegrationTests
{

    public class BatchFileBuilderTests 
    {

        [Fact]
        public void Build_batch_file_with_ID_first_line_success()
        {
            //arrange
            var batchNumber = "5001";
            var batchPath = $"c://tests//test";
            //act
            var _sut = new BatchFileBuilder(batchPath, batchNumber);
            //assert
            Assert.True(File.ReadAllLines(_sut.BatchPath)[0] == batchNumber);
            File.Delete(_sut.BatchPath);
        }

        [Fact]
        public void Build_batch_file_with_content_success()
        {
            //arrange
            var batchNumber = "9001";
            var batchPath = $"c://tests//test";
            var _sut = new BatchFileBuilder(batchPath, batchNumber);
            var listOfText = new List<string>() {"foo", "bar"};
            //act
            _sut.WriteToBatch(listOfText);
            //assert
            Assert.True(File.ReadAllLines(_sut.BatchPath).Length>2);
            File.Delete(_sut.BatchPath);
        }



    }
}
