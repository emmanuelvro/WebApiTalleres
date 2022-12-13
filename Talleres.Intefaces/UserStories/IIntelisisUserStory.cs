using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talleres.Intefaces.UserStories
{
    public interface IIntelisisUserStory<T, A, P> : IDisposable, IAsyncDisposable
    {
        Task<IList<T>> GetAlumnos();
        Task<A> GetArticulo(string articulo);
        Task<P> GetPrecio(string articulo);
        Task<string> GetCicloEscolarActivo();
    }
}
