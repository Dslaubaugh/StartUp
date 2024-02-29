using FluentAssertions;
using JetBrains.Annotations;
using NSubstitute;
using StartUp.Web.controllers;
using StartUp.Web.services;

namespace StartUp.Web.UnitTests.controllers;

[TestSubject(typeof(StartUpController))]
public class StartUpControllerTest
{
    private IStartUpService _startUpService;
    private StartUpController _controller;

    public StartUpControllerTest()
    {
        _startUpService = Substitute.For<IStartUpService>();
        _controller = new StartUpController(_startUpService);
    }

    [Fact]
    public async Task ShouldGreetYou()
    {
        var expected = "hello there";
        _startUpService.GetGreeting().Returns(expected);

        var actual = await _controller.Obiwan();

        actual.Should().BeEquivalentTo(expected);
    }
}