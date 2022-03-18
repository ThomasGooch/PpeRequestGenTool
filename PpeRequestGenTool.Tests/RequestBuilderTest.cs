using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PpeRequestGenTool.Data.Model;
using PpeRequestGenTool.Business;
using Xunit;

namespace PpeRequestGenTool.Tests
{

    public class RequestBuilderTests
    {


        [Fact]
        public void Collect_altered_strings()
        {
            //arrange
            var testStr = "226T2210407111ZG0352610014D0B1362001    1013366554477     20210203          AM04C2A1234567890C3001C1372001C60AM01C419681231C50CAFN1234567890CBLN1234567890CM401South Main StreetCNSmall TownCOGACP30024AM07EM1D2A6000000001E103D711877001126E70D30D50D60D80DE20210202DF0NX1DK2EUEVEX1234567890AM03EZ01DB2345678911AM11D9{DC{DQ{DU{DN00D0B11A012233445566     20210202AM21ANPF3AUTHNUMUF1UH01FQMESSAGEAM22EM1D21234567AM23F5{F6{F7{F9{FM0FI{";
            var request = new RxVaccineRequest();
            var _sut = new RequestsBuilder()
            {
                NumberOfRequest = 2
            };
            var parsedTestStr = request.ParseRequestString(testStr);
            //act
            var success = _sut.CreateRecords(testStr);
            //assert
            Assert.True(success.Count()>1);
        }

    }
}
