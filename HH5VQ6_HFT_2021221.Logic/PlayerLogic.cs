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

        public PlayerLogic(IPlayerRepository repository)
        {
            this.playerRepository = repository;
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
    }
}
