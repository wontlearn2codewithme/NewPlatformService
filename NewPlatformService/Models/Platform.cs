using System.ComponentModel.DataAnnotations;

namespace NewPlatformService.Models
{
    public class Platform
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; } = string.Empty;
        [Required]
        public required string Publisher { get; set; } = string.Empty;
        [Required]
        public required string Cost { get; set; } = string.Empty;
    }
}