using ASTNet.Models.Requests;
using ASTNet.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASTNet.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/rank")]
    public class RankController : ControllerBase
    {
        private readonly IRankService _rankService;

        public RankController(IRankService rankService)
        {
            _rankService = rankService;
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] RankRequest request)
        {
            if (string.IsNullOrEmpty(request.p1))
                return BadRequest("p1 is required");

            if (request.p1.Length > 99)
                return BadRequest("p1 length must not exceed 99 characters");

            var result = _rankService.ProcessRank(request.p1);
            return Ok(result);
        }
    }
}
