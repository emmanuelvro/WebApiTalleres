using EasyCaching.Core.Interceptor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talleres.Models.Response;

namespace Talleres.Intefaces.UserStories
{
    public interface IProgramasUserStory<T> : IGlobalUserStory<T>, IDisposable, IAsyncDisposable
    {
        [EasyCachingAble(Expiration = 600, IsHighAvailability = true)]
        Task<Response<IList<T>>> Get();

        [EasyCachingAble(Expiration = 600, IsHighAvailability = true)]
        Task<Response<IList<T>>> GetByNivel(int idNivel);
    }
}
