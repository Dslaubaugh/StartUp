using FluentAssertions;
using JetBrains.Annotations;
using NSubstitute;
using StartUp.Web.database;
using StartUp.Web.models;
using StartUp.Web.services;

namespace StartUp.Web.UnitTests.services;

[TestSubject(typeof(StartUpService))]
public class StartUpServiceTest
{
    private StartUpService _service;
    private IStartUpDBContext _dbContext;

    public StartUpServiceTest()
    {
        _dbContext = Substitute.For<IStartUpDBContext>();
        _service = new StartUpService(_dbContext);
    }

    [Fact]
    public async Task ShouldInsertValuesIntoDb()
    {
        var insertValues = new InsertValues
        {
            UIValue = "value",
            Language = "english",
            ButtonClick = false,
            FavoriteNumber = 14,
            Date = DateTime.Now
        };
        var expected = new Guid();
        _dbContext.InsertIntoTable(insertValues).Returns(expected);

        var actual =await _service.InsertIntoTable(insertValues);

        actual.Should().Be(expected);
    }
}