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
    public class SeasonsController
    {
        ISeasonLogic seasonLogic;

        public SeasonsController(ISeasonLogic seasonLogic)
        {
            this.seasonLogic = seasonLogic;
        }

        [HttpGet]
        public IEnumerable<Season> GetSeasons()
        {
            var seasons = seasonLogic.getAllSeasons();
            return seasons;
        }

        [HttpGet("{id}")]
        public Season Get(int id)
        {
            return seasonLogic.getSeasonById(id);
        }

        [HttpPost]
        public void Post([FromBody] Season season)
        {
            seasonLogic.newSeason(season);
        }

        [HttpPut]
        public void Put([FromBody] Season season)
        {
            seasonLogic.changeName(season.SeasonId, season.SeasonNickname);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            seasonLogic.removeSeason(id);
        }
    }
}
