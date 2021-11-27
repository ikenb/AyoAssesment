namespace LoggerService.Logger
{
    public class LogDetail
    {
        public DateTime Timestamp { get; set; }
        public string? Message { get; set; }  
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public string? MachineName { get; set; }
        public Exception? Exception { get; set; }  
    
    }
}
