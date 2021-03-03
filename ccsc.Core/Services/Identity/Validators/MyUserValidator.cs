using ccsc.DataLayer.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ccsc.Core.Services.Identity.Validators
{
	public class MyUserValidator : UserValidator<User>
	{
		public MyUserValidator(IdentityErrorDescriber errors) : base(errors)
		{
			
		}

		public override async Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user)
		{
			var result = await base.ValidateAsync(manager, user);
			this.ValidateUser(user, result.Errors.ToList());
			return result;
		}

		private void ValidateUser(User user, List<IdentityError> errors)
		{
			if (user.UserName.Contains("Admin"))
			{
				errors.Add(new IdentityError
				{
					Code = "InvalidUser",
					Description = "نام کاربری نامعتبر"
				});
			}
		}
	}
}