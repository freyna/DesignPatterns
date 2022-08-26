using System.ComponentModel.DataAnnotations;

namespace DesignPatternASP.Models
{
    public class BeerViewModel
    {
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Style { get; set; }
        public string? BrandId { get; set; }
        public string? OtherBrand { get; set; }
    }
}
