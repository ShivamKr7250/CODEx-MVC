using System.ComponentModel.DataAnnotations;

namespace CODEx.Model
{
    public class Faculty
    {
        [Key]
        public int? Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Desigation { get; set; }
        [Required]
        public string? ImageUrl { get; set; }
    }
}
