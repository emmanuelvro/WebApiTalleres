using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talleres.Models.Request;

namespace Talleres.Intefaces.UserStories
{
    public interface INotificationUserStory : IDisposable, IAsyncDisposable
    {
        Task Confirmation(Alumno alumno);
    }
}
