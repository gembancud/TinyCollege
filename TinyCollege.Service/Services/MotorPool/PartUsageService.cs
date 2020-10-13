using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TinyCollege.Data.Models;
using TinyCollege.Data.Models.MotorPool;

namespace TinyCollege.Service.Services.MotorPool
{
    public class PartUsageService : BaseService
    {
        public PartUsageService() : base()
        {
        }

        public List<PartUsage> GetPartUsages()
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.PartUsages.ToList();
        }

        public List<PartUsage> GetPartUsages(string query)
        {
            var stringProperties = typeof(PartUsage).GetProperties().Where(prop =>
                prop.PropertyType == typeof(string) ||
                prop.PropertyType == typeof(int) ||
                prop.PropertyType == typeof(int?)
            );

            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.PartUsages.Where(
                delegate (PartUsage x)
                {
                    return stringProperties.Any(prop => (prop.PropertyType == typeof(int) && prop.GetValue(x)?.ToString() == query) ||
                                                        (prop.PropertyType == typeof(int?) && prop.GetValue(x)?.ToString() == query) ||
                                                        (prop.PropertyType == typeof(string) && EF.Functions.Like(prop.GetValue(x)?.ToString(), $"%{query}%")));
                }
            ).ToList();
        }

        public List<PartUsage> CreatePartUsage(PartUsage partUsage)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            _context.Add(partUsage);
            _context.SaveChanges();
            return _context.PartUsages.Where(x => x.PartUsageId == _context.PartUsages.Max(x => x.PartUsageId)).ToList();
        }

        public List<Part> GetPartUsagePart(int partUsagePartId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Parts.Where(x => x.PartId == partUsagePartId).ToList();
        }

        public List<MaintenanceDetail> GetPartUsageMaintenanceDetail(int partUsageMaintenanceDetailId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.MaintenanceDetails.Where(x => x.MaintenanceDetailId == partUsageMaintenanceDetailId).ToList();
        }

        public List<PartUsage> DeletePartUsage(PartUsage partUsage)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            try
            {
                _context.PartUsages.Attach(partUsage);
                _context.PartUsages.Remove(partUsage);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                // ignored
            }

            return _context.PartUsages.ToList();
        }

        public List<PartUsage> EditPartUsage(PartUsage partUsage)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);
            var tmpPartUsage = _context.PartUsages.First(x => x.PartUsageId == partUsage.PartUsageId);
            _context.Entry(tmpPartUsage).CurrentValues.SetValues(partUsage);
            _context.SaveChanges();
            return _context.PartUsages.Where(x => x.PartUsageId == partUsage.PartUsageId).ToList();
        }
    }
}
