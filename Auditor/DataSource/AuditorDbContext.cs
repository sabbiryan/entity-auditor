using System;
using System.Collections.Generic;
using System.Text;
using DataSource.Employees;
using DataSource.Persons;
using DataSource.Students;
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



        public virtual DbSet<EmployeeSource> EmployeeSources { get; set; }
        public virtual DbSet<EmployeeTarget> EmployeeTargets { get; set; }


        public virtual DbSet<StudentSource> StudentSources { get; set; }
        public virtual DbSet<StudentTarget> StudentTargets { get; set; }


        public virtual DbSet<PersonSource> PersonSources { get; set; }
        public virtual DbSet<PersonTarget> PersonTargets { get; set; }
    }

}
