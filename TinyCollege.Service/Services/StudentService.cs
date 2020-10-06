using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCollege.Data.Models;

namespace TinyCollege.Service.Services
{
    public class StudentService : BaseService
    {
        public StudentService() : base()
        {
        }

        public IQueryable<Student> GetStudents()
        {
            return _context.Students;
        }
    }
}