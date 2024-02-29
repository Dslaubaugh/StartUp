using Microsoft.AspNetCore.Mvc;
using StartUp.Web.services;

namespace StartUp.Web.controllers;


public class StartUpController : ControllerBase
{
    private readonly IStartUpService _startupService;

    public StartUpController(IStartUpService startUpService)
    {
        _startupService = startUpService;
    }

    [HttpGet("hi")]
    public async Task<string> Obiwan()
    {
        return _startupService.GetGreeting();
    }
}