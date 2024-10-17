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

        public void OnGet()
        {
            // Initialization logic if needed
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Set a placeholder for SupportingDocumentPath before validation
            if (ClaimViewModel.SupportingDocumentPath == null)
            {
                ClaimViewModel.SupportingDocumentPath = "Coming Soon";
            }

            // Validate the model state
            if (!ModelState.IsValid)
            {
                // Log validation errors to help troubleshoot
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Validation error: {error.ErrorMessage}");
                }
                Console.WriteLine("Model is invalid.");
                return Page();
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