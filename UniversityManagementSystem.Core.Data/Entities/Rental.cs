using System;

namespace UniversityManagementSystem.Core.Data.Entities
{
    public class Rental : EntityBase
    {
        public DateTimeOffset CheckoutDate { get; set; }

        public DateTimeOffset ReturnDate { get; set; }

        public string StudentId { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}