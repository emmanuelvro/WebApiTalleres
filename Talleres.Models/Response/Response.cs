using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talleres.Models.Response
{
    public class Response<T> : Response
    {
        private IList<T> _payload;
        public IList<T> Payload
        {
            get { return this._payload; }
        }
        [JsonIgnore]
        public T PayloadFirst
        {
            get
            {
                if (this._payload != null)
                    return this._payload.FirstOrDefault();
                else
                    return default;
            }
        }

        public Response<T> AddError(string message, T payload = default)
        {
            this.Success = false;
            this.Message = message;
            if (payload != null)
            {
                this._payload = new List<T>();
                this._payload.Add(payload);

            }
            return this;
        }

        public Response<T> AddPayload(IList<T> items)
        {
            if (this._payload == null) this._payload = new List<T>();
            ((List<T>)this._payload).AddRange(items);
            return this;
        }

        public Response<T> AddPayload(T items)
        {
            if (this._payload == null) this._payload = new List<T>();
            ((List<T>)this._payload).Add(items);
            return this;
        }
    }

    public class Response
    {
        public string Message { get; set; } = "La operacion ha sido completada";
        public bool Success { get; set; } = true;
        public virtual Response AddError(string message)
        {
            this.Success = false;
            this.Message = message;
            return this;
        }
    }
}
