using System;

namespace UniversityManagementSystem.Data.Entities
{
    public class Lecture : EntityBase
    {
        public DateTimeOffset DateTime { get; set; }

        public TimeSpan Duration { get; set; }

        public int RunId { get; set; }
        public Run Run { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}