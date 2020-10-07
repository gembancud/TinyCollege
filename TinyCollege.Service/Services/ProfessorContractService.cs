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
    }
}
