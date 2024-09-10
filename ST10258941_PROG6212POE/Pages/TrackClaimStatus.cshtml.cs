using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ST10258941_PROG6212POE.Pages
{
    public class TrackClaimStatusModel : PageModel
    {
        public List<ClaimStatusViewModel> Claims { get; set; }

        public void OnGet()
        {
            // Mock data for demonstration purposes
            Claims = new List<ClaimStatusViewModel>
            {
                new ClaimStatusViewModel
                {
                    ClaimId = 1,
                    LecturerId = 101,
                    HoursWorked = 20,
                    HourlyRate = 50.00m,
                    TotalAmount = 1000.00m,
                    Status = "Pending",
                    Comments = "Awaiting approval"
                },
                new ClaimStatusViewModel
                {
                    ClaimId = 2,
                    LecturerId = 101,
                    HoursWorked = 15,
                    HourlyRate = 55.00m,
                    TotalAmount = 825.00m,
                    Status = "Approved",
                    Comments = "Approved by Programme Coordinator"
                },
                new ClaimStatusViewModel
                {
                    ClaimId = 3,
                    LecturerId = 101,
                    HoursWorked = 10,
                    HourlyRate = 60.00m,
                    TotalAmount = 600.00m,
                    Status = "Rejected",
                    Comments = "Incorrect hourly rate entered"
                }
            };
        }
    }
}
