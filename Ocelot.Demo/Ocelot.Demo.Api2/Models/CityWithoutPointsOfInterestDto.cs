namespace Ocelot.Demo.Api2.Models
{
    /// <summary>
    /// A DTO for a city without point of interest
    /// </summary>
    public class CityWithoutPointsOfInterestDto
    {
        /// <summary>
        /// Id of the city
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name of the city
        /// </summary>
        public string? Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
