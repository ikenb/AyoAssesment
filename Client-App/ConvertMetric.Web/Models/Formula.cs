using System.ComponentModel.DataAnnotations;

namespace ConvertMetric.Web.Models
{
    public class Formula
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Syntax { get; set; }
    }
}
