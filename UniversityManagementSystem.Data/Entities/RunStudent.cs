namespace UniversityManagementSystem.Data.Entities
{
    public class RunStudent
    {
        public string StudentId { get; set; }

        public int RunId { get; set; }
        public Run Run { get; set; }
    }
}