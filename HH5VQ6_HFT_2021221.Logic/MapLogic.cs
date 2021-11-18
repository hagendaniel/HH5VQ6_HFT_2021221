﻿using HH5VQ6_HFT_2021221.Models;
using HH5VQ6_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH5VQ6_HFT_2021221.Logic
{
    public class MapLogic : IMapLogic
    {
        IMapRepository mapRepository;

        public MapLogic(IMapRepository repository) //dependency injection
        {
            this.mapRepository = repository;
        }
        public void addMap(string mapName, int difficulty)
        {
            mapRepository.addMap(mapName, difficulty);
        }

        public void deleteMap(int id)
        {
            mapRepository.removeMap(id);
        }

        public IList<Map> getAllMaps()
        {
            return mapRepository.GetAll().ToList();
        }

        public Map getMapById(int id)
        {
            return mapRepository.GetOne(id);
        }

        public void renameMap(int id, string newName)
        {
            mapRepository.renameMap(id, newName);
            //should add delete to the maprepository - a repot ez nem éri el, csak a maprepot
        }
    }
}