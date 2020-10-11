using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCollege.Data.Models;

namespace TinyCollege.Service.Services
{
    public class ProfessorContractService : BaseService
    {
        public ProfessorContractService() : base()
        {
        }

        public IQueryable<ProfessorContract> GetProfessorContracts()
        {
            return _context.ProfessorContracts;
        }

        public IQueryable<ProfessorContract> CreateProfessorContract(ProfessorContract professorContract)
        {
            _context.Add(professorContract);
            _context.SaveChanges();
            return _context.ProfessorContracts.Where(x => x.ProfessorContractId == _context.ProfessorContracts.Max(x => x.ProfessorContractId));
        }

        public IQueryable<Professor> GetProfessorContractProfessor(int professorContractProfessorId)
        {
            return _context.Professors.Where(x => x.ProfessorId == professorContractProfessorId);
        }

        public IQueryable<Contract> GetContractContractContract(int professorContractContractId)
        {
            return _context.Contracts.Where(x => x.ContractId == professorContractContractId);
        }
    }
}
