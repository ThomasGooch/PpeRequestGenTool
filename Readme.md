PpeRequestGenTool

built in .Net 3.1 

projects:
business
data
dataAccess
presentation

testing:
tests
integrationTests

set startup project as presentation.


This is a simple Test File generator for use by QA. It creates and modifies BATCHES, which are aggregated into a COLLECTION, and finally
the COLLECTION evolves into the Final Test File. All of this is based on configurable settings within 'appsettings.json'.

BATCHES may be created as new or from a template. BATCHES may be updated and deleted.Batches may be peeked into for brief overview. 
BATCHES may be pushed and removed from COLLECTION.

COLLECTION may be peeked into for a brief overview. COLLECTION may invoke Final Test File creation.


**NOTES**
One BATCH can only be modified during program execution.
Many BATCHES can be pushed to COLLECTION.
Many BATCHES can be removed from COLLECTION.
There can only be 1 COLLECTION.
There can only be 1 Final Test File.
COLLECTION can only be deleted from local machine manually.
Final Test File can only be viewed/deleted from local machine manually.

























































############################################################################
//Console.WriteLine("Is this Cristian? T/F");
            //string cristain = Console.ReadLine().ToLower();
            //if (cristain == "t")
            //{
            //Console.WriteLine("INTRODUCTION");
            //Console.WriteLine("welcome to the PPE Request Generator APP: ");
            //Console.WriteLine("This app currently generates a text file containing PPE request on each line.");
            //Console.WriteLine("This app currently generates values for 402-D2 (max length = 12)");
            //Console.WriteLine("This app asks for the path for file creation and appendment.");
            //Console.WriteLine("This app asks for the sequence");
            //Console.WriteLine("This app, lastly, ask for # of records needed (1 to 99,999,999)");
            //Console.WriteLine("BEGINNING APP");



            //string ppeRequest = "BOWT2200929111YJ0259852852D0B185285285281011234561123     20200826          AM04C2987654321C1GRP852852C60AM01C420080101C50CAFIRSTPMBVICBLASTPMBVIAM07EM1D2789654000000E103D719515081641E70D30D50D60D80DE20200826DF0AM03EZ12DB0AM11D9{DC{DQ{DU{DN00D0B11A010000000000     20080101AM21ANPF3AUTHNUMUF1UH01FQMESSAGEAM22EM1D20AM23F5{F6{F7{F9{FM0FI{";
            //Console.WriteLine("Paste D2 String: (D2789654000000)");



//else
        //{
        //    string[] ppeRequests = new string[4];
        //    ppeRequests[0] = "BOWT2200924T76T10241123123D0B1123123    1012579257925     20200924          AM04C2987654321C1123123C60AM01C420080101C50CAFIRSTCBLASTAM07EM1D21234110E103D774747474747E70D30D50D60D80DE20200826DF0AM03EZ12DB0AM11D9{DC{DQ{DU{DN00D0B11A010000000000     20080101AM21ANPF3AUTHNUMUF1UH01FQMESSAGEAM22EM1D20AM23F5{F6{F7{F9{FM0FI{";
        //    ppeRequests[1] = "BOWT2200924T76TB0241123123D0B1123123    1012579257925     20200924          AM04C2987654321C1123123C60AM01C420080101C50CAFIRSTCBLASTAM07EM1D21234110E103D774747474747E70D30D50D60D80DE20200826DF0AM03EZ12DB0AM11D9{DC{DQ{DU{DN00";
        //    ppeRequests[2] = "BOWT2200924T76TD0255123123D0B1123123    1012579257925     20200924          AM04C2987654321C1123123C60AM01C420080101C50CAFIRSTCBLASTAM07EM1D21234110E103D774747474747E70D30D50D60D80DE20200826DF0EV02600692959AM03EZ12DB0AM11D9{DC{DQ{DU{DN00D0B11A010000000000     20080101AM21ANPF3AUTHNUMUF1UH01FQMESSAGEAM22EM1D20AM23F5{F6{F7{F9{FM0FI{";
        //    ppeRequests[3] = "BOWT2200924T76TE0242123123D0B1123123    1012579257925     20200924          AM04C2987654321C1123123C60AM01C420080101C50CAFIRSTCBLASTAM07EM1D21234110E103D774747474747E70D30D50D60D80DE20200826DF0AM03EZ12DB0AM11D9{DC{DQ{DU{DN00D0B11A010000000000     20080101AM21ANRF3AUTHNUMUF1UH01FQMESSAGEAM22EM1D20AM23F5{F6{F7{F9{FM0FI{";


        //    System.IO.StreamWriter ppereqscenario = new System.IO.StreamWriter("C:\\Users\\e7897bt\\Documents\\requestGenTest_lg.txt", false);
        //    int start = 1234110; // 1234111, 1234112, ...
        //    for (int i = 0; i < 4; i++)
        //    {

        //        for (long k = 1; k <= 1000000; k++)
        //        {
        //            string newValue = "D2" + (start + k).ToString();
        //            string temp = ppeRequests[i];
        //            string sending = temp.Replace("D21234110", newValue);
        //            ppereqscenario.WriteLine(sending);
        //        }

        //    }

        //    ppereqscenario.Close();


        //}