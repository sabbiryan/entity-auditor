using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSource.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace DataSource.Seeds
{
    public class EmployeeSourceSeeding
    {
        public static async Task Run()
        {
            Console.WriteLine("Creating source seed....");

            using (var context = new AuditorDbContext(ContextProvider.GetContextOptions()))
            {
                List<EmployeeSource> sources = new List<EmployeeSource>()
                {
                    new EmployeeSource()
                    {
                        SocialSecurityNumber = "01010101",
                        FirstName = "Kari",
                        LastName = "Nordmann",
                        Department = "Sales"
                    },
                    new EmployeeSource()
                    {
                        SocialSecurityNumber = "01010102",
                        FirstName = "Jack",
                        LastName = "Jackson",
                        Department = "Support"
                    },
                    new EmployeeSource()
                    {
                        SocialSecurityNumber = "01010103",
                        FirstName = "Nils",
                        LastName = "Nilsen",
                        Department = "Sales"
                    },
                };

                foreach (var source in sources)
                {
                    var employeeSource = await context.EmployeeSources.FirstOrDefaultAsync(x => x.SocialSecurityNumber == source.SocialSecurityNumber);
                    if (employeeSource == null)
                    {
                        context.EmployeeSources.Add(source);
                    }
                    else
                    {
                        employeeSource.FirstName = source.FirstName;
                        employeeSource.LastName = source.LastName;
                        employeeSource.Department = source.Department;
                        context.EmployeeSources.Update(employeeSource);
                    }
                }

                await context.SaveChangesAsync();
            }
        }

    }
}
