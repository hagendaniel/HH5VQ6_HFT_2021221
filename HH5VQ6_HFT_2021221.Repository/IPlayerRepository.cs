using HH5VQ6_HFT_2021221.Models;

namespace HH5VQ6_HFT_2021221.Repository
{
    public interface IPlayerRepository : IRepository<Player>
    {
        void registerNewPlayer(Player newPlayer);
        void removePlayer(int id);
        void changeStatus(int id, bool newStatus, string eliminatedOnMap);
        void customId(int id, int customId);
    }
}
