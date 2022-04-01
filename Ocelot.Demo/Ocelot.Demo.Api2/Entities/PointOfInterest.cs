
using System.ComponentModel.DataAnnotations;

namespace Ocelot.Demo.Api2.Entities
{
    public class PointOfInterest
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
