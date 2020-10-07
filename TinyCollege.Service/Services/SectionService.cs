using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCollege.Data.Models;

namespace TinyCollege.Service.Services
{
    public class SectionService : BaseService
    {
        public SectionService() : base()
        {
        }

        public IQueryable<Section> GetSections()
        {
            return _context.Sections;
        }
    }
}
