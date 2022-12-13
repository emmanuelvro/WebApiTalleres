using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Talleres.Intefaces.DataBase
{
    public interface IGlobalDAO<T>
    {
        Task<T> Insert(T entidad);
        Task<T> Update(T entidad, object key);
        Task<int> Delete(T entidad);
        Task<T> GetById(object id);
        Task<IList<T>> Get(string[] includes = null);
        Task<IList<T>> Find(Expression<Func<T, bool>> expression);
        Task Exec(string sp);
    }
}
