namespace Ocelot.Demo.Api2.Models
{
    /// <summary>
    /// A DTO for a city without point of interest
    /// </summary>
    public class CityWithoutPointsOfInterestDto
    {
        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
