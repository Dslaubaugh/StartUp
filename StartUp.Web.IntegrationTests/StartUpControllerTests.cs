using StartUp.Web.controllers;
using StartUp.Web.database;
using StartUp.Web.models;
using StartUp.Web.services;

namespace StartUp.IntegrationTests;

public class StartUpControllerTests
{
    private AppSettings _appSettings;
    private DBConnectionFactory _connectionFactory;
    private StartUpDBContext _dbContext;
    private StartUpService _service;
    private StartUpController _controller;

    public StartUpControllerTests()
    {
        _appSettings = new AppSettings
        {
            StartUpDBConnection = new DatabaseConnection
            {
                UserName = "postgres",
                Password = "postgres",
                Name = "start-up-local",
                Hostname = "localhost:5432"
            }
        };
        _connectionFactory = new DBConnectionFactory(_appSettings);
        _dbContext = new StartUpDBContext(_connectionFactory);
        _service = new StartUpService(_dbContext);
        _controller = new StartUpController(_service);
    }

    [Fact (Skip = "failing pipeline")]
    public async Task Test1()
    {
        var insertValues = new InsertValues
        {
            UIValue = "taco",
            Language = "English",
            ButtonClick = true,
            FavoriteNumber = 15,
            Date = DateTime.Now
        };
        var actual = await _controller.InsertIntoTable(insertValues);

        actual.Should().NotBeEmpty();
    }
}