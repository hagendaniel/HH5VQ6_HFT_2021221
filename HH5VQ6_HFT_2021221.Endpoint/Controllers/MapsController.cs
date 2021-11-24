using HH5VQ6_HFT_2021221.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HH5VQ6_HFT_2021221.Endpoint.Controllers
{
    [ApiController]
    [Route("Maps")]
    public class MapsController : ControllerBase
    {
        private readonly IMapLogic _mapLogic;

        public MapsController(IMapLogic mapLogic)
        {
            _mapLogic = mapLogic;
        }

        [HttpGet]
        public IActionResult GetMaps()
        {
            var maps = _mapLogic.getAllMaps();

            return Ok(maps);
        }

        [HttpPost]
        public IActionResult AddMap([FromBody] string mapName, int difficulty)
        {
            _mapLogic.addMap(mapName, difficulty);

            return Ok();
        }
    }
}
