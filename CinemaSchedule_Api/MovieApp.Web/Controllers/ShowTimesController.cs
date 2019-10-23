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
            return Ok(await showTimeService.GetDates());
        }

        [HttpGet("GetTimes")]
        public async Task<IActionResult> GetTimes(string _date, int id)
        {
            return Ok(await showTimeService.GetTimes(_date, id));
        }
    }
}