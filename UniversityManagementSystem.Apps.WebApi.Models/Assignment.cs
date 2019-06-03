using System;
using System.ComponentModel.DataAnnotations;

namespace UniversityManagementSystem.Apps.WebApi.Models
{
    public class Assignment
    {
        public int Id { get; set; }

        [Required] public string Title { get; set; }

        [Required] public string Details { get; set; }

        [Required] public DateTimeOffset Deadline { get; set; }

        [Required] public Run Run { get; set; }
    }
}