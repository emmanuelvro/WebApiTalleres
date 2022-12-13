using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Talleres.Interfaces.Helpers
{
    public static class RepositoryExtend
    {
        public static IQueryable<T> Includes<T>(this DbContext context, string[] includes)
       where T : class
        {
            var query = context.Set<T>().AsQueryable();
            if(includes == null) return query;

            foreach (string include in includes)
                query = query.Include(include);

            return query;
        }
    }
}
