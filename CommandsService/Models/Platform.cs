using System.ComponentModel.DataAnnotations;

namespace CommandsService.Models
{
    public class Platform
    {
        [Key]
        [Required]
        public required int Id { get; set; }
        [Required]
        public required string Name { get; set; } = string.Empty;
        [Required]
        public required int ExternalID { get; set; }
        public virtual ICollection<Command> Commands { get; set; } = new List<Command>();
    }
}
