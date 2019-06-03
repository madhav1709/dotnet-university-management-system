using System.Collections.Generic;

namespace UniversityManagementSystem.Data.Entities
{
    public class Building : EntityBase
    {
        public string Name { get; set; }

        public int CampusId { get; set; }
        public Campus Campus { get; set; }

        public ICollection<Library> Libraries { get; set; }

        public ICollection<Refectory> Refectories { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
}