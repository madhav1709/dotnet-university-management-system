namespace UniversityManagementSystem.Core.Data.Entities
{
    public class Result : EntityBase
    {
        public int Grade { get; set; }

        public string Feedback { get; set; }

        public string StudentId { get; set; }

        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; }
    }
}