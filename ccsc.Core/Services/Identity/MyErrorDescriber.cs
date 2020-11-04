using Microsoft.AspNetCore.Identity;

namespace ccsc.Core.Services.Identity
{
	public class MyErrorDescriber : IdentityErrorDescriber
	{
		public override IdentityError DefaultError()
		=> new IdentityError()
			{
				Code = nameof(DefaultError),
				Description = "خطایی رخ داده است"
			};
	

		public override IdentityError DuplicateUserName(string userName)
			=> new IdentityError()
			{
				Code = nameof(DuplicateUserName),
				Description = $"{userName} معتبر نیست"
			};

		public override IdentityError DuplicateEmail(string email)
		{
			return new IdentityError
			{
				Code = nameof(DuplicateEmail),
				Description = "ایمیل تکراری"
			};
		}

		public override IdentityError InvalidUserName(string userName)
		{
			return new IdentityError
			{
				Code = nameof(InvalidUserName),
				Description = "نام کاربری نامعتبر"
			};
		}

		public override IdentityError PasswordRequiresDigit()
		{
			return new IdentityError
			{
				Code = nameof(PasswordRequiresDigit),
				Description = "رمز شامل عدد نیست"
			};
		}
	}
}