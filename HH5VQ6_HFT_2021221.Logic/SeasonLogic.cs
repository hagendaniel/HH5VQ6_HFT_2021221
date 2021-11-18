using HH5VQ6_HFT_2021221.Models;
using HH5VQ6_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HH5VQ6_HFT_2021221.Logic
{
    public class SeasonLogic : ISeasonLogic
    {
        ISeasonRepository seasonRepository;
        IPlaceRepository placeRepository;

        public SeasonLogic(ISeasonRepository repository, IPlaceRepository _placeRepository)
        {
            this.seasonRepository = repository;
            placeRepository = _placeRepository;
        }

        public void changeName(int id, string newName)
        {
            seasonRepository.changeName(id, newName);
        }

        public IList<Season> getAllSeasons()
        {
            return seasonRepository.GetAll().ToList();
        }

        public Season getSeasonById(int id)
        {
            return seasonRepository.GetOne(id);
        }

        public void newSeason(string seasonName, int placeId)
        {
            seasonRepository.newSeason(seasonName, placeId);
        }

        public void removeSeason(int id)
        {
            seasonRepository.removeSeason(id);
        }

        public string whichSeasonGame(string placeName) //In which season was the game hold in the given city first
        {
            ICollection<Season> seasons = seasonRepository.GetAll().ToList();
            IQueryable<Place> places = placeRepository.GetAll();

            Place place = places.Where(x => x.PlaceName == placeName).FirstOrDefault();
            place.Seasons = seasons.Where(x => x.PlaceId == place.PlaceId).ToList();

            //int toReturn = place.PlaceId;
            string toReturn = seasons.Where(x => x.PlaceId == place.PlaceId).Select(x =>x.SeasonNickname).FirstOrDefault();

            if (place is null)
                throw new InvalidPlaceException();
            else
                return toReturn;
        }
    }
}
