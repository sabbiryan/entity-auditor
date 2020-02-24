using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Client.DynamicInputs;
using Client.MatchTables;
using DataSource;
using DataSource.Employees;

namespace Client
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            await DatabaseService.Ensure();

            Console.WriteLine("Processing table matching....");

            StartTableMatching:
            var input = DynamicInputHandler.TakeInput();

            var matchTable = new MatchTable();
            matchTable.SetBatchSize(10);
            MatchTableResponse response;
            try
            {
                response = await matchTable.FindMatch(input.SourceEntity, input.TargetEntity, input.PrimaryKey);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine($"The source and target tables schema may does not match. Starting the matching again... \n\n");
                goto StartTableMatching;
            }


            Console.WriteLine("Added\n---------");
            foreach (var item in response.Added) Console.WriteLine($"{item.Message}");

            Console.WriteLine("\nRemoved\n---------");
            foreach (var item in response.Removed) Console.WriteLine($"{item.Message}");

            Console.WriteLine("\nChanges\n---------");
            foreach (var item in response.Changes) Console.WriteLine($"{item.Message}");

            Console.WriteLine("\n\nFinished table matching....");

            Console.WriteLine("\n\nAre you wish to play with another entities??\n1. Yes \t2. Press any other key to exit.");
            var action = Console.ReadLine();
            if (action == "1" || action?.ToLower() == "yes")
            {
                goto StartTableMatching;
            }

        }
    }
}