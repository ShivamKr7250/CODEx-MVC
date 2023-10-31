using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODEx.Model
{
    public class RegistrationForm
    {
        [Key]
        public int Id { get; set; }

        public string? TeamName { get; set; }

        public string? College {  get; set; }

        public string? Department { get; set; }

        public string? TeamLeaderNanme { get; set; }

        public string? LeaderNumber  { get; set; }

        public string? LeaderEmail { get; set; }

        public string? Member2Name { get; set; }

        public string? Member2Number { get; set; }

        public string? Member3Name { get; set; }

        public string? Member3Number { get; set; }

        public string? Member4Name { get;set; }

        public string? Member4Number { get;set; }

        public string? Theme { get; set; }

        public string? Category { get; set; }

        public string? ProblemStatment { get; set; }
    }
}
