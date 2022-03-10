using System.ComponentModel.DataAnnotations;

namespace Ocelot.Demo.Api2.Models
{
    public class PointOfInterestForCreationDto
    {
        [Required ]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }


    }
}
