using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCollege.Data.Models;

namespace TinyCollege.Service.Services
{
    public class ContractService : BaseService
    {
        public ContractService() : base()
        {
        }

        public IQueryable<Contract> GetContracts()
        {
            return _context.Contracts;
        }

        public IQueryable<ProfessorContract> GetContractProfessorContracts(int contractId)
        {
            return _context.ProfessorContracts.Where(x => x.ContractId == contractId);
        }
    }
}
