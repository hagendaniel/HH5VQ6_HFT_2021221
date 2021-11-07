using HH5VQ6_HFT_2021221.Models;
using HH5VQ6_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH5VQ6_HFT_2021221.Logic
{
    public class SeasonLogic : ISeasonLogic
    {
        ISeasonRepository seasonRepository;

        public SeasonLogic(ISeasonRepository repository)
        {
            this.seasonRepository = repository;
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
    }
}
