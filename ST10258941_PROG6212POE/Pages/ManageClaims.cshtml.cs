using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
            // Mock data for demonstration purposes
            Claims = new List<ManageClaimViewModel>
            {
                new ManageClaimViewModel
                {
                    ClaimId = 1,
                    LecturerId = 101,
                    HoursWorked = 20,
                    HourlyRate = 50.00m,
                    TotalAmount = 1000.00m,
                    Status = "Pending",
                    Comments = ""
                },
                new ManageClaimViewModel
                {
                    ClaimId = 2,
                    LecturerId = 101,
                    HoursWorked = 15,
                    HourlyRate = 55.00m,
                    TotalAmount = 825.00m,
                    Status = "Pending",
                    Comments = ""
                }
            };
        }

        public IActionResult OnPost()
        {
            // Perform the action based on the button clicked (approve, reject, or comment)
            foreach (var claim in Claims)
            {
                if (claim.ClaimId == ClaimId)
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
                    break;
                }
            }

            // Normally, you would save changes to the database here

            return RedirectToPage();
        }
    }
}
