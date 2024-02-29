namespace StartUp.Web.services;

public interface IStartUpService
{
    string GetGreeting();
}

public class StartUpService : IStartUpService
{
    public string GetGreeting()
    {
        return "Hello there";
    }
}