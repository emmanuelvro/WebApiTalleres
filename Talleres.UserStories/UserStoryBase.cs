using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talleres.UserStories
{
    public class UserStoryBase : IDisposable, IAsyncDisposable
    {
        protected bool disposed;
        private IList<IDisposable> ForDispose;
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

        public T RegisterForDispose<T>(T item)
                            where T : IDisposable
        {
            if (ForDispose == null)
                ForDispose = new List<IDisposable>();

            ForDispose.Add(item);
            return item;
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
