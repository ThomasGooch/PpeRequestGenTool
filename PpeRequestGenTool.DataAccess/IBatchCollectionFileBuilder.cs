namespace PpeRequestGenTool.DataAccess
{
    public interface IBatchCollectionFileBuilder
    {
        void WriteToBatchCollection(string batchFilePath);
        void RemoveBatchByBatchNumber(string batchNum);
        void CreateFinalOutputFile();
    }
}