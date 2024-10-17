namespace ST10258941_PROG6212POE.Pages
{
    // In-memory storage for claims
    public static class ClaimStorage
    {
        private static List<ClaimViewModel> _claims = new List<ClaimViewModel>();

        public static void AddClaim(ClaimViewModel claim)
        {
            // Assign a unique ClaimId
            claim.ClaimId = _claims.Count + 1;
            _claims.Add(claim);
        }

        public static List<ClaimViewModel> GetClaims()
        {
            return _claims;
        }
    }
}
