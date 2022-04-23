namespace Ocelot.Demo.Api2.Models
{
    public class CityWithoutPointsOfInterestDto
    {
        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
