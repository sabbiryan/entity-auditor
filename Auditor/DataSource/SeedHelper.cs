using System.Threading.Tasks;
using DataSource.Seeds;

namespace DataSource
{
    public class SeedHelper
    {

        public static async Task Run()
        {

            await EmployeeSourceSeeding.Run();
            await EmployeeTargetSeeding.Run();

            await StudentSourceSeeding.Run();
            await StudentTargetSeeding.Run();
        }
    }
}