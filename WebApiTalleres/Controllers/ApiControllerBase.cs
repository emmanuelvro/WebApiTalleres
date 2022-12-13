using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace WebApiTalleres.Controllers
{
    public class ApiControllerBase<TUserHistory> : ControllerBase, IDisposable, IAsyncDisposable
           where TUserHistory : IDisposable, IAsyncDisposable
    {
        private readonly ILogger<TUserHistory> looger;
        public TUserHistory UserHistory { get; set; }
        private bool disposed;
        public ApiControllerBase(TUserHistory userHistory, ILogger<TUserHistory> looger)
        {
            this.UserHistory = userHistory;
            this.looger = looger;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        [NonAction]
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

        [NonAction]
        public IActionResult GetActionResult(object value)
        {

            Response.RegisterForDisposeAsync(this);
            return new OkObjectResult(value);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                UserHistory.Dispose();
            }

            disposed = true;
        }
    }
}
