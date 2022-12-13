using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talleres.Intefaces.DataBase;
using Talleres.Interfaces.Helpers;

namespace Talleres.Infraestructure.DataBase
{
    public class Global<T> : IGlobalDAO<T> where T : class
    {
        private readonly DbContext _context;

        public Global(DbContext context)
        {
            this._context = (DbContext)context;
        }
        public async Task<int> Delete(T entidad)
        {
            _context.Set<T>().Remove(entidad);
            return await _context.SaveChangesAsync();
        }

        public async Task Exec(string sp)
        {
            await _context.Database.ExecuteSqlRawAsync($"{sp}");
        }

        public async Task<IList<T>> Find(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<IList<T>> Get(string[] includes = null)
        {
            return await _context.Includes<T>(includes).ToListAsync();
        }


        public async Task<T> GetById(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }


        public async Task<T> Insert(T entidad)
        {
            _context.Set<T>().Add(entidad);
            await _context.SaveChangesAsync();
            return entidad;
        }


        public async Task<T> Update(T entidad, object key)
        {
            if (entidad == null)
                return null;
            _context.Set<T>().Update(entidad);
            await _context.SaveChangesAsync();
            return entidad;
        }
    }
}
