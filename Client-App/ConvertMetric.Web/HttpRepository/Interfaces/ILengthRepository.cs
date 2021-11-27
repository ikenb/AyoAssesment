namespace ConvertMetric.Web.HttpRepository.Interfaces
{
    public interface ILengthRepository
    {
        double ConvertWeight(string from, string to, int amount);
    }
}
