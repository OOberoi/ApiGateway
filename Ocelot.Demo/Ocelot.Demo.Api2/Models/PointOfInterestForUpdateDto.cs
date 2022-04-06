using System.ComponentModel.DataAnnotations;

namespace Ocelot.Demo.Api2.Models
{
    public class PointOfInterestForUpdateDto
    {
        [Required(ErrorMessage = "Name should be provided!")]
        [MaxLength(50)]
        public string? Name { get; set; }

        [MaxLength(250)]
        public string? Description { get; set; }
    }
}
