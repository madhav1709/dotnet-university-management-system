using System.Collections.Generic;

namespace UniversityManagementSystem.Data.Entities
{
    public class Hall : EntityBase
    {
        public string Name { get; set; }

        public int CampusId { get; set; }
        public Campus Campus { get; set; }

        public ICollection<HallStudent> HallStudents { get; set; }
    }
}