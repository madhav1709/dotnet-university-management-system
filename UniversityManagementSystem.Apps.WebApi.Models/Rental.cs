using System;
using System.ComponentModel.DataAnnotations;

namespace UniversityManagementSystem.Apps.WebApi.Models
{
    public class Rental
    {
        public int Id { get; set; }

        [Required] public DateTimeOffset CheckoutDate { get; set; }

        [Required] public DateTimeOffset ReturnDate { get; set; }

        [Required] public string StudentId { get; set; }

        [Required] public Book Book { get; set; }
    }
}