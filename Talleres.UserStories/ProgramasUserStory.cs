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
    public class ProgramasUserStory : UserStoryBase, IProgramasUserStory<TblPrograma>
    {
        public IGlobalContext<TblPrograma> entidad { get; set; }
        public ProgramasUserStory(IGlobalContext<TblPrograma> entidad)
        {
            this.entidad = RegisterForDispose(entidad);
        }

        public Task<bool> Delete(TblPrograma model)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<IList<TblPrograma>>> Get()
        {
            var response = new Response<IList<TblPrograma>>();
            var data = await this.entidad.Get().ConfigureAwait();
            response.AddPayload(data);
            return response;
        }

        public Task<Response<TblPrograma>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TblPrograma> Insert(TblPrograma model)
        {
            throw new NotImplementedException();
        }

        public Task<TblPrograma> Update(TblPrograma model, int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<IList<TblPrograma>>> GetByNivel(int idNivel)
        {
            var response = new Response<IList<TblPrograma>>();
            var data = await this.entidad.Get().ConfigureAwait();
            response.AddPayload(data.Where(x=> x.IdNivel == idNivel).ToList());
            return response;
        }
    }
}
