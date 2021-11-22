namespace ConvertMetricUnits.Core.Repository.Interfaces
{
    public interface ITemparatureRepository
    {
        double ConvertTemparature(string from, string to, int amount);
    }
}
