using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SqlSugar.Template.Models;
using SqlSugar.Template.Repository;
using SqlSugar.Template.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SqlSugar.Template.Controllers
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
        public SysJobLogService _sysJobLogService { get; set; }

        public WeatherForecastController(ILogger<WeatherForecastController> logger, SysJobLogService sysJobLogService)
        {
            _logger = logger;
            _sysJobLogService = sysJobLogService;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> GetAsync()
        {
            //var list = _order.GetOrders();
            int page = 1;
            int intPageSize = 50;
            var data = await _sysJobLogService.QueryById(10);

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
