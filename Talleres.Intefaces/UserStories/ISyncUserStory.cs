using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talleres.Models.Response;

namespace Talleres.Intefaces.UserStories
{
    public interface ISyncUserStory<T> : IDisposable, IAsyncDisposable
    {
        Task<bool> ProcessAlumns();
        Task<bool> ProcessCost();
    }
}
