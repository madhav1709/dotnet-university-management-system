using System.Collections.Generic;

namespace UniversityManagementSystem.Core.Data.Entities
{
    public class Course : EntityBase
    {
        public string Name { get; set; }

        public int CampusId { get; set; }
        public Campus Campus { get; set; }

        public ICollection<CourseModule> CourseModules { get; set; }

        public ICollection<CourseStudent> CourseStudents { get; set; }

        public ICollection<Graduation> Graduations { get; set; }
    }
}