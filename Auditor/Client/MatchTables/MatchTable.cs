using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Comparer;
using Client.Extensions;
using DataSource;
using Microsoft.EntityFrameworkCore;

namespace Client.MatchTables
{
    public class MatchTable
    {
        private int BatchSize { get; set; } = 100;

        public void SetBatchSize(int batchSize)
        {
            BatchSize = batchSize;
        }


        public async Task<MatchTableResponse> FindMatch(Type sourceTable, Type targetTable, string primaryKey)
        {
            var response = new MatchTableResponse();

            using (var context = new AuditorDbContext(ContextProvider.GetContextOptions()))
            {
                context.ChangeTracker.AutoDetectChangesEnabled = false;

                var sourceDbSet = context.Set(sourceTable);
                var targetDbSet = context.Set(targetTable);

                var sourceCount = await sourceDbSet.CountAsync();
                var targetCount = await targetDbSet.CountAsync();
                Console.WriteLine($"{sourceCount} source items found and {targetCount} target items found\n\n");

                var max = Math.Max(sourceCount, targetCount);
                for (int i = 0; i < (max / BatchSize) + 1; i++)
                {
                    var skip = BatchSize * i;

                    var sources = await sourceDbSet.OrderByDynamic(x => $"x.{primaryKey}").Skip(skip).Take(BatchSize).ToListAsync();
                    var targets = await targetDbSet.OrderByDynamic(x => $"x.{primaryKey}").Skip(skip).Take(BatchSize).ToListAsync();
                    
                    foreach (var item in targets)
                    {
                        var type = item.GetType();
                        var propertyInfo = type.GetProperty(primaryKey);
                        if (propertyInfo != null)
                        {
                            var value = propertyInfo.GetValue(item)?.ToString();
                            var expression = $"x.{primaryKey}==\"{value}\"";
                            var targetItem = sources.SingleOrDefaultDynamic(x => expression);

                            if (targetItem != null)
                            {
                                var compare = targetItem.DeepCompare(item);
                                if (!compare.IsEqual)
                                {
                                    foreach (var changeProperty in compare.ChangeProperties)
                                    {
                                        response.Changes.Add(new MatchItem(value,
                                            $"{value} {changeProperty.Name.Name} changed from {changeProperty.OldValue} to {changeProperty.NewValue}"));
                                    }
                                }
                            }
                        }
                    }

                    var sourceKeys = sources.SelectDynamic(x => $"x.{primaryKey}").ToList();
                    var targetKeys = targets.SelectDynamic(x => $"x.{primaryKey}").ToList();

                    var removedItems = sourceKeys.Except(targetKeys).ToList();
                    foreach (var item in removedItems)
                    {
                        var @dynamic = sources.FirstDynamic(x => $"x.{primaryKey}==\"{item}\"");
                        response.Removed.Add(new MatchItem(item.ToString(), $"{@dynamic}"));
                    }


                    var addedItems = targetKeys.Except(sourceKeys).ToList();
                    foreach (var item in addedItems)
                    {
                        var @dynamic = targets.FirstDynamic(x => $"x.{primaryKey}==\"{item}\"");
                        response.Added.Add(new MatchItem(item.ToString(), $"{@dynamic}"));
                    }

                }

            }


            return response;
        }

    }
}
