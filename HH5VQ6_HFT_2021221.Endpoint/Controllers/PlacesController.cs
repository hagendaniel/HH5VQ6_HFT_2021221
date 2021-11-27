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
    public class PlacesController
    {
        IPlaceLogic placeLogic;

        public PlacesController(IPlaceLogic placeLogic)
        {
            this.placeLogic = placeLogic;
        }

        [HttpGet]
        public IEnumerable<Place> GetPlaces()
        {
            var places = placeLogic.getAllPlaces();
            return places;
        }

        [HttpGet("{id}")]
        public Place Get(int id)
        {
            return placeLogic.getPlaceById(id);
        }

        [HttpPost]
        public void Post([FromBody] Place place)
        {
            placeLogic.addPlace(place);
        }

        [HttpPut]
        public void Put([FromBody] Place place)
        {
            placeLogic.changePlace(place.PlaceId, place.PlaceName);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            placeLogic.removePlace(id);
        }

        ////non-crud
        //[HttpGet("players/{id}")]
        //public string InWhichCityPlayerDied(int id)
        //{
        //    return placeLogic.inWhichCityPlayerDied(id);
        //}

        [HttpGet("inwhichcityplayerdied/{playerId}")]
        public InWhichCityPlayerDied inWhichCityPlayerDied(int playerId)
        {
            return placeLogic.inWhichCityPlayerDied(playerId);
        }
    }
}
