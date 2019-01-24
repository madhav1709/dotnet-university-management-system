namespace UniversityManagementSystem.Core.Data.Entities
{
    public class Enrolment : EntityBase
    {
        public int Year { get; set; }

        public string StudentId { get; set; }

        public int RunId { get; set; }
        public Run Run { get; set; }
    }
}