using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talleres.Intefaces.DataBase.Context;

namespace Talleres.Infraestructure.DataBase.Context
{
    public class DataContext<T> : Global<T>, IGlobalContext<T> where T : class
    {
        protected bool disposed;
        private readonly IList<IDisposable> ForDispose;
        public DataContext(talleresContext context) : base(context)
        {

        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public ValueTask DisposeAsync()
        {
            try
            {
                Dispose();
                return default;
            }
            catch (Exception exception)
            {
                return new ValueTask(Task.FromException(exception));
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                var list = ForDispose as List<IDisposable>;
                if (list != null && list.Any())
                    list.ForEach(w => w.Dispose());
            }

            disposed = true;
        }
    }
}
