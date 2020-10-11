using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCollege.Data.Models.MotorPool;

namespace TinyCollege.Service.Services.MotorPool
{
    public class PartService : BaseService
    {
        public PartService() : base()
        {
        }

        public IQueryable<Part> GetParts()
        {
            return _context.Parts;
        }

        public IQueryable<Part> CreatePart(Part part)
        {
            _context.Add(part);
            _context.SaveChanges();
            return _context.Parts.Where(x => x.PartId == _context.Parts.Max(x => x.PartId));
        }

        public IQueryable<PartUsage> GetPartPartUsages(int partId)
        {
            return _context.PartUsages.Where(x => x.PartId == partId);
        }

        public IQueryable<Part> DeletePart(Part part)
        {
            try
            {
                _context.Parts.Attach(part);
                _context.Parts.Remove(part);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                // ignored
            }

            return _context.Parts;
        }
    }
}
