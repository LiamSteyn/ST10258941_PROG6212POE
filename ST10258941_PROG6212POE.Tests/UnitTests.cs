using ST10258941_PROG6212POE.Pages;

namespace ST10258941_PROG6212POE.Tests
{
    [TestClass]
    public class SubmitClaimModelTests
    {
        [TestMethod]
        public void ClaimViewModel_ValidData_ShouldBeValid()
        {
            // Arrange
            var model = new ClaimViewModel
            {
                LecturerId = 1,
                HoursWorked = 10,
                HourlyRate = 50.0m,
                SupportingDocumentPath = "Error" // or set to a valid path
            };

            // Act
            bool isValid = ValidateClaimViewModel(model);

            // Assert
            Assert.IsTrue(isValid);
        }


        // Checks if an error comes up if hours if negative
        [TestMethod]
        public void ClaimViewModel_InvalidHoursWorked_ShouldBeInvalid()
        {
            // Arrange
            var model = new ClaimViewModel
            {
                LecturerId = 1,
                HoursWorked = -5, // Invalid value
                HourlyRate = 50.0m,
                SupportingDocumentPath = "Error"
            };

            // Act
            bool isValid = ValidateClaimViewModel(model);

            // Assert
            Assert.IsFalse(isValid);
        }

        private bool ValidateClaimViewModel(ClaimViewModel model)
        {
            // Simple validation logic
            return model.HoursWorked >= 0 && model.HourlyRate > 0;
        }
    }

    // Checks if the valid claim goes through
    [TestClass]
    public class ManageClaimViewModelTests
    {
        [TestMethod]
        public void ManageClaimViewModel_ValidData_ShouldBeValid()
        {
            // Arrange
            var claim = new ManageClaimViewModel
            {
                ClaimId = 1,
                LecturerId = 101,
                HoursWorked = 20,
                HourlyRate = 50.00m,
                TotalAmount = 1000.00m,
                Status = "Pending",
                Comments = ""
            };

            // Act
            bool isValid = ValidateManageClaimViewModel(claim);

            // Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void ManageClaimViewModel_InvalidStatus_ShouldBeInvalid()
        {
            // Arrange
            var claim = new ManageClaimViewModel
            {
                ClaimId = 1,
                LecturerId = 101,
                HoursWorked = 20,
                HourlyRate = 50.00m,
                TotalAmount = 1000.00m,
                Status = "Unknown", // Invalid status
                Comments = ""
            };

            // Act
            bool isValid = ValidateManageClaimViewModel(claim);

            // Assert
            Assert.IsFalse(isValid);
        }

        private bool ValidateManageClaimViewModel(ManageClaimViewModel claim)
        {
            // Simple validation logic
            return claim.Status == "Pending" || claim.Status == "Approved" || claim.Status == "Rejected";
        }
    }
}
