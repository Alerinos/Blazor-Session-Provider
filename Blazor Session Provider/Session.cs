namespace Blazor_Session_Provider;

public class Session
{
    readonly StateSession _session;

    public string SessionName { get; set; } = "Session";

    public Session(StateSession session)
        => (_session) = (session);

    public Task InitializationAsync(string? token)
    {
        if (token is null)
            return Task.CompletedTask;

        _session.Load(new() { Name = "Alerin" });

        return Task.CompletedTask;
    }
}
