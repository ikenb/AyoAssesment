namespace ConvertMetricUnits.Core.Repository.Interfaces
{
    public interface ILengthRepository
    {
        double ConvertLengthAsync(string from, string to, double amount);
    }
}
