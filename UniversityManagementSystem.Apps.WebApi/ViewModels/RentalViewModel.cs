using System;
using System.ComponentModel.DataAnnotations;

namespace UniversityManagementSystem.Apps.WebApi.ViewModels
{
    public class RentalViewModel
    {
        public int Id { get; set; }

        [Required] public DateTimeOffset CheckoutDate { get; set; }

        [Required] public DateTimeOffset ReturnDate { get; set; }

        [Required] public string StudentId { get; set; }

        [Required] public BookViewModel Book { get; set; }
    }
}