using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataSource.Employees;
using Microsoft.EntityFrameworkCore;

namespace DataSource.Seeds
{
    public class EmployeeTargetSeeding
    {

        public static async Task Run()
        {
            Console.WriteLine("Creating employee target seed....");

            using (var context = new AuditorDbContext(ContextProvider.ContextOptions))
            {
                List<EmployeeTarget> sources = new List<EmployeeTarget>()
                {
                    new EmployeeTarget()
                    {
                        SocialSecurityNumber = "01010101",
                        FirstName = "Kari",
                        LastName = "Nordman",
                        Department = "Support"
                    },
                    new EmployeeTarget()
                    {
                        SocialSecurityNumber = "0101004",
                        FirstName = "Esther",
                        LastName = "Doe",
                        Department = "Support"
                    },
                    new EmployeeTarget()
                    {
                        SocialSecurityNumber = "01010102",
                        FirstName = "Nils",
                        LastName = "Nilsen",
                        Department = "Sales"
                    },
                };


                foreach (var source in sources)
                {
                    var employeeTarget = await context.EmployeeTargets.FirstOrDefaultAsync(x => x.SocialSecurityNumber == source.SocialSecurityNumber);
                    if (employeeTarget == null)
                    {
                        context.EmployeeTargets.Add(source);
                    }
                    else
                    {
                        employeeTarget.FirstName = source.FirstName;
                        employeeTarget.LastName = source.LastName;
                        employeeTarget.Department = source.Department;
                        context.EmployeeTargets.Update(employeeTarget);
                    }
                }

                await context.SaveChangesAsync();
            }
        }
    }
}