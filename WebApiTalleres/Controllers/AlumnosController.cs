using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talleres.Infraestructure.DataBase.Context;
using Talleres.Intefaces.UserStories;
using Talleres.Models.Response;
using Talleres.UserStories;

namespace WebApiTalleres.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosController : ApiControllerBase<IAlumnoUserStory<TblAlumno>>
    {
        public AlumnosController(
            IAlumnoUserStory<TblAlumno> userHistory, 
            ILogger<IAlumnoUserStory<TblAlumno>> logger
            ) : base(userHistory, logger)
        {

        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(TblAlumno))]
        public async Task<IActionResult> Get()
        {
            return GetActionResult(await this.UserHistory.Get().ConfigureAwait());
        }
    }
}
