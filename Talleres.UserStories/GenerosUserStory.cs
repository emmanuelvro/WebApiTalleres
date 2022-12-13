using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talleres.Infraestructure.DataBase.Context;
using Talleres.Intefaces.DataBase.Context;
using Talleres.Intefaces.UserStories;
using Talleres.Models.Response;

namespace Talleres.UserStories
{
    public class GenerosUserStory : UserStoryBase, IGenerosUserStory<TblGenero>
    {
        public IGlobalContext<TblGenero> entidad { get; set; }
        public GenerosUserStory(IGlobalContext<TblGenero> entidad)
        {
            this.entidad = RegisterForDispose(entidad);
        }

        public Task<bool> Delete(TblGenero model)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<IList<TblGenero>>> Get()
        {
            var response = new Response<IList<TblGenero>>();
            var data = await this.entidad.Get().ConfigureAwait();
            response.AddPayload(data);
            return response;
        }

        public Task<Response<TblGenero>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TblGenero> Insert(TblGenero model)
        {
            throw new NotImplementedException();
        }

        public Task<TblGenero> Update(TblGenero model, int id)
        {
            throw new NotImplementedException();
        }
    }
}
