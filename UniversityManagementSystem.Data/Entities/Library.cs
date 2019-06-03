using System.Collections.Generic;

namespace UniversityManagementSystem.Data.Entities
{
    public class Library : EntityBase
    {
        public string Name { get; set; }

        public int BuildingId { get; set; }
        public Building Building { get; set; }

        public ICollection<LibraryBook> LibraryBooks { get; set; }
    }
}