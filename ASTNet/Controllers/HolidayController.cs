using ASTNet.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASTNet.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/holidays")]
    public class HolidayController : ControllerBase
    {
        private readonly IHolidayService _holidayService;

        public HolidayController(IHolidayService holidayService)
        {
            _holidayService = holidayService;
        }

        [Authorize]
        [HttpGet("{year}/{countryCode}")]
        public async Task<IActionResult> Get(int year, string countryCode)
        {
            var url = $"https://date.nager.at/api/v3/PublicHolidays/{year}/{countryCode}";
            var data = await _holidayService.GetHolidaysAsync(year, countryCode);

            return Ok(new
            {
                url,
                method = "GET",
                response = data
            });
        }
    }
}
