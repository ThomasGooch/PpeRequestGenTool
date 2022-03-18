using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PpeRequestGenTool.Data.Model
{
    public class SmartHopRequest : BaseRequest
    {

       


        public SmartHopRequest ParseRequestString(string request)
        {
            var requestStrSplit = request.Split(new char[] { (char)30, (char)29, (char)28 }, StringSplitOptions.None);
            var result = new SmartHopRequest
            {
                RxNumber = requestStrSplit.FirstOrDefault(c => c.StartsWith("D2")),
                CardholderId = requestStrSplit.FirstOrDefault(c => c.StartsWith("C2")),
                PersonCode = requestStrSplit.FirstOrDefault(c => c.StartsWith("C3")),
                SccCode = requestStrSplit.FirstOrDefault(c => c.StartsWith("DK")),
                FirstName = requestStrSplit.FirstOrDefault(c => c.StartsWith("CA")),
                LastName = requestStrSplit.FirstOrDefault(c => c.StartsWith("CB")),
                DateOfBirth = requestStrSplit.FirstOrDefault(c => c.StartsWith("C4")),
                ZipCode = requestStrSplit.FirstOrDefault(c => c.StartsWith("CP")),
                NdcCode = requestStrSplit.FirstOrDefault(c => c.StartsWith("D7"))
            };
            return result;
        }
    }
}
