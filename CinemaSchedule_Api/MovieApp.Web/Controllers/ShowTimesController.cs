using Microsoft.AspNetCore.Mvc;
using MovieApp.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShowTimesController : ControllerBase
    {
        private readonly IShowTimeService showTimeService;

        public ShowTimesController(IShowTimeService showTimeService)
        {
            this.showTimeService = showTimeService;
        }

        [HttpGet("GetDates")]
        public async Task<IActionResult> GetDates()
        {
            var dates = await showTimeService.GetDatesAsync();
            if (dates == null)
                return NotFound();

            return Ok(dates);
        }

        [HttpGet("GetTimes")]
        public async Task<IActionResult> GetTimes(string _date, int id)
        {
            var times = await showTimeService.GetTimesAsync(_date, id);
            if (times == null)
                return NotFound();

            return Ok(times);
        }
    }
}