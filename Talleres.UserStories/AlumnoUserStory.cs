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
    public class AlumnoUserStory : UserStoryBase, IAlumnoUserStory<TblAlumno>
    {
        public IGlobalContext<TblAlumno> entidad { get; set; }

        public AlumnoUserStory(IGlobalContext<TblAlumno> entidad)
        {
            this.entidad = RegisterForDispose(entidad);
        }

        public async Task<Response<IList<TblAlumno>>> Get()
        {
            var response = new Response<IList<TblAlumno>>();
            var data = await this.entidad.Get().ConfigureAwait();
            response.AddPayload(data);
            return response;
        }

        public Task<Response<TblAlumno>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TblAlumno> Insert(TblAlumno model)
        {
            throw new NotImplementedException();
        }

        public Task<TblAlumno> Update(TblAlumno model, int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(TblAlumno model)
        {
            throw new NotImplementedException();
        }
    }
}
