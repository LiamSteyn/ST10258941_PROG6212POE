using Microsoft.AspNetCore.Mvc.RazorPages;
using ST10258941_PROG6212POE.Pages;

namespace ST10258941_PROG6212POE.Pages
{
    public class TrackClaimStatusModel : PageModel
    {
        private readonly ILogger<TrackClaimStatusModel> _logger;

        public List<ClaimStatusViewModel> Claims { get; set; }

        public TrackClaimStatusModel(ILogger<TrackClaimStatusModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            // Retrieve claims from in-memory storage
            Claims = ClaimStorage.GetClaims().Select(claim => new ClaimStatusViewModel
            {
                ClaimId = claim.ClaimId,
                LecturerId = claim.LecturerId,
                HoursWorked = claim.HoursWorked,
                HourlyRate = claim.HourlyRate,
                TotalAmount = claim.HoursWorked * claim.HourlyRate,
                Status = "Pending", // For now, default status is set to "Pending"
                Comments = "Awaiting approval"
            }).ToList();

            if (Claims.Count == 0)
            {
                _logger.LogInformation("No claims found.");
            }
            else
            {
                _logger.LogInformation($"{Claims.Count} claims found.");
            }
        }
    }
}
