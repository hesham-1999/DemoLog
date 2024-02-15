using DemoLog.Controllers.Request;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using System.Drawing;

namespace DemoLog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IConfiguration _config;

        public WeatherForecastController(ILogger<WeatherForecastController> logger , IConfiguration configuration)
        {
            _logger = logger;
            this._config = configuration;
        }
        private async Task<string> WriteFile(IFormFile file)
        {
            var Extention ="."+ file.FileName.Split(".")[1];
            var currentDirectory = Directory.GetCurrentDirectory();
            var FileName = Guid.NewGuid().ToString() + Extention;
            var path = Path.Combine(currentDirectory, @"wwwroot\Upload\\Files" , FileName);    

            if(!Directory.Exists(currentDirectory))
            {
                Directory.CreateDirectory(currentDirectory);
            }
         
            using (var stream = new FileStream(path, FileMode.CreateNew))
            {
                await file.CopyToAsync(stream);
            }

            return path;
        }
        

        [HttpPost]
    
        public async Task<IActionResult> UploadFile([FromForm]FileUpload fileUploadRequest)
        {
            var path = _config.GetSection("FilePath:Path").Value;
            if (fileUploadRequest.File.Length > 0)
            {
                var result = await WriteFile(fileUploadRequest.File);
                return Ok(new
                {
                    message = "File Created Successfuly",
                    path  = result

                });
            }
            return BadRequest("Invalid File Data ");
        }

        [HttpGet()]
        [Route("DownloadFile")]
        public async Task<IActionResult> DownloadFile(string fileName)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var path = Path.Combine(currentDirectory, @"wwwroot\\Upload\\Files", fileName);
            var bytes = await System.IO.File.ReadAllBytesAsync(path);
            var provider = new FileExtensionContentTypeProvider();
            if(!provider.TryGetContentType(fileName, out var contentType))
            {
                contentType = "application/octet-stream";
            }
            return File(bytes,contentType,Path.GetFileName(path));
        }
   
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();
            int x = 15;
            _logger.LogInformation("Start Ation Get info");
            _logger.LogInformation("print data {@result}",result);
            _logger.LogInformation("print data {x}",x);

            _logger.LogWarning("Start Ation Get warrinig ");
            _logger.LogError("Start Ation Get error");
            _logger.LogCritical("Start Ation Get critical ");
            return result;
        }
    }
}
