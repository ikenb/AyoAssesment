namespace ConvertMetric.Web.HttpRepository.Interfaces
{
    public interface IWeightRepository
    {
        double ConvertWeight(string from, string to, int amount);
    }
}
