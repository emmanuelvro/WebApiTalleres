using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talleres.Infraestructure.DataBase.Context;
using Talleres.Intefaces.UserStories;
using Talleres.Models;

namespace WebApiTalleres.Controllers
{
    [ApiController]
    public class IntelisisController : ControllerBase
    {
        private ISyncUserStory<Cealumno> alumnoUserStory;
        private IRecurringJobManager recurringJobManager;
        public IntelisisController(
            ISyncUserStory<Cealumno> alumnoUserStory,
            IRecurringJobManager recurringJobManager)
        {
            this.alumnoUserStory = alumnoUserStory;
            this.recurringJobManager = recurringJobManager;
        }

        [HttpGet("api/intelisis/syncAlumns")]
        public async Task<IActionResult> SyncAlumns()
        {
            return Ok(await this.alumnoUserStory.ProcessAlumns().ConfigureAwait());
        }

        [HttpGet("api/intelisis/syncPrices")]
        public async Task<IActionResult> SyncPrices()
        {
            return Ok(await this.alumnoUserStory.ProcessCost().ConfigureAwait());
        }

        [HttpPost]
        [Route("api/intelisis/schedule")]
        public ActionResult<string> Schedule([FromBody] Scheduler scheduler)
        {
            if (scheduler == null) return this.BadRequest();
            switch (scheduler.Value)
            {
                case 1:
                    this.recurringJobManager.AddOrUpdate(scheduler.JobName, () => this.alumnoUserStory.ProcessAlumns(), cronExpression: scheduler.CronExp);
                    break;
                case 2:
                    this.recurringJobManager.AddOrUpdate(scheduler.JobName, () => this.alumnoUserStory.ProcessCost(), cronExpression: scheduler.CronExp);
                    break;
            }
            
            return this.Ok();
        }

    }
}
