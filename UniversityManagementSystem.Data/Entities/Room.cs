using System.Collections.Generic;

namespace UniversityManagementSystem.Data.Entities
{
    public class Room : EntityBase
    {
        public string Name { get; set; }

        public int BuildingId { get; set; }
        public Building Building { get; set; }

        public ICollection<Lecture> Lectures { get; set; }
    }
}