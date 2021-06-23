using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ccsc.Core.Services.Interfaces;
using ccsc.DataLayer.Context;
using ccsc.DataLayer.Entities.ChangeSets;
using ccsc.DataLayer.Entities.Contacts;
using ccsc.DataLayer.Entities.Contracts;
using ccsc.DataLayer.Entities.Courses;
using Microsoft.EntityFrameworkCore;

namespace ccsc.Core.Services
{
	public class ContractService : IContractService
	{
		private readonly CcscContext _context;
		private readonly ISubSystemService _subSystemService;

		public ContractService(CcscContext context, ISubSystemService subSystemService)
		{
			_context = context;
			_subSystemService = subSystemService;
		}

		public int AddContract(Contract contract)
		{
			_context.Contracts.Add(contract);
			_context.SaveChanges();
			return contract.ContractId;
		}

		public List<SubSystem> GetSubSystemsOfContract(int id)
		{
			List<SubSystem> subSystems = new List<SubSystem>();
			subSystems = _context.SubSystems
				.Include(s => s.Contracts)
				.Where(s => s.Contracts.Any(e => e.ContractId == id))
				.ToList();

			return subSystems;
		}


		public async Task UpdateContractAsync(Contract input, List<int> subSystemIds)
		{
				input.SubSystems = await _subSystemService.GetSubSystemsByIds(subSystemIds);

			_context.Update(input);
			await _context.SaveChangesAsync();
		}

		public async Task RemoveContractRelatedAsync(Contract contract)
		{
			var subSystems = GetSubSystemsOfContract(contract.ContractId);

			if (subSystems.Any())
			{
				foreach (var ss in subSystems)
				{
					contract.SubSystems.Remove(ss);
					_context.Update(contract);
					await _context.SaveChangesAsync();
				}
			}
		}

		 async Task IContractService.AddContract(Contract newContract, List<int> selectedSubSystems)
		{
			AddContract(newContract);

			await _context.SaveChangesAsync();

			await UpdateContractAsync(newContract, selectedSubSystems);
		}

		public async Task<List<Course>> GetCoursesOfContract(int contractId)
		{
			List<Course> courses = new List<Course>();
			courses = await _context.Courses
				.Include(c => c.Contracts)
				.Where(c => c.Contracts.Any(e => e.ContractId == contractId))
				.Where(c => c.IsActive)
				.ToListAsync();

			return courses;
		}
	}
}
