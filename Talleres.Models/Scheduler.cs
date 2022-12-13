using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talleres.Models
{
    public class Scheduler
    {
        public string JobName { get; set; }

        public string CronExp { get; set; }

        public int Value { get; set; }
    }
}
