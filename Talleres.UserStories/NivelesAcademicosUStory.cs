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
    public class NivelesAcademicosUStory : UserStoryBase, INivelesAcademicoUStory<TblNivelesAcademico>
    {
        public IGlobalContext<TblNivelesAcademico> entidad { get; set; }
        public NivelesAcademicosUStory(IGlobalContext<TblNivelesAcademico> entidad)
        {
            this.entidad = RegisterForDispose(entidad);
        }

        public Task<bool> Delete(TblNivelesAcademico model)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<IList<TblNivelesAcademico>>> Get()
        {
            var response = new Response<IList<TblNivelesAcademico>>();
            var data = await this.entidad.Get().ConfigureAwait();
            response.AddPayload(data);
            return response;
        }

        public Task<Response<TblNivelesAcademico>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TblNivelesAcademico> Insert(TblNivelesAcademico model)
        {
            throw new NotImplementedException();
        }

        public Task<TblNivelesAcademico> Update(TblNivelesAcademico model, int id)
        {
            throw new NotImplementedException();
        }
    }
}
