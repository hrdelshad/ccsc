using System;
using System.Threading.Tasks;
using ccsc.Core.DTOs.Account;
using ccsc.DataLayer.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ccsc.Web.Controllers
{
	[Route("account")]
	public class Accounts : Controller
	{
		private UserManager<User> _userManager;
		private SignInManager<User> _signInManager;

		public Accounts(UserManager<User> userManager, SignInManager<User> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		[HttpGet("SignUp", Name = "GetRegister")]
		public IActionResult Register(string returnTo)
		{
			if (_signInManager.IsSignedIn(User))
			{
				return RedirectToAction("Index", "Home");
			}

			ViewData["returnTo"] = returnTo;
			return View();
		}

		[HttpPost("SignUp", Name = "PostRegister")]
		public async Task<IActionResult> Register(RegisterAccountViewModel account, string returnTo)
		{
			if (_signInManager.IsSignedIn(User))
			{
				return RedirectToAction("Index", "Home");
			}

			ViewData["returnTo"] = returnTo;

			if (ModelState.IsValid)
			{
				User user = new User
				{
					UserName = account.UserName,
					Email = account.Email,
					FirstName = account.FirstName,
					LastName = account.LastName,
					DisplayName = account.DisplayName,
					RegisteredOn = DateTime.Now

				};

				var result = await _userManager.CreateAsync(user, account.Password);
				if (result.Succeeded)
				{
					//ToDo Implement Email verification
					//return RedirectToLocal(returnTo);
					return RedirectToAction("Index", "Home");
				}

				this.AddErrors(result);
			}

			return View(account);
		}

		[HttpGet("SignIn", Name = "GetLogin")]
		public IActionResult Login(string returnTo = null)
		{
			if (_signInManager.IsSignedIn(User))
				return string.IsNullOrEmpty(returnTo)
					? RedirectToLocal(returnTo)
					: RedirectToAction("Index", "Home");

			ViewData["returnTo"] = returnTo;
			return View();
		}

		[HttpPost("SignIn", Name = "PostLogin")]
		public async Task<IActionResult> Login(LoginViewModel model, string returnTo = null)
		{
			if (_signInManager.IsSignedIn(User))
				return !string.IsNullOrEmpty(returnTo)
					? RedirectToLocal(returnTo)
					: RedirectToAction("Index", "Home");

			ViewData["returnTo"] = returnTo;
			if (!ModelState.IsValid) return View(model);

			var result = await _signInManager.PasswordSignInAsync(
				model.UserName, model.Password, model.RememberMe, true);

			if (!result.Succeeded)
			{
				if (result.IsLockedOut)
				{
					var lockoutTime = _signInManager.Options.Lockout.DefaultLockoutTimeSpan;
					ViewData["ErrorMessage"] = "تا {0} دقیقه دیگر امکان ورود نیست.";
				}

				ModelState.AddModelError(string.Empty, "نام کاربری یا کلمه عبور نامعتبر");
			}
			else
			{
				return !string.IsNullOrEmpty(returnTo)
					? RedirectToLocal(returnTo)
					: RedirectToAction("Index", "Home");
			}

			return View(model);

		}


		[HttpPost("SignOut", Name = "GetLogOn")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}



		private IActionResult RedirectToLocal(string returnTo)
		{
			return Redirect(Url.IsLocalUrl(returnTo) ? returnTo : "/");
		}

		private void AddErrors(IdentityResult result)
		{
			foreach (var error in result.Errors)
			{
				ModelState.AddModelError(string.Empty, error.Description);
			}
		}
	}
}
