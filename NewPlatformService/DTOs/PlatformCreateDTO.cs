using System;
using System.ComponentModel.DataAnnotations;

namespace NewPlatformService.DTOs
{
    public class PlatformCreateDTO
    {
        public PlatformCreateDTO(string name, string publisher, string cost)
        {
            Name = name;
            Publisher = publisher;
            Cost = cost;
        }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        public string Cost { get; set; }
    }
}

