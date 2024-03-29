﻿using System.ComponentModel.DataAnnotations;
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

        /// <summary>
        /// Name of City
        /// </summary>
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        /// <summary>
        /// CityId used as foreign key
        /// </summary>
        [ForeignKey("CityId")]
        public City? City { get; set; }

        /// <summary>
        /// City Id
        /// </summary>
        public int CityId { get; set; }

        /// <summary>
        /// Description of City
        /// </summary>
        [MaxLength(250)]
        public string? Description { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        public PointOfInterest(string name)
        {
            Name = name;
        }
    }
}
