using System.Collections.Generic;

namespace UniversityManagementSystem.Data.Entities
{
    public class Course : EntityBase
    {
        public string Name { get; set; }

        public int SchoolId { get; set; }
        public School School { get; set; }

        public ICollection<CourseModule> CourseModules { get; set; }

        public ICollection<CourseStudent> CourseStudents { get; set; }

        public ICollection<Graduation> Graduations { get; set; }
    }
}