using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ST10258941_PROG6212POE.Pages

{
    public class ClaimViewModel
    {
        public int ClaimId { get; set; }

        [Required(ErrorMessage = "Lecturer ID is required")]
        public int LecturerId { get; set; }

        [Required(ErrorMessage = "Hours worked is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Hours worked must be greater than 0")]
        public int HoursWorked { get; set; }

        [Required(ErrorMessage = "Hourly rate is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Hourly rate must be greater than 0")]
        public decimal HourlyRate { get; set; }

        // No longer required
        public IFormFile? SupportingDocument { get; set; }

        // Optional path field, no validation required
        public string? SupportingDocumentPath { get; set; }

        public string? Status { get; set; } // Current status of the claim (e.g., Pending, Approved, Rejected)
        public string? Comments { get; set; } // Any comments related to the claim
    }
}