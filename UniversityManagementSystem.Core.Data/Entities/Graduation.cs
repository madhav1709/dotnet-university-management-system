namespace UniversityManagementSystem.Core.Data.Entities
{
    public class Graduation : EntityBase
    {
        public int Year { get; set; }

        public string StudentId { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}