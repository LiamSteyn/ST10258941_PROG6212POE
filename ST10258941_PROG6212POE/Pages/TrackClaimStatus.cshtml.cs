using Microsoft.AspNetCore.Mvc.RazorPages;

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
                TotalAmount = claim.HoursWorked * claim.HourlyRate, // Total amount owed calculation
                Status = claim.Status ?? "Pending",
                Comments = claim.Comments ?? string.Empty,
                AdditionalNotes = claim.AdditionalNotes
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
