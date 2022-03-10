﻿using System.ComponentModel.DataAnnotations;

namespace Ocelot.Demo.Api2.Models
{
    public class PointOfInterestForCreationDto
    {
        [Required(ErrorMessage = "Name is missing!") ]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(250)]
        public string? Description { get; set; }


    }
}
