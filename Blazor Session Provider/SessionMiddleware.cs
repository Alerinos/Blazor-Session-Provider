using System.Reflection;

namespace Blazor_Session_Provider;

public class SessionMiddleware
{
    private readonly RequestDelegate _next;

    public SessionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, Session sessionService)
    {
        var sessionName = sessionService.SessionName;
        var sessionValue = context.Request.Cookies[sessionName];

        // Initialize session, send token
        await sessionService.InitializationAsync(sessionValue);

        await _next(context);
    }
}

public static class SessionMiddlewareExtensions
{
    public static IApplicationBuilder UseIdentitySession(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<SessionMiddleware>();
    }
}