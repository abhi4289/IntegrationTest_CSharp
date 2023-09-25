using Microsoft.AspNetCore.Mvc;

public class WeatherController : ControllerBase
{
    [HttpGet]
    public string Get()
    {
        return "Hello World!";
    }
}