using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using Document = iTextSharp.text.Document;

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
                TotalAmount = c.HoursWorked * c.HourlyRate, // Calculate the total amount owed according to the claim data
                Status = c.Status ?? "Pending",
                Comments = c.Comments ?? string.Empty,
                AdditionalNotes = c.AdditionalNotes,
                SupportingDocumentPath = c.SupportingDocumentPath
            }).ToList();
        }

        // Update the claims status
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
        public IActionResult OnPostGeneratePdf()
        {
            // Filter approved claims
            var approvedClaims = ClaimStorage.GetClaims().Where(c => c.Status == "Approved").ToList();

            if (!approvedClaims.Any())
            {
                TempData["Message"] = "No approved claims available for report generation.";
                return RedirectToPage();
            }

            // Create PDF document
            var outputPath = Path.Combine("wwwroot/reports", $"ApprovedClaims_{DateTime.Now:yyyyMMddHHmmss}.pdf");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var stream = new FileStream(outputPath, FileMode.Create))
            {
                var document = new Document();
                PdfWriter.GetInstance(document, stream);
                document.Open();

                document.Add(new Paragraph("Approved Claims Report"));
                document.Add(new Paragraph($"Generated on: {DateTime.Now}\n\n"));

                PdfPTable table = new PdfPTable(5);
                table.AddCell("Claim ID");
                table.AddCell("Lecturer ID");
                table.AddCell("Hours Worked");
                table.AddCell("Hourly Rate");
                table.AddCell("Total Amount");

                foreach (var claim in approvedClaims)
                {
                    table.AddCell(claim.ClaimId.ToString());
                    table.AddCell(claim.LecturerId.ToString());
                    table.AddCell(claim.HoursWorked.ToString());
                    table.AddCell(claim.HourlyRate.ToString("C"));
                    table.AddCell((claim.HoursWorked * claim.HourlyRate).ToString("C"));
                }

                document.Add(table);
                document.Close();
            }

            // Return file as a download
            var fileName = Path.GetFileName(outputPath);
            return File(System.IO.File.ReadAllBytes(outputPath), "application/pdf", fileName);
        }
    }
}