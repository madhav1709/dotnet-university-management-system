namespace UniversityManagementSystem.Data.Entities
{
    public class Enrolment : EntityBase
    {
        public int Year { get; set; }

        public string StudentId { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}