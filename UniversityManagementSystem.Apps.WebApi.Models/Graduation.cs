using System;
using System.ComponentModel.DataAnnotations;

namespace UniversityManagementSystem.Apps.WebApi.Models
{
    public class Graduation
    {
        public Graduation()
        {
            Year = DateTimeOffset.Now.Year;
        }

        public int Id { get; set; }

        [Required] public int Year { get; set; }

        [Required] public string StudentId { get; set; }

        [Required] public Course Course { get; set; }
    }
}