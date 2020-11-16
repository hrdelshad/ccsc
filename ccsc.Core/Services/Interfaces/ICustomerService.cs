﻿using System.Collections.Generic;
using ccsc.DataLayer.Entities.ChangeSets;

namespace ccsc.Core.Services.Interfaces
{
	public interface ICustomerService
	{
		string GetVersion(string url);
		string TabibVersion(string url);

		bool CustomerExists(int customerId);
	}

	
}