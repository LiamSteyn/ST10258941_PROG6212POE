namespace ST10258941_PROG6212POE.Pages
{
        public class ClaimViewModel
        {
            public int LecturerId { get; set; }

            public int HoursWorked { get; set; }

            public decimal HourlyRate { get; set; }

            public string SupportingDocumentPath { get; set; } // Path where the document will be saved

            public IFormFile SupportingDocument { get; set; } // To handle file upload in the form
        }
}