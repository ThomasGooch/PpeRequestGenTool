using System.Collections.Generic;

namespace PpeRequestGenTool.DataAccess
{
    public interface IBatchFileBuilder
    {
        bool CreateFile(string batchPath);
        void WriteToBatch(IEnumerable<string> list);
    }
}