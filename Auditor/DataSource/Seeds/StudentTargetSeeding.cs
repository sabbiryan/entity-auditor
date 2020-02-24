using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataSource.Students;
using Microsoft.EntityFrameworkCore;

namespace DataSource.Seeds
{
    public class StudentTargetSeeding
    {

        public static async Task Run()
        {
            Console.WriteLine("Creating student target seed....");

            using (var context = new AuditorDbContext(ContextProvider.ContextOptions))
            {
                List<StudentTarget> sources = new List<StudentTarget>()
                {
                    new StudentTarget()
                    {
                        StudentId = "01010101",
                        Name = "Kari Nordman",
                        Course = "Algorithm"
                    },
                    new StudentTarget()
                    {
                        StudentId = "0101004",
                        Name = "Esther Doe",
                        Course = "Data Structure"
                    },
                    new StudentTarget()
                    {
                        StudentId = "01010102",
                        Name= "Nils Nilsen",
                        Course = "Structure Programming Language"
                    },
                };


                foreach (var source in sources)
                {
                    var employeeTarget = await context.StudentTargets.FirstOrDefaultAsync(x => x.StudentId == source.StudentId);
                    if (employeeTarget == null)
                    {
                        context.StudentTargets.Add(source);
                    }
                    else
                    {
                        employeeTarget.Name = source.Name;
                        employeeTarget.Course = source.Course;
                        context.StudentTargets.Update(employeeTarget);
                    }
                }

                await context.SaveChangesAsync();
            }
        }
    }
}