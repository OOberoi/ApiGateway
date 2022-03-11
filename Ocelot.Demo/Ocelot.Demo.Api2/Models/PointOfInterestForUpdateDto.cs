using System.ComponentModel.DataAnnotations;

namespace Ocelot.Demo.Api2.Models
{
    public class PointOfInterestForUpdateDto
    {
        public string Name { get; set; }

        public string? Description { get; set; }
    }
}
