namespace Ocelot.Demo.Api2.Models
{
    /// <summary>
    /// DTO for point of interest
    /// </summary>
    public class PointOfInterestDto
    {
        /// <summary>
        /// Id for POI
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name for POI
        /// </summary>
        public string? Name { get; set; }
        public string? Description { get; set; }        
    }
}
