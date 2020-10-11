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

        public List<Contract> GetContracts()
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Contracts.ToList();
        }

        public List<Contract> CreateContract(Contract contract)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            _context.Add(contract);
            _context.SaveChanges();
            return _context.Contracts.Where(x => x.ContractId == _context.Contracts.Max(x => x.ContractId)).ToList();
        }

        public List<ProfessorContract> GetContractProfessorContracts(int contractId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.ProfessorContracts.Where(x => x.ContractId == contractId).ToList();
        }

        public List<Contract> DeleteContract(Contract contract)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            try
            {
                _context.Contracts.Attach(contract);
                _context.Contracts.Remove(contract);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                // ignored
            }

            return _context.Contracts.ToList();
        }

        public List<Contract> EditContract(Contract contract)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);
            var tmpContract = _context.Contracts.First(x => x.ContractId == contract.ContractId);
            _context.Entry(tmpContract).CurrentValues.SetValues(contract);
            _context.SaveChanges();
            return _context.Contracts.Where(x => x.ContractId == contract.ContractId).ToList();
        }
    }
}
