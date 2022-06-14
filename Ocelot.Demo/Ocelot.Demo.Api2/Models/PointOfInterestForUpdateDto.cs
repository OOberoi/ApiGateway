using System.ComponentModel.DataAnnotations;

namespace Ocelot.Demo.Api2.Models
{
    /// <summary>
    /// DTO to update point of interest
    /// </summary>
    public class PointOfInterestForUpdateDto
    {
        /// <summary>
        /// Name of point of interest
        /// </summary>
        [Required(ErrorMessage = "Name should be provided!")]
        [MaxLength(50)]
        public string? Name { get; set; }

        [MaxLength(250)]
        public string? Description { get; set; }
    }
}
