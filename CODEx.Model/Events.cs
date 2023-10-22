using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODEx.Model
{
    public class Events
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }

        public DateOnly Date { get; set; }

        public string? PosterUrl { get; set; }

        [Required]
        public int TotalParticipant {  get; set; }
    }
}
