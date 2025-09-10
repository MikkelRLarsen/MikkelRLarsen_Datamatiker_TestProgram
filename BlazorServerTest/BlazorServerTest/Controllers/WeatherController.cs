using Microsoft.AspNetCore.Mvc;

namespace BlazorServerTest.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class WeatherController : ControllerBase
	{
		[HttpGet]
		public IActionResult GetWeather()
		{
			var weatherData = new[]
			{
				new { Date = DateTime.Now, TemperatureC = 25, Summary = "Sunny" },
				new { Date = DateTime.Now.AddDays(1), TemperatureC = 22, Summary = "Cloudy" }
			};

			return Ok(weatherData);
		}
	}
}
