namespace ConvertMetric.Web
{
    public static class Connector
    {
        public static string APIBaseUrl = "https://localhost:7025/";
        public static string LengthAPIPath = APIBaseUrl + "api/v1/Length/";
        public static string TemparatureAPIPath = APIBaseUrl + "api/v1/Temparature/";
        public static string WeightAPIPath = APIBaseUrl + "api/v1/Weight/";
        public static string AccountAPIPath = APIBaseUrl + "api/v1/Users/";
    }
}
