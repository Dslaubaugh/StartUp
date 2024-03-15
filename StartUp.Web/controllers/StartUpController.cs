using Microsoft.AspNetCore.Mvc;
using StartUp.Web.models;
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
    
    [HttpPost("insert")]
    public async Task<Guid> InsertIntoTable([FromBody] InsertValues values)
    {
        return await _startupService.InsertIntoTable(values);
    }
}