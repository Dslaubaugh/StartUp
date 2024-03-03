using StartUp.Web.database;
using StartUp.Web.models;

namespace StartUp.Web.services;

public interface IStartUpService
{
    string GetGreeting();
    Task<Guid> InsertIntoTable(InsertValues values);
}

public class StartUpService : IStartUpService
{
    private IStartUpDBContext _startUpDbContext;

    public StartUpService(IStartUpDBContext dbContext)
    {
        _startUpDbContext = dbContext;
    }

    public string GetGreeting()
    {
        return "Hello there";
    }

    public Task<Guid> InsertIntoTable(InsertValues values)
    {
        return _startUpDbContext.InsertIntoTable(values);
    }
}