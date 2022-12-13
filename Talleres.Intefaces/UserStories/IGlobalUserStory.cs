using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talleres.Intefaces.DataBase.Context;
using Talleres.Models.Response;

namespace Talleres.Intefaces.UserStories
{
    public interface IGlobalUserStory<T> : IDisposable, IAsyncDisposable
    {
        IGlobalContext<T> entidad { get; set; }
        Task<Response<T>> GetById(int id);
        Task<T> Insert(T model);
        Task<T> Update(T model, int id);
        Task<bool> Delete(T model);
        public Task<bool> SendEmail(T user)
        {
            throw new NotImplementedException();
        }
    }
}
