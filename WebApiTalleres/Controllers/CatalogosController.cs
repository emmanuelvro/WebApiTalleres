using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talleres.Infraestructure.DataBase.Context;
using Talleres.Intefaces.UserStories;

namespace WebApiTalleres.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogosController : ControllerBase
    {
        private INivelesAcademicoUStory<TblNivelesAcademico> nivelesUS;
        private IProgramasUserStory<TblPrograma> programasUS;
        private IGenerosUserStory<TblGenero> generosUS;
        public CatalogosController(
            INivelesAcademicoUStory<TblNivelesAcademico> nivelesUS,
            IProgramasUserStory<TblPrograma> programasUS,
            IGenerosUserStory<TblGenero> generosUS
            )
        {
            this.nivelesUS = nivelesUS;
            this.programasUS = programasUS;
            this.generosUS = generosUS;
        }
        [HttpGet]
        [Route("niveles")]
        [ProducesResponseType(200, Type = typeof(TblNivelesAcademico))]
        public async Task<IActionResult> GetNiveles()
        {
            return new OkObjectResult(await this.nivelesUS.Get().ConfigureAwait());
        }

        [HttpGet]
        [Route("programas")]
        [ProducesResponseType(200, Type = typeof(TblPrograma))]
        public async Task<IActionResult> GetProgramas()
        {
            return new OkObjectResult(await this.programasUS.Get().ConfigureAwait());
        }

        [HttpGet]
        [Route("programasByNivel/{nivel}")]
        [ProducesResponseType(200, Type = typeof(TblPrograma))]
        public async Task<IActionResult> GetProgramasByNivel(int nivel)
        {
            return new OkObjectResult(await this.programasUS.GetByNivel(nivel).ConfigureAwait());
        }

        [HttpGet]
        [Route("generos")]
        [ProducesResponseType(200, Type = typeof(TblGenero))]
        public async Task<IActionResult> GetGeneros()
        {
            return new OkObjectResult(await this.generosUS.Get().ConfigureAwait());
        }
    }
}
