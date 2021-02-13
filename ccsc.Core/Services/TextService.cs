using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ccsc.Core.Services.Interfaces;

namespace ccsc.Core.Services
{
	public class TextService : ITextService
	{
		public bool IsDuplicate(string str1, string str2)
		{
			bool isDuplicate = str1 == str2;

			return isDuplicate;

		}
	}
}
