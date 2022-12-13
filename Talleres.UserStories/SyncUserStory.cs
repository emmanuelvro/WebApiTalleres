using Microsoft.EntityFrameworkCore;
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
    public class SyncUserStory : UserStoryBase, ISyncUserStory<Cealumno>
    {
        private IIntelisisUserStory<Cealumno, Art, ListaPreciosTallere> intelisisUserStory;

        public SyncUserStory(IIntelisisUserStory<Cealumno, Art, ListaPreciosTallere> intelisisUserStory)
        {
            this.intelisisUserStory = intelisisUserStory;
        }

        public async Task<bool> ProcessCost()
        {
            using (var entidadTalleres = new colegioContext())
            {
                List<int> ciclos = await entidadTalleres.TblCatClicloEscolars.Where(x=> x.Activo).Select(x=> x.Id).ToListAsync();
                List<TblCatTallere> talleres = await entidadTalleres.TblCatTalleres.Where(x => ciclos.Contains(x.IdCliclo)).ToListAsync();
                foreach (var item in talleres)
                {
                    if (!string.IsNullOrEmpty(item.IdIntelisis))
                    {
                        if(item.IdPlantel == 3)
                        {
                            try
                            {
                                var costo = await this.intelisisUserStory.GetPrecio(item.IdIntelisis).ConfigureAwait();
                                if (costo is not null)
                                    item.Costo = Convert.ToDouble(costo.Semestre1?.ToString() ?? costo.Inscripcion.Value.ToString() ?? costo.Mensualidaes.Value.ToString());
                            }
                            catch (Exception)
                            {
                            }
                            
                        }
                        else
                        {
                            try
                            {
                                var costo = await this.intelisisUserStory.GetArticulo(item.IdIntelisis).ConfigureAwait();
                                if (costo is not null)
                                    item.Costo = Convert.ToDouble(item.IdPlantel == 2 ? costo.Precio2 : item.IdPlantel == 1 ? costo.Precio3 : item.IdPlantel == 5 ? costo.Precio4 : item.IdPlantel == 4 ? costo.Precio5 : 0);
                            }
                            catch (Exception)
                            {

                                throw;
                            }
                            
                        }

                        using (var entidadTalleres2 = new colegioContext())
                        {
                            try
                            {
                                entidadTalleres2.Entry(item).State = EntityState.Modified;
                                await entidadTalleres2.SaveChangesAsync();
                            }
                            catch (Exception)
                            {

                                throw;
                            }
                            
                        }
                    }
                }
            }
            return true;
        }

        public async Task<bool> ProcessAlumns()
        {
            string[] situaciones = new string[] { "EGRESADO", "ACEPTADO", "BAJA", "BAJA CON ADEUDO", "INTERCAMBIO ALEMANIA" };
            List<TblCatAlumno> alumnos = new();
            using (var entidadAlumnos = new colegioContext())
                alumnos = await entidadAlumnos.TblCatAlumnos.ToListAsync();
            var matriculas = alumnos.Select(x => x.IdAlumno.ToString()).ToList();
            var alumnosIntelisis = await this.intelisisUserStory.GetAlumnos().ConfigureAwait();
            var filtraAlumnosExistentes = alumnosIntelisis.Where(x => matriculas.Contains(x.Alumno)).ToList();
            var filtraAlumnosNoExistentes = alumnosIntelisis.Where(x => !matriculas.Contains(x.Alumno) && x.Estatus == "ALTA" && !situaciones.Contains(x.Situacion) && !x.Nombre.Contains("Prueba")).ToList();
            string cicloActivo = await this.intelisisUserStory.GetCicloEscolarActivo().ConfigureAwait();
            foreach (var item in filtraAlumnosNoExistentes)
            {
                int idFamilia = 0;
                int idNivelAcademico = 0;
                int idPrograma = 0;
                try
                {
                    using (var entidadAlumnos = new colegioContext())
                    {
                        var buscaFamilia = await entidadAlumnos.TblCatFamilia.FirstOrDefaultAsync(x => x.Familia == Convert.ToInt32(item.Familia)).ConfigureAwait();
                        if (buscaFamilia is null)
                        {
                            var familia = new TblCatFamilium
                            {
                                Activo = true,
                                IdUsuario = 3,
                                Familia = Convert.ToInt32(item.Familia),
                                FechaCreacion = DateTime.Now
                            };
                            entidadAlumnos.TblCatFamilia.Add(familia);
                            await entidadAlumnos.SaveChangesAsync().ConfigureAwait();
                            idFamilia = familia.Id;
                        }
                        else
                        {
                            idFamilia = buscaFamilia.Id;
                        }
                    }
                    if (item.Programa is null) continue;
                    using (var entidadAlumnos = new colegioContext())
                    {
                        idNivelAcademico = (await entidadAlumnos.TblCatNivelAcademicos.FirstOrDefaultAsync(x => x.Nivel == item.NivelAcademico).ConfigureAwait()).Id;
                        idPrograma = (await entidadAlumnos.TblCatProgramas.FirstOrDefaultAsync(x => x.Programa == item.Programa).ConfigureAwait()).Id;
                    }
                    TblCatAlumno alumno = new()
                    {
                        Activo = true,
                        Adeudo = false,
                        ApellidoMaterno = item.ApellidoMaterno,
                        ApellidoPaterno = item.ApellidoPaterno,
                        FechaCreacion = DateTime.Now,
                        FechaNacimiento = item.FechaNacimiento,
                        Grupo = item.Grupo ?? "X",
                        IdAlumno = Convert.ToInt32(item.Alumno),
                        IdClicloEscolar = 1,
                        IdEstatus = 1,
                        IdFamilia = idFamilia,
                        IdGenero = item.Genero == "Femenino" ? 1 : 2,
                        IdNivelAcademico = idNivelAcademico,
                        IdPrograma = idPrograma,
                        IdSituacion = 1,
                        Nombre = item.Nombre,
                        Ruta = false,
                        IdPlantel = item.Sucursal == 3 ? 1 : item.Sucursal == 2 ? 2 : item.Sucursal == 1 ? 3 : item.Sucursal == 0 ? 4 : item.Sucursal == 4 ? 5 : 1
                    };

                    using (var entidadAlumnos = new colegioContext())
                    {
                        entidadAlumnos.TblCatAlumnos.Add(alumno);
                        await entidadAlumnos.SaveChangesAsync();
                    }
                }
                catch (Exception)
                {
                }

            }

            foreach (var item in filtraAlumnosExistentes)
            {
                
                int idNivelAcademico = 0;
                int idPrograma = 0;
                var al = item;
                using (var entidadAlumnos = new colegioContext())
                {
                    idNivelAcademico = (await entidadAlumnos.TblCatNivelAcademicos.FirstOrDefaultAsync(x => x.Nivel == item.NivelAcademico).ConfigureAwait()).Id;
                    if (item.Programa is null) continue;
                    idPrograma = (await entidadAlumnos.TblCatProgramas.FirstOrDefaultAsync(x => x.Programa == item.Programa).ConfigureAwait()).Id;
                }
                var alumn = alumnos.Where(x => x.IdAlumno == Convert.ToInt32(item.Alumno));
                if (!alumn.Any()) continue;
                foreach (var a in alumn)
                {
                    a.Grupo = item.Grupo ?? "X";
                    a.Nombre = item.Nombre;
                    a.ApellidoPaterno = item.ApellidoPaterno;
                    a.ApellidoMaterno = item.ApellidoMaterno;
                    a.IdNivelAcademico = idNivelAcademico;
                    a.IdPrograma = idPrograma;
                    a.IdPlantel = item.Sucursal == 3 ? 1 : item.Sucursal == 2 ? 2 : item.Sucursal == 1 ? 3 : item.Sucursal == 0 ? 4 : item.Sucursal == 4 ? 5 : 1;
                    if (item.Estatus != "ALTA" || situaciones.Contains(item.Situacion) || item.CicloEscolar != cicloActivo)
                        a.Activo = false;
                    else
                        a.Activo = true;
                    using (var entidadAlumnos = new colegioContext())
                    {
                        entidadAlumnos.Entry(a).State = EntityState.Modified;
                        entidadAlumnos.SaveChanges();
                    }
                }
               
            }

            return true;
        }
    }
}
