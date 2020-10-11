﻿using System;
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

        public IQueryable<Department> GetStudentDepartment(int studentDepartmentId)
        {
            return _context.Departments.Where(x => x.DepartmentId == studentDepartmentId);
        }

        public IQueryable<Advisory> GetStudentAdvisory(int studentAdvisoryId)
        {
            return _context.Advisories.Where(x => x.AdvisoryId == studentAdvisoryId);
        }

        public IQueryable<Enrollment> GetStudentEnrollments(int studentId)
        {
            return _context.Enrollments.Where(x => x.StudentId == studentId);
        }
    }
}