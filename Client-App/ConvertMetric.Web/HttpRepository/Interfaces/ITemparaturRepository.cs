namespace ConvertMetric.Web.HttpRepository.Interfaces
{
    public interface ITemparatureRepository
    {
        double ConvertWeight(string from, string to, int amount);
    }
}
