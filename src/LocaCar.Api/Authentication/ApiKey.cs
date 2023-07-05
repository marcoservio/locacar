using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LocaCar.Api.Authentication
{
    public class ApiKey : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();

            if (!context.HttpContext.Request.Headers.TryGetValue(configuration["API_KEY_NAME"], out var extractedApiKey))
            {
                context.Result = new UnauthorizedObjectResult("API Key missing");
                return;
            }

            if (!configuration["API_KEY"].Equals(extractedApiKey))
            {
                context.Result = new UnauthorizedObjectResult("Invalid API Key");
                return;
            }
        }
    }
}
