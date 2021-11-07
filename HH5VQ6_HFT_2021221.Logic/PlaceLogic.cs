using HH5VQ6_HFT_2021221.Models;
using HH5VQ6_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH5VQ6_HFT_2021221.Logic
{
    public class PlaceLogic : IPlaceLogic
    {
        IPlaceRepository placeRepository;

        public PlaceLogic(IPlaceRepository repository)
        {
            this.placeRepository = repository;
        }

        public void addPlace(string placeName, string country)
        {
            placeRepository.addPlace(placeName, country);
        }

        public void changePlace(int id, string newPlace)
        {
            placeRepository.changePlace(id, newPlace);
        }

        public IList<Place> getAllPlaces()
        {
            return placeRepository.GetAll().ToList();
        }

        public Place getPlaceById(int id)
        {
            return placeRepository.GetOne(id);
        }

        public void removePlace(int id)
        {
            placeRepository.removePlace(id);
        }
    }
}
