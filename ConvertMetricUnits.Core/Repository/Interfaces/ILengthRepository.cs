namespace ConvertMetricUnits.Core.Repository.Interfaces
{
    public interface ILengthRepository
    {
        double ConvertLength(string from, string to, int amount);
    }
}
