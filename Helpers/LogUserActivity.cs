using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Helper.API.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace Helper.API.Helpers
{
    public class LogUserActivity: IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var resultContext = await next();

            var userId = int.Parse(resultContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var repo = resultContext.HttpContext.RequestServices.GetService<IHelperRepository>();
            var user = await repo.GetUser(userId);

            user.OstatniaAktywnosc = DateTime.Now;
            await repo.SaveAll();
        }        
    }
}