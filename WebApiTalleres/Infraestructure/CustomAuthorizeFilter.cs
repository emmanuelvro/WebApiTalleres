using Hangfire.Annotations;
using Hangfire.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTalleres.Infraestructure
{
    public class CustomAuthorizeFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            //var httpcontext = context.GetHttpContext();
            //return httpcontext.User.Identity.IsAuthenticated;
            return true;
        }
    }
}
