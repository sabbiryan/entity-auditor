using System;
using System.Linq;
using System.Reflection;

namespace Client.DynamicInputs
{
    public class DynamicInputHandler
    {
        public static DynamicInputResponse TakeInput()
        {

            #region Inputs

            var assembly = Assembly.Load(nameof(DataSource));
            var entityTypes = assembly.GetTypes();

            SourceInput:
            Console.WriteLine("Enter the source table name: ");
            var source = Console.ReadLine();
            var sourceType = entityTypes.FirstOrDefault(x => x.Name.ToLower() == source?.Replace(" ", "").Trim().ToLower());
            if (sourceType == null)
            {
                Console.WriteLine($"Entity not found with key: {source}");
                goto SourceInput;
            }

            SourceTarget:
            Console.WriteLine("Enter the target table name: ");
            var target = Console.ReadLine();
            var targetType = entityTypes.FirstOrDefault(x => x.Name.ToLower() == target?.Replace(" ", "").Trim().ToLower());
            if (targetType == null)
            {
                Console.WriteLine($"Entity not found with key: {target}");
                goto SourceTarget;
            }


            PrimaryKey:
            Console.WriteLine("Enter the table primary key name: ");
            var primaryKey = Console.ReadLine();
            if (string.IsNullOrEmpty(primaryKey))
            {
                Console.WriteLine("Primary key can not be null or empty...");
                goto PrimaryKey;
            }

            var properties = sourceType.GetProperties();
            var propertyInfo = properties.FirstOrDefault(x => x.Name.ToLower() == primaryKey?.Replace(" ", "").Trim().ToLower());
            if (propertyInfo == null)
            {
                Console.WriteLine($"Primary key not found with key {primaryKey}");
                goto PrimaryKey;
            }

            primaryKey = propertyInfo.Name;

            #endregion


            return new DynamicInputResponse()
            {
                SourceEntity = sourceType,
                TargetEntity = targetType,
                PrimaryKey = primaryKey
            };
        }
    }
}