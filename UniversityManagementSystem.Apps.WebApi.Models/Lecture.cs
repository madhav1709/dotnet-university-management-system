using System;
using System.ComponentModel.DataAnnotations;

namespace UniversityManagementSystem.Apps.WebApi.Models
{
    public class Lecture
    {
        public int Id { get; set; }

        [Required] public DateTimeOffset DateTime { get; set; }

        [Required] public TimeSpan Duration { get; set; }

        [Required] public Run Run { get; set; }

        [Required] public Room Room { get; set; }
    }
}