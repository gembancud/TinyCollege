using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCollege.Data.Models;

namespace TinyCollege.Service.Services
{
    public class ProfessorService : BaseService
    {
        public ProfessorService() : base()
        {
        }

        public IQueryable<Professor> GetProfessors()
        {
            return _context.Professors;
        }
    }
}
