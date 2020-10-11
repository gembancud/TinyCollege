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
