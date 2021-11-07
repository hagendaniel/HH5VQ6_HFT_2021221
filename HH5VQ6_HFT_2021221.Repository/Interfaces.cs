using HH5VQ6_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH5VQ6_HFT_2021221.Repository
{
    public interface IRepository<T> where T : class
    {
        T GetOne(int id);
        IQueryable<T> GetAll();
    }

    public interface IMapRepository : IRepository<Map>
    {
        void addMap(string mapName, int difficulty);
        void removeMap(int id);
        void renameMap(int id, string newName);
    }

    public interface IPlaceRepository : IRepository<Place>
    {
        void addPlace(string placeName, string country);
        void removePlace(int id);
        void changePlace(int id, string newPlace);
    }

    public interface IPlayerRepository : IRepository<Player>
    {
        void registerNewPlayer(Player newPlayer);
        void removePlayer(int id);
        void changeStatus(int id, bool newStatus, string eliminatedOnMap);
        void customId(int id, int customId);
    }

    public interface ISeasonRepository : IRepository<Season>
    {
        void newSeason(string seasonName, int placeId);
        void removeSeason(int id);
        void changeName(int id, string newName);
    }
}
