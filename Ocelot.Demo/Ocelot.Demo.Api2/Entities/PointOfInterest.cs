using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ocelot.Demo.Api2.Entities
{
    /// <summary>
    /// An object that represents PointOfInterest
    /// </summary>
    public class PointOfInterest
    {
        /// <summary>
        /// Id for PointOfInterest
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        
        
        [ForeignKey("CityId")]

        
        public City? City { get; set; }

        /// <summary>
        /// CityId used as foreign key
        /// </summary>
        public int CityId { get; set; }

        [MaxLength(250)]
        public string? Description { get; set; }


        public PointOfInterest(string name)
        {
            Name = name;
        }
    }
}
