using BCP.Identity.API.Provider;

namespace BCP.Identity.API.Middleware
{
    public class AdUserMiddleware
    {
       private readonly RequestDelegate next;
         
        public AdUserMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
         
        public async Task Invoke(HttpContext context, IAdUserProvider userProvider, IConfiguration config)
        {
            if (!userProvider.Initialized)
            {
                await userProvider.Create(context, config);
            }
             
            await next(context);
        }  
    }
}