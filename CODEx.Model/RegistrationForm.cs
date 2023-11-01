using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [DisplayName("Leader Name")]
        public string? TeamLeaderName { get; set; }

        [DisplayName("Leader Phone Number")]
        public string? LeaderNumber  { get; set; }

        [DisplayName("Leader EmailID")]
        public string? LeaderEmail { get; set; }

        [DisplayName("Member 2 Name")]
        public string? Member2Name { get; set; }

        [DisplayName("Member 2 Number")]
        public string? Member2Number { get; set; }

        [DisplayName("Member 3 Name")]
        public string? Member3Name { get; set; }

        [DisplayName("Member 3 Number")]
        public string? Member3Number { get; set; }

        [DisplayName("Member 4 Name")]
        public string? Member4Name { get;set; }

        [DisplayName("Member 4 Number")]
        public string? Member4Number { get;set; }

        public string? Theme { get; set; }

        public string? Category { get; set; }

        [DisplayName("Problem Statement")]
        public string? ProblemStatment { get; set; }
    }
}
