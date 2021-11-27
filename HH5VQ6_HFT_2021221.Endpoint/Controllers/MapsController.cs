using HH5VQ6_HFT_2021221.Logic;
using HH5VQ6_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HH5VQ6_HFT_2021221.Endpoint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MapsController : ControllerBase
    {
        /*private readonly*/ IMapLogic _mapLogic;

        public MapsController(IMapLogic mapLogic)
        {
            _mapLogic = mapLogic;
        }

        [HttpGet]
        public IEnumerable<Map> GetMaps()
        {
            var maps = _mapLogic.getAllMaps();

            return maps;
        }

        [HttpGet("{id}")]
        public Map Get(int id)
        {
            return _mapLogic.getMapById(id);
        }

        [HttpPost]
        public void Post([FromBody] Map map)
        {
            _mapLogic.addMap(map);
        }

        [HttpPut]
        public void Put([FromBody] Map map)
        {
            _mapLogic.renameMap(map.MapId, map.MapName);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _mapLogic.deleteMap(id);
        }

        //[HttpPost]
        //public IActionResult AddMap([FromBody] Map map)
        //{
        //    _mapLogic.addMap(map);

        //    return Ok();
        //}

        [HttpGet("thekillermap/{seasonname}")]
        public Map TheKillerMap(string seasonName)
        {
            return _mapLogic.TheKillerMap(seasonName);
        }
    }
}
