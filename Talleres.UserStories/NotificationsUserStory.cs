using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talleres.Infraestructure.DataBase.Context;
using Talleres.Intefaces.DataBase.Context;
using Talleres.Intefaces.UserStories;
using Talleres.Models.Request;

namespace Talleres.UserStories
{
    public class NotificationsUserStory : UserStoryBase, INotificationUserStory
    {
        private IGlobalContext<Cealumno> entidad;
        public NotificationsUserStory(IGlobalContext<Cealumno> entidad)
        {
            this.entidad = RegisterForDispose(entidad);
        }
        public async Task Confirmation(Alumno alumno)
        {
            int natacion = 0;
            foreach (var item in alumno.Inscripcion)
            {
                using (var entidadAlumnos = new colegioContext()) {

                    var consultaPago = entidadAlumnos.TblPagosIntelises.FirstOrDefault(x => x.IdCiclo == alumno.idCliclo && x.IdAlumno == item.IdAlumno && x.IdTaller == item.IdTaller);
                    var matricula = alumno.Matricula.ToString().Length == 1 ? $"000000{alumno.Matricula}" : alumno.Matricula.ToString().Length == 2 ? $"00000{alumno.Matricula}" : alumno.Matricula.ToString();
                    if (alumno.Sucursal == 3 && alumno.IdNivelAcademico < 3 && consultaPago is null)
                    {
                        List<int> idsNatacion = new() { 7948, 7965 };
                        var buscaNatacion = alumno.Inscripcion.Where(x => idsNatacion.Contains(x.IdTaller)).ToList();
                        if (buscaNatacion.Count > 1 && idsNatacion.Contains(item.IdTaller))
                        {
                            if (natacion > 0) {
                                foreach (var dia in item.Dias)
                                {
                                    var articulo = dia.IdDia == 1 ? "5104" : dia.IdDia == 2 ? "5105" : dia.IdDia == 3 ? "5106" : dia.IdDia == 5 ? "5107" : "";
                                    await this.entidad.Exec($"EXEC xpGenerarPedidosAlumnoPIT @Alumno='{matricula}', @Sucursal={alumno.Sucursal}, @Articulo='{articulo}'").ConfigureAwait();
                                }
                                entidadAlumnos.TblPagosIntelises.Add(new TblPagosIntelisi
                                {
                                    IdAlumno = item.IdAlumno,
                                    IdTaller = item.IdTaller,
                                    IdCiclo = alumno.idCliclo,
                                    FechaCreacion = DateTime.Now
                                });
                                await entidadAlumnos.SaveChangesAsync().ConfigureAwait();
                                continue;
                            }
                            item.IdIntelisis = "5276";
                            natacion++;
                        }
                    }
                    

                    if (consultaPago is null)
                    {
                        
                        if (alumno.Sucursal == 1)
                            await this.entidad.Exec($"EXEC TallerAlumnoPIT @Alumno='{matricula}', @Sucursal={alumno.Sucursal}, @Articulo='{item.IdIntelisis}'").ConfigureAwait();
                        else
                            await this.entidad.Exec($"EXEC xpGenerarPedidosAlumnoPIT @Alumno='{matricula}', @Sucursal={alumno.Sucursal}, @Articulo='{item.IdIntelisis}'").ConfigureAwait();

                        if(alumno.IdNivelAcademico < 3 && alumno.Sucursal != 1)
                        {
                            foreach (var dia in item.Dias)
                            {
                                var articulo = dia.IdDia == 1 ? "5104" : dia.IdDia == 2 ? "5105" : dia.IdDia == 3 ? "5106" : dia.IdDia == 5 ? "5107" : "";
                                await this.entidad.Exec($"EXEC xpGenerarPedidosAlumnoPIT @Alumno='{matricula}', @Sucursal={alumno.Sucursal}, @Articulo='{articulo}'").ConfigureAwait();
                            }
                            
                        }

                        entidadAlumnos.TblPagosIntelises.Add(new TblPagosIntelisi
                        {
                            IdAlumno = item.IdAlumno,
                            IdTaller = item.IdTaller,
                            IdCiclo = alumno.idCliclo,
                            FechaCreacion = DateTime.Now
                        });
                        await entidadAlumnos.SaveChangesAsync().ConfigureAwait();
                    }
                }
            }


            using (var entidadAlumnos = new colegioContext())
            {
                var existe = entidadAlumnos.TblConfirmaciones.FirstOrDefault(x => x.IdAlumno == alumno.idAlumno && x.IdCiclo == alumno.idCliclo);
                if (existe is null)
                {
                    entidadAlumnos.TblConfirmaciones.Add(new TblConfirmacione
                    {
                        IdAlumno = alumno.idAlumno,
                        Descuento = false,
                        Monto = alumno.Inscripcion.Sum(x => x.Costo),
                        IdCiclo = alumno.idCliclo,
                        FechaCreacion = DateTime.Now
                    });
                    await entidadAlumnos.SaveChangesAsync().ConfigureAwait();
                }
            }

        }
        
    }
}
