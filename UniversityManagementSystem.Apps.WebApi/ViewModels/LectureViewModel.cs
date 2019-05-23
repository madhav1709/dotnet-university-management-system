using System;
using System.ComponentModel.DataAnnotations;

namespace UniversityManagementSystem.Apps.WebApi.ViewModels
{
    public class LectureViewModel
    {
        public int Id { get; set; }

        [Required] public DateTimeOffset DateTime { get; set; }

        [Required] public TimeSpan Duration { get; set; }

        [Required] public RunViewModel Run { get; set; }

        [Required] public RoomViewModel Room { get; set; }
    }
}