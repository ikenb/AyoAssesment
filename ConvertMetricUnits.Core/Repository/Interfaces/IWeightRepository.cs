namespace ConvertMetricUnits.Core.Repository.Interfaces
{
    public interface IWeightRepository
    {
        double ConvertWeight(string from, string to, double amount);
    }
}
