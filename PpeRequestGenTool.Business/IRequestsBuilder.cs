using System.Collections.Generic;
using PpeRequestGenTool.Data.Model;
using PpeRequestGenTool.DataAccess;

namespace PpeRequestGenTool.Business
{
    public interface IRequestsBuilder
    {
        IEnumerable<string> CreateRecords(string requestStr);
        string AddRecordsToBatch(IEnumerable<string> list);
        void UpdateRecordsInBatch(string batchPath);
        void PeekAtBatch(string batchPath);
        string AddBatchToCollection(string batchFilePath);
        void RemoveBatchFromCollection(string batchNumber);
        void PeekAtCollection();
        void CreateFinalOutput();
        string CreateRecordsByTemplate(string templateBatchId);
    }
}