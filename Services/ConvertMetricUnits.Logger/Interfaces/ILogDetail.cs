using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerService.Interfaces
{
    public interface ILogDetail
    {
        public DateTime Timestamp { get; set; }
        public string Message { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string MachineName { get; set; }
        public Exception Exception { get; set; }
    }
}
