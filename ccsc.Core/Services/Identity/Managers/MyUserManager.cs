using System;
using System.Collections.Generic;
using ccsc.DataLayer.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ccsc.Core.Services.Identity.Managers
{
	public class MyUserManager : UserManager<User>
	{
		public MyUserManager(
			IUserStore<User> store, 
			IOptions<IdentityOptions> optionsAccessor, 
			IPasswordHasher<User> passwordHasher, 
			IEnumerable<IUserValidator<User>> userValidators, 
			IEnumerable<IPasswordValidator<User>> passwordValidators, 
			ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, 
			IServiceProvider services, 
			ILogger<UserManager<User>> logger)
			: base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
		{
		}
	}
}