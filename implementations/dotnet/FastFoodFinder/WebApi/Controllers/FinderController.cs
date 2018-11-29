using Engine;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinderController : ControllerBase
    {
        private readonly IFinderEngine _finderEngine;

        public FinderController(IFinderEngine finderEngine)
        {
            _finderEngine = finderEngine ?? throw new ArgumentNullException(nameof(finderEngine));
        }

        [HttpPost]
        public IActionResult Post([FromBody] FindRequest request)
        {
            var results = _finderEngine.FindMenu(request.Location, request.Food);

            return Ok(results);
        }
    }
}
