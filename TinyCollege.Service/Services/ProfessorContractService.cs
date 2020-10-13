using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TinyCollege.Data.Models;

namespace TinyCollege.Service.Services
{
    public class ProfessorContractService : BaseService
    {
        public ProfessorContractService() : base()
        {
        }

        public List<ProfessorContract> GetProfessorContracts()
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.ProfessorContracts.ToList();
        }

        public List<ProfessorContract> GetProfessorContracts(string query)
        {
            var stringProperties = typeof(ProfessorContract).GetProperties().Where(prop =>
                prop.PropertyType == typeof(string) ||
                prop.PropertyType == typeof(int) ||
                prop.PropertyType == typeof(int?)
            );

            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.ProfessorContracts.Where(
                delegate (ProfessorContract x)
                {
                    return stringProperties.Any(prop => (prop.PropertyType == typeof(int) && prop.GetValue(x)?.ToString() == query) ||
                                                        (prop.PropertyType == typeof(int?) && prop.GetValue(x)?.ToString() == query) ||
                                                        (prop.PropertyType == typeof(string) && EF.Functions.Like(prop.GetValue(x)?.ToString(), $"%{query}%")));
                }
            ).ToList();
        }

        public List<ProfessorContract> CreateProfessorContract(ProfessorContract professorContract)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            _context.Add(professorContract);
            _context.SaveChanges();
            return _context.ProfessorContracts.Where(x => x.ProfessorContractId == _context.ProfessorContracts.Max(x => x.ProfessorContractId)).ToList();
        }

        public List<Professor> GetProfessorContractProfessor(int professorContractProfessorId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Professors.Where(x => x.ProfessorId == professorContractProfessorId).ToList();
        }

        public List<Contract> GetContractContractContract(int professorContractContractId)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            return _context.Contracts.Where(x => x.ContractId == professorContractContractId).ToList();
        }

        public List<ProfessorContract> DeleteProfessorContract(ProfessorContract professorContract)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);

            try
            {
                _context.ProfessorContracts.Attach(professorContract);
                _context.ProfessorContracts.Remove(professorContract);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                // ignored
            }

            return _context.ProfessorContracts.ToList();
        }

        public List<ProfessorContract> EditProfessorContract(ProfessorContract professorContract)
        {
            using TinyCollegeContext _context = new TinyCollegeContext(_builder.Options);
            var tmpProfessorContract = _context.ProfessorContracts.First(x => x.ProfessorContractId == professorContract.ProfessorContractId);
            _context.Entry(tmpProfessorContract).CurrentValues.SetValues(professorContract);
            _context.SaveChanges();
            return _context.ProfessorContracts.Where(x => x.ProfessorContractId == professorContract.ProfessorContractId).ToList();
        }
    }
}
