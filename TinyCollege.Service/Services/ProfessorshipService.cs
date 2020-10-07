using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCollege.Data.Models;

namespace TinyCollege.Service.Services
{
    public class ProfessorshipService : BaseService
    {
        public ProfessorshipService() : base()
        {
        }

        public IQueryable<Professorship> GetProfessorships()
        {
            return _context.Professorships;
        }
    }
}
