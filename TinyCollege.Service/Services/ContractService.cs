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

        public IQueryable<Contract> CreateContract(Contract contract)
        {
            _context.Add(contract);
            _context.SaveChanges();
            return _context.Contracts.Where(x => x.ContractId == _context.Contracts.Max(x => x.ContractId));
        }

        public IQueryable<ProfessorContract> GetContractProfessorContracts(int contractId)
        {
            return _context.ProfessorContracts.Where(x => x.ContractId == contractId);
        }
    }
}
