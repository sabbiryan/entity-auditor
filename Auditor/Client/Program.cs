using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.MatchTables;
using DataSource;
using DataSource.Employees;
using DataSource.Seeds;
using Microsoft.EntityFrameworkCore;

namespace Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await EmployeeSourceSeeding.Run();
            await EmployeeTargetSeeding.Run();

            Console.WriteLine("Processing table matching....");


            var matchTable = new MatchTable();
            matchTable.SetBatchSize(10);
            var response = await matchTable.FindMatch(typeof(EmployeeSource), typeof(EmployeeTarget), nameof(EmployeeBase.SocialSecurityNumber));

            Console.WriteLine("Added\n---------");
            foreach (var item in response.Added)
            {
                Console.WriteLine($"{item.Message}");
            }

            Console.WriteLine("\nRemoved\n---------");
            foreach (var item in response.Removed)
            {
                Console.WriteLine($"{item.Message}");
            }

            Console.WriteLine("\nChanges\n---------");
            foreach (var item in response.Changes)
            {
                Console.WriteLine($"{item.Message}");
            }

            Console.WriteLine("\n\nFinished table matching....");
        }
    }

   
}
