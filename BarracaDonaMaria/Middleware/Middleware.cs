using BarracaDonaMaria.Infrastructure.Services;

namespace BarracaDonaMaria.Middleware;
public class Middleware
{
    private readonly RequestDelegate next;

    public Middleware(RequestDelegate next) =>
        this.next = next;

    public async Task Invoke(HttpContext httpContext)
    {
        NHibernateHelper.BeginTransaction();

        await next(httpContext);

        if (httpContext.Response.StatusCode >= 200 && httpContext.Response.StatusCode < 300)
        {
            await NHibernateHelper.CommitAsync();
            return;
        }
        await NHibernateHelper.RollbackAsync();
    }
}
