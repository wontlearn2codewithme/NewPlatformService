using System.ComponentModel.DataAnnotations;

namespace CommandsService.Models
{
    public class Command
    {
        [Key]
        public required int Id { get; set; }
        [Required]
        public required string HowTo { get; set; } = string.Empty;
        [Required]
        public required string CommandLine { get; set; } = string.Empty;
        [Required]
        public required int PlatformId { get; set; }
        public virtual required Platform Platform { get; set; }
    }
}
