using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Process file upload
            if (ClaimViewModel.SupportingDocument != null)
            {
                var filePath = Path.Combine("wwwroot/uploads", ClaimViewModel.SupportingDocument.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ClaimViewModel.SupportingDocument.CopyToAsync(stream);
                }

                ClaimViewModel.SupportingDocumentPath = filePath;
            }

            // Add logic to save claim details to the database or perform further actions

            // Redirect to a confirmation or summary page
            return RedirectToPage("/Index");
        }
    }
}
