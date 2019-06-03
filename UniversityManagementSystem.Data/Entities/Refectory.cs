namespace UniversityManagementSystem.Data.Entities
{
    public class Refectory : EntityBase
    {
        public string Name { get; set; }

        public int BuildingId { get; set; }
        public Building Building { get; set; }
    }
}