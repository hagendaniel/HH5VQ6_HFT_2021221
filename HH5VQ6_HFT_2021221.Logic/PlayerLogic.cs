using HH5VQ6_HFT_2021221.Models;
using HH5VQ6_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH5VQ6_HFT_2021221.Logic
{
    public class PlayerLogic : IPlayerLogic
    {
        IPlayerRepository playerRepository;
        ISeasonRepository seasonRepository;

        public PlayerLogic(IPlayerRepository repository, ISeasonRepository _seasonRepository)
        {
            this.playerRepository = repository;
            seasonRepository = _seasonRepository;
        }

        public void changeStatus(int id, bool newStatus, string eliminatedOnMap)
        {
            playerRepository.changeStatus(id, newStatus, eliminatedOnMap);
        }

        public void customId(int id, int customId)
        {
            playerRepository.customId(id, customId);
        }

        public IList<Player> getAllPlayers()
        {
            return playerRepository.GetAll().ToList();
        }

        public Player getPlayerById(int id)
        {
            return playerRepository.GetOne(id);
        }

        public void registerNewPlayer(string name, DateTime dateTime, int debt)
        {
            playerRepository.registerNewPlayer(new Player() { PlayerName = name, Born = dateTime, Debt = debt });
        }

        public void removePlayer(int id)
        {
            playerRepository.removePlayer(id);
        }

        //non-crud

        public Player whoWonGivenSeason(int seasonId)
        {
            Season season = seasonRepository.GetAll().Where(x => x.SeasonId == seasonId).SingleOrDefault();
            Player toReturn = season.Players.Where(x => x.AliveOrDead == true).SingleOrDefault();
            //var player = seasonRepository.GetAll().Where(x => x.SeasonId==seasonId).Where(x => x.Players.Any(x => x.AliveOrDead==true)).FirstOrDefault();
            return toReturn;
        }
    }
}
