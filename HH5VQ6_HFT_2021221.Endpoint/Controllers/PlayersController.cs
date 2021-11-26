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
    public class PlayersController
    {
        IPlayerLogic playerLogic;

        public PlayersController(IPlayerLogic playerLogic)
        {
            this.playerLogic = playerLogic;
        }

        [HttpGet]
        public IEnumerable<Player> GetPlayers()
        {
            var players = playerLogic.getAllPlayers();
            return players;
        }

        [HttpGet("{id}")]
        public Player Get(int id)
        {
            return playerLogic.getPlayerById(id);
        }

        [HttpPost]
        public void Post([FromBody] Player player)
        {
            playerLogic.registerNewPlayer(player);
        }

        [HttpPut]       //------------------------------------------------------------------
        public void Put([FromBody] Player player)
        {
            playerLogic.changeStatus(player.PlayerId, player.AliveOrDead, Convert.ToInt32(player.EliminatedOnMap_MapId));
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            playerLogic.removePlayer(id);
        }
    }
}
