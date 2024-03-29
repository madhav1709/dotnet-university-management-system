using System;
using System.Collections.Generic;

namespace UniversityManagementSystem.Core.Data.Entities
{
    public class Assignment : EntityBase
    {
        public string Title { get; set; }

        public string Details { get; set; }

        public DateTimeOffset Deadline { get; set; }

        public int RunId { get; set; }
        public Run Run { get; set; }

        public ICollection<Result> Results { get; set; }
    }
}