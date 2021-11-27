using System.ComponentModel.DataAnnotations;

namespace ConvertMetric.Web.Models
{
    public class Temparature
    {
   
        public int Id { get; set; }
      
        public string? Unit { get; set; }
  
        public int FormulaId { get; set; }
        public Formula? Formula { get; set; }
    }
}
