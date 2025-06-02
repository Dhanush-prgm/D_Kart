using System;
using System.ComponentModel.DataAnnotations;

namespace D_Kart.Domain.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Feedback is required.")]
        [StringLength(500, ErrorMessage = "Feedback cannot exceed 500 characters.")]
        public string Feedback { get; set; }

        public DateTime DateSubmitted { get; set; }
    }
}