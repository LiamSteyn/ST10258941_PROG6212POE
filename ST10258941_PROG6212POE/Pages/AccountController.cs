using Microsoft.AspNetCore.Mvc;

namespace ST10258941_PROG6212POE.Pages
{
    public class AccountController : Controller
    {
        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // Add logic for authentication here
                // For now, we'll just redirect to the home page
                return RedirectToAction("Index", "Home");
            }

            // If model state is not valid, return the view with the model
            return View(model);
        }
    }
}