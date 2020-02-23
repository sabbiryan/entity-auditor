using System;
using System.Collections.Generic;
using System.Text;
using DataSource.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DataSource
{
    public class AuditorDbContext: DbContext
    {
        public AuditorDbContext(DbContextOptions options): base(options)
        {
            
        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=.\SQLExpress;Database=AuditorDb;Trusted_Connection=True;");
        //}


        public virtual DbSet<EmployeeSource> EmployeeSources { get; set; }
        public virtual DbSet<EmployeeTarget> EmployeeTargets { get; set; }
    }
}
