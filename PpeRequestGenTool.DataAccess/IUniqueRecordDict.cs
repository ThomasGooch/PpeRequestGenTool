using System.Collections.Generic;

namespace PpeRequestGenTool.DataAccess
{
    public interface IUniqueRecordDict
    {
        void PushToUniqueRecordDict(Dictionary<string,string> record);
        Dictionary<string, string> ReadUniqueRecordDict();
    }
}