using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace ST10258941_PROG6212POE.Pages
{
    public class ManageClaimsModel : PageModel
    {
        [BindProperty]
        public List<ManageClaimViewModel> Claims { get; set; }

        [BindProperty]
        public int ClaimId { get; set; }

        [BindProperty]
        public string Action { get; set; }

        [BindProperty]
        public string Comment { get; set; }

        public void OnGet()
        {
            // Load claims from the in-memory storage
            Claims = ClaimStorage.GetClaims().Select(c => new ManageClaimViewModel
            {
                ClaimId = c.ClaimId,
                LecturerId = c.LecturerId,
                HoursWorked = c.HoursWorked,
                HourlyRate = c.HourlyRate,
                TotalAmount = c.HoursWorked * c.HourlyRate,
                Status = c.Status ?? "Pending",
                Comments = c.Comments ?? string.Empty,
                AdditionalNotes = c.AdditionalNotes,
                SupportingDocumentPath = c.SupportingDocumentPath
            }).ToList();
        }

        public IActionResult OnPost()
        {
            // Find the claim by ClaimId
            var claim = ClaimStorage.GetClaims().FirstOrDefault(c => c.ClaimId == ClaimId);
            if (claim != null)
            {
                if (Action == "approve")
                {
                    claim.Status = "Approved";
                }
                else if (Action == "reject")
                {
                    claim.Status = "Rejected";
                }
                else if (Action == "comment")
                {
                    claim.Comments = Comment;
                }
            }

            // Return to the page after processing
            return RedirectToPage();
        }
    }
}