namespace PpeRequestGenTool.Data.Model
{
    public interface IRxVaccineRequest
    {
        RxVaccineRequest ParseRequestString(string request);
    }
}