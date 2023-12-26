using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODEx.Model
{
    public class Coordinator
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Designation { get; set; }

        [Required]
        public string? Batch { get; set; }

        public string? ImageUrl {  get; set; }

        public string? LinkedIn { get; set; }
        public string? Instagram { get; set; }
        public string? Facebook { get; set; }
        public string? Github { get; set; }

        [Required]
        public string? Description { get; set; }

    }
}
