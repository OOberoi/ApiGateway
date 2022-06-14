using System.ComponentModel.DataAnnotations;

namespace Ocelot.Demo.Api2.Models
{
    /// <summary>
    /// DTO for point of interest
    /// </summary>
    public class PointOfInterestForCreationDto
    {
        /// <summary>
        /// Name of point of interest
        /// </summary>
        [Required(ErrorMessage = "Name is missing!") ] 
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(250)]
        public string? Description { get; set; }


    }
}
