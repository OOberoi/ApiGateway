using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ocelot.Demo.Api2.Entities
{
    /// <summary>
    /// A class that represents a city object
    /// </summary>
    public class City
    {
        /// <summary>
        /// Id of the City
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]               
        public int Id { get; set; }

        /// <summary>
        /// City Name
        /// </summary>
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        /// <summary>
        /// Decription of City
        /// </summary>
        [MaxLength(250)]
        public string? Description { get; set; }

        /// <summary>
        /// A collection of Point of Interests
        /// </summary>
        public ICollection<PointOfInterest> PointsOfInterest { get; set; } = new List<PointOfInterest>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        public City(string name)
        {
            Name = name;
        }
    }
}
