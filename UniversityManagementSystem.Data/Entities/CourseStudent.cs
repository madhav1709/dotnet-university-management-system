namespace UniversityManagementSystem.Data.Entities
{
    public class CourseStudent
    {
        public string StudentId { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}