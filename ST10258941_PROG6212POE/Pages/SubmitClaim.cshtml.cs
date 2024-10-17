using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;

namespace ST10258941_PROG6212POE.Pages
{
    public class SubmitClaimModel : PageModel
    {
        [BindProperty]
        public ClaimViewModel ClaimViewModel { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet()
        {
            // Initialization logic if needed
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Set a placeholder for SupportingDocumentPath before validation
            if (ClaimViewModel.SupportingDocumentPath == null)
            {
                ClaimViewModel.SupportingDocumentPath = "Error";
            }

            // Validate the model state
            if (!ModelState.IsValid)
            {
                // Log validation errors to help troubleshoot
                ErrorMessage = "Ensure no negative numbers have been entered.";
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Validation error: {error.ErrorMessage}");
                }
                Console.WriteLine("Model is invalid.");
                return Page();
            }

            // Maximum file size limit (5 MB)
            const long maxFileSize = 5 * 1024 * 1024; // 5 MB in bytes

            // Allowed file extensions
            var allowedExtensions = new[] { ".pdf", ".docx" };

            // Process file upload
            if (ClaimViewModel.SupportingDocument != null && ClaimViewModel.SupportingDocument.Length > 0)
            {
                // Check file size
                if (ClaimViewModel.SupportingDocument.Length > maxFileSize)
                {
                    ModelState.AddModelError("SupportingDocument", "The file size must be less than 5 MB.");
                    Console.WriteLine("Validation error: The file size exceeds the 5 MB limit.");
                    ErrorMessage = "File size must be less than 5 MB.";
                    return Page(); // Return to the page to display validation error
                }

                var fileExtension = Path.GetExtension(ClaimViewModel.SupportingDocument.FileName).ToLowerInvariant();
                if (!allowedExtensions.Contains(fileExtension))
                {
                    ModelState.AddModelError("SupportingDocument", "Only PDF and DOCX files are allowed.");
                    Console.WriteLine("Validation error: Invalid file type. Only PDF and DOCX files are allowed.");
                    ErrorMessage = "Only PDF and DOCX files are allowed.";
                    return Page(); // Return to the page to display validation error
                }

                var filePath = Path.Combine("wwwroot/uploads", ClaimViewModel.SupportingDocument.FileName);

                // Ensure the uploads directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ClaimViewModel.SupportingDocument.CopyToAsync(stream);
                }
                ClaimViewModel.SupportingDocumentPath = $"/uploads/{ClaimViewModel.SupportingDocument.FileName}"; // Store relative path
            }
            else
            {
                ClaimViewModel.SupportingDocumentPath = "Error"; // Placeholder for the path
            }



            // Log the submitted data to the console for debugging
            Console.WriteLine($"Submitted Data: LecturerId: {ClaimViewModel.LecturerId}, HoursWorked: {ClaimViewModel.HoursWorked}, HourlyRate: {ClaimViewModel.HourlyRate}, SupportingDocumentPath: {ClaimViewModel.SupportingDocumentPath}");

            // Add the claim to the in-memory storage
            ClaimStorage.AddClaim(ClaimViewModel);

            // Log success message
            Console.WriteLine("Claim successfully added.");

            // Redirect to the confirmation or summary page (e.g., Index page)
            return RedirectToPage("/Index");
        }
    }
}