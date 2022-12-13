using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talleres.Intefaces.DataBase.Context
{
    public interface IGlobalContext<T> : IGlobalDAO<T>, IDisposable, IAsyncDisposable
    {
    }
}
