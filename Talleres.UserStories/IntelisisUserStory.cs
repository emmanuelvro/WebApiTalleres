using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talleres.Infraestructure.DataBase.Context;
using Talleres.Intefaces.DataBase.Context;
using Talleres.Intefaces.UserStories;

namespace Talleres.UserStories
{
    public class IntelisisUserStory : UserStoryBase, IIntelisisUserStory<Cealumno, Art, ListaPreciosTallere>
    {
        public IGlobalContext<Cealumno> entidad { get; set; }
        public IGlobalContext<Art> entidadArt { get; set; }
        public IGlobalContext<ListaPreciosTallere> entidadPrecios { get; set; }
        public IGlobalContext<CecicloEscolar> entidadCiclo { get; set; }
        public IntelisisUserStory(IGlobalContext<Cealumno> entidad,
            IGlobalContext<Art> entidadArt, 
            IGlobalContext<ListaPreciosTallere> entidadPrecios,
            IGlobalContext<CecicloEscolar> entidadCiclo)
        {
            this.entidad = RegisterForDispose(entidad);
            this.entidadArt = RegisterForDispose(entidadArt);
            this.entidadPrecios = RegisterForDispose(entidadPrecios);
            this.entidadCiclo = RegisterForDispose(entidadCiclo);
        }
        public async Task<IList<Cealumno>> GetAlumnos()
        {
            var response = await this.entidad.Get().ConfigureAwait();
            return response.ToList();
        }

        public async Task<Art> GetArticulo(string articulo)
        {
            var arts = await this.entidadArt.Find(x => x.Rama == "TALLERES" && x.Articulo == articulo);
            return arts.FirstOrDefault();
        }

        public async Task<ListaPreciosTallere> GetPrecio(string articulo)
        {
            var precio = await this.entidadPrecios.Find(x => x.Articulo == articulo);
            return precio.FirstOrDefault();
        }

        public async Task<string> GetCicloEscolarActivo()
        {
            var ciclo = await this.entidadCiclo.Find(x => x.Estatus == "Activo").ConfigureAwait();
            return ciclo.FirstOrDefault().CicloEscolar;
        }
    }
}
