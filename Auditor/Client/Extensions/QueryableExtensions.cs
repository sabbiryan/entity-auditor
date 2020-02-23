using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Client.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<object> Set(this DbContext context, Type t)
        {
            return (IQueryable<object>)context.GetType().GetMethod("Set")?.MakeGenericMethod(t)
                .Invoke(context, null);
        }

        public static IQueryable Query(this DbContext context, string entityName) =>
            context.Query(context.Model.FindEntityType(entityName).ClrType);

        public static IQueryable Query(this DbContext context, Type entityType) =>
            (IQueryable)((IDbSetCache)context).GetOrAddSet(context.GetDependencies().SetSource, entityType);
    }
}
