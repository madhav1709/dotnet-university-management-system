using System;
using System.ComponentModel.DataAnnotations;

namespace UniversityManagementSystem.Core.WebApi.ViewModels
{
    public class AssignmentViewModel
    {
        public int Id { get; set; }

        [Required] public string Title { get; set; }

        [Required] public string Details { get; set; }

        [Required] public DateTimeOffset Deadline { get; set; }

        [Required] public RunViewModel Run { get; set; }
    }
}