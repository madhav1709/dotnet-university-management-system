using System.Collections.Generic;

namespace UniversityManagementSystem.Data.Entities
{
    public class Campus : EntityBase
    {
        public string Name { get; set; }

        public ICollection<Building> Buildings { get; set; }

        public ICollection<School> Schools { get; set; }
    }
}