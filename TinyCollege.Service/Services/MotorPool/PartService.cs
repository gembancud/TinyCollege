using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCollege.Data.Models;
using TinyCollege.Data.Models.MotorPool;

namespace TinyCollege.Service.Services.MotorPool
{
    public class PartService : BaseService
    {
        public PartService() : base()
        {
        }

        public List<Part> GetParts()
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Parts.ToList();
        }

        public List<Part> CreatePart(Part part)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            _context.Add(part);
            _context.SaveChanges();
            return _context.Parts.Where(x => x.PartId == _context.Parts.Max(x => x.PartId)).ToList();
        }

        public List<PartUsage> GetPartPartUsages(int partId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.PartUsages.Where(x => x.PartId == partId).ToList();
        }

        public List<Part> DeletePart(Part part)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

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

            return _context.Parts.ToList();
        }

        public List<Part> EditPart(Part part)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);
            var tmpPart = _context.Parts.First(x => x.PartId == part.PartId);
            _context.Entry(tmpPart).CurrentValues.SetValues(part);
            _context.SaveChanges();
            return _context.Parts.Where(x => x.PartId == part.PartId).ToList();
        }
    }
}
