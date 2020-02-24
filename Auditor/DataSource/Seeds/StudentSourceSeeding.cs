using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataSource.Students;
using Microsoft.EntityFrameworkCore;

namespace DataSource.Seeds
{
    public class StudentSourceSeeding
    {
        public static async Task Run()
        {
            Console.WriteLine("Creating student source seed....");

            using (var context = new AuditorDbContext(ContextProvider.ContextOptions))
            {
                List<StudentSource> sources = new List<StudentSource>()
                {
                    new StudentSource()
                    {
                        StudentId = "01010101",
                        Name = "Kari Nordmann",
                        Course = "C#"
                    },
                    new StudentSource()
                    {
                        StudentId = "01010102",
                        Name = "Jack Jackson",
                        Course = "Javascript"
                    },
                    new StudentSource()
                    {
                        StudentId = "01010103",
                        Name = "Nils Nilsen",
                        Course = "SQL Server"
                    },
                };

                foreach (var source in sources)
                {
                    var studentSource = await context.StudentSources.FirstOrDefaultAsync(x => x.StudentId == source.StudentId);
                    if (studentSource == null)
                    {
                        context.StudentSources.Add(source);
                    }
                    else
                    {
                        studentSource.Name = source.Name;
                        studentSource.Course = source.Course;
                        context.StudentSources.Update(studentSource);
                    }
                }

                await context.SaveChangesAsync();
            }
        }

    }
}