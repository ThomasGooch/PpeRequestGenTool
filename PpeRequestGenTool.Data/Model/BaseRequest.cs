using System;
using System.Collections.Generic;
using System.Text;

namespace PpeRequestGenTool.Data.Model
{
    public abstract class BaseRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RxNumber { get; set; }
        public string CardholderId { get; set; }
        public string PersonCode { get; set; }
        public string SccCode { get; set; }
        public string DateOfBirth { get; set; }
        public string ZipCode { get; set; }
        public string NdcCode { get; set; }
    }
}
