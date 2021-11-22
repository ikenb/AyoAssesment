using System.ComponentModel.DataAnnotations;

namespace ConvertMetricUnits.Data.Models
{
    public class Weight
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Unit { get; set; }
        [Required]
        public int FormulaId { get; set; }
        public Formula? Formula { get; set; }
    }
}
