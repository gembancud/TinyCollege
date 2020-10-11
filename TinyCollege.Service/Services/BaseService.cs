using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TinyCollege.Data.Models;

namespace TinyCollege.Service.Services
{
    public class BaseService
    {
        public BaseService()
        {
            var builder = new DbContextOptionsBuilder<TinyCollegeContext>();
            var connectionString = "Server=localhost\\DEV;Database=TinyCollegeTest;Trusted_Connection=true;";
            builder.UseSqlServer(connectionString);
            _builder = builder;
            //_context = new TinyCollegeContext(builder.Options);
        }

        //protected TinyCollegeContext _context { get; set; }
        protected DbContextOptionsBuilder<TinyCollegeContext> _builder { get; set; }
    }
}