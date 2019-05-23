namespace UniversityManagementSystem.Data.Entities
{
    public class HallStudent
    {
        public string StudentId { get; set; }

        public int HallId { get; set; }
        public Hall Hall { get; set; }
    }
}