namespace ST10258941_PROG6212POE.Pages
{
    public class ManageClaimViewModel
    {
        public int ClaimId { get; set; }
        public int LecturerId { get; set; }
        public int HoursWorked { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } // Pending, Approved, Rejected
        public string Comments { get; set; } // Optional comments from the approver

        public string AdditionalNotes { get; set; }

        public string SupportingDocumentPath { get; set; }
    }
}