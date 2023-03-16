namespace Blazor_Session_Provider;

public class StateSession
{
    public Model? User { get; set; }

    public bool IsLoggedIn { get; set; }

    public void Load(Model? user)
    {
        User = user;
        StateChanged();
    }


    public event Action? OnChange;
    public void StateChanged() => OnChange?.Invoke();

    public class Model
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
