using System;
using System.Linq;

namespace PpeRequestGenTool.Data.Model
{


    public class RxVaccineRequest : BaseRequest
    {
        //public string DateOfService { get; set; }
        public string Override { get; set; }



        public RxVaccineRequest ParseRequestString(string request)
        {
            var requestStrSplit = request.Split(new char[] { (char)30, (char)29, (char)28 }, StringSplitOptions.None);
            var result = new RxVaccineRequest
            {
                RxNumber = requestStrSplit.FirstOrDefault(c => c.StartsWith("D2")),
                CardholderId = requestStrSplit.FirstOrDefault(c => c.StartsWith("C2")),
                PersonCode = requestStrSplit.FirstOrDefault(c => c.StartsWith("C3")),
                SccCode = requestStrSplit.FirstOrDefault(c => c.StartsWith("DK")),
                //DateOfService = requestStrSplit.FirstOrDefault(c => c.StartsWith("D1")),
                FirstName = requestStrSplit.FirstOrDefault(c => c.StartsWith("CA")),
                LastName = requestStrSplit.FirstOrDefault(c => c.StartsWith("CB")),
                DateOfBirth = requestStrSplit.FirstOrDefault(c => c.StartsWith("C4")),
                Override = requestStrSplit.FirstOrDefault(c => c.StartsWith("EV")),
                ZipCode = requestStrSplit.FirstOrDefault(c => c.StartsWith("CP")),
                NdcCode = requestStrSplit.FirstOrDefault(c => c.StartsWith("D7"))
            };
            return result;
        }

        
    }
}
