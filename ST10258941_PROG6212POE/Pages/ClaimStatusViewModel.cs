namespace ST10258941_PROG6212POE.Pages
{
    public class ClaimStatusViewModel
    {
        /// <summary>
        /// Gets or sets the unique identifier for the claim.
        /// </summary>
        public int ClaimId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the lecturer associated with the claim.
        /// </summary>
        public int LecturerId { get; set; }

        /// <summary>
        /// Gets or sets the number of hours worked that the claim is based on.
        /// </summary>
        public int HoursWorked { get; set; }

        /// <summary>
        /// Gets or sets the rate per hour for the work done.
        /// </summary>
        public decimal HourlyRate { get; set; }

        /// <summary>
        /// Gets or sets the total amount calculated based on HoursWorked and HourlyRate.
        /// This value might be computed from HoursWorked and HourlyRate.
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the status of the claim. Possible values include:
        /// Pending - The claim is under review.
        /// Approved - The claim has been approved.
        /// Rejected - The claim has been rejected.
        /// </summary>
        public string Status { get; set; } // Pending, Approved, Rejected

        /// <summary>
        /// Gets or sets any optional comments from the approver regarding the claim.
        /// This can include reasons for approval or rejection, or other relevant notes.
        /// </summary>
        public string Comments { get; set; } // Optional comments from the approver
    }
}
