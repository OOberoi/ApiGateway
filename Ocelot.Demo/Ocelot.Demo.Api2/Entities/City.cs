//using Ocelot.Demo.Api2.Models;

namespace Ocelot.Demo.Api2.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public ICollection<PointOfInterest> PointsOfInterest { get; set; } = new List<PointOfInterest>();
    }
}
