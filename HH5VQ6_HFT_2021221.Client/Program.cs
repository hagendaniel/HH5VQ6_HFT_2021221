﻿using ConsoleTools;
using HH5VQ6_HFT_2021221.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
//using HH5VQ6_HFT_2021221.Data; //For testing, also Data should be added in Project reference


namespace HH5VQ6_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            /*GameDbContext gameDbContext = new GameDbContext();

            Console.WriteLine("Database has been filled with data");

            Console.WriteLine("\nSeason places:");
            var places = gameDbContext.Place.Select(x => x.Country);
            foreach (var item in places)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nSeasons played:");
            var seasons = gameDbContext.Seasons.Select(x => x.SeasonNickname);
            foreach (var item in seasons)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nPlayers name:");
            var players = gameDbContext.Players.Select(x => x.PlayerName);
            foreach (var item in players)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nMaps name:");
            var maps = gameDbContext.Maps.Select(x => x.MapName);
            foreach (var item in maps)
            {
                Console.WriteLine(item);
            }
            */

            ////////--------------------------------------------------------

            //var maps = GetMaps();

            //foreach (var map in maps)
            //{
            //    Console.WriteLine(map.MapName);
            //}

            //AddMap(new Map { MapId = 5, MapName = "Trainsurfing", Difficulty = 2 });

            //var maps2 = GetMaps();

            //foreach (var map in maps2)
            //{
            //    Console.WriteLine(map.MapName);
            //}

            //-----------------------------------------------------------------------------------------------------------------------------------------------------------

            //System.Threading.Thread.Sleep(18000);

            RestService rest = new RestService("http://localhost:27989");

            rest.Post<Map>(new Map()
            {
                //MapId = 5,
                MapName = "Trainsurf",
                Difficulty = 4
            }, "maps");

            var maps = rest.Get<Map>("maps");

            foreach (var map in maps)
            {
                Console.WriteLine(map.MapName);
            }


            //-----------------------------------------------------------------------------------------------------------------------------------------------------------

            var mapMenu = new ConsoleMenu()
                .Add("Create new map", () => CreateMap(rest))
                .Add("Show all maps", () => GetAllMaps(rest))
                .Add("Show a map by id", () => GetMap(rest))
                .Add("Rename a map", () => RenameMap(rest))
                .Add("Delete a map", () => DeleteMap(rest));

            var placeMenu = new ConsoleMenu()
                .Add("Create new place", () => CreatePlace(rest))
                .Add("Show all places", () => GetAllPlaces(rest))
                .Add("Show a place by id", () => GetPlace(rest))
                .Add("Change place to a new one in the same country", () => ChangePlace(rest))
                .Add("Delete a place", () => DeletePlace(rest));

            var playerMenu = new ConsoleMenu()
                .Add("Register new player", () => CreatePlayer(rest))
                .Add("Show all players", () => GetAllPlayers(rest))
                .Add("Show a player by id", () => GetPlayer(rest))
                .Add("Eliminate a player", () => EliminatePlayer(rest))
                .Add("Delete a player", () => DeletePlayer(rest));

            playerMenu.Show();

            Console.ReadKey();
        }

        //static void AddMap(Map map)
        //{
        //    HttpClient httpClient = new HttpClient();

        //    HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(map), Encoding.UTF8, "application/json");

        //    var response = httpClient.PostAsync("http://localhost:27989/maps", httpContent).GetAwaiter().GetResult();

        //    if (response.StatusCode != System.Net.HttpStatusCode.OK)
        //    {
        //        throw new Exception();
        //    }
        //}

        //static List<Map> GetMaps()
        //{
        //    HttpClient httpClient = new HttpClient();

        //    var response = httpClient.GetAsync("https://localhost:27989/maps").GetAwaiter().GetResult();

        //    if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //    {
        //        var responseContent = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

        //        var maps = JsonConvert.DeserializeObject<List<Map>>(responseContent);

        //        return maps;
        //    }

        //    throw new Exception();

        //}

        //CRUD METHODS FOR THE MENU-----------------------------------------------------------------------------------------
        //CRUD METHODS FOR THE MAPMENU--------------------------------------------------------------------------------------
        #region MAPMENU_CRUD
        private static void CreateMap(RestService restService)
        {
            Console.WriteLine("Name of the new map: ");
            string name = Console.ReadLine();
            Console.WriteLine("Difficulty of the new map (1-10): ");
            int difficulty = int.Parse(Console.ReadLine());
            restService.Post(new Map
            {
                MapName = name,
                Difficulty=difficulty
            }, "maps");
            Console.WriteLine("The new map has been created");
            Console.ReadKey();
        }

        private static void GetAllMaps(RestService restService)
        {
            var maps = restService.Get<Map>("maps");
            foreach (var map in maps)
            {
                Console.WriteLine(map.MapName);
            }
            Console.ReadKey();
        }

        private static void GetMap(RestService restService)
        {
            try
            {
                Console.WriteLine("Id of the map: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Map map = restService.Get<Map>(id, "maps");
                Console.WriteLine($"The map with the given id is {map.MapName}, with difficulty level of {map.Difficulty}");
            }
            catch (System.NullReferenceException)
            {
                Console.WriteLine("Invalid id");
            }
            Console.ReadKey();
        }

        private static void RenameMap(RestService restService)
        {
            try
            {
                Console.WriteLine("Id of the map you want to rename: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Map map = restService.Get<Map>(id, "maps");
                string oldName = map.MapName;
                Console.WriteLine("New name of the map: ");
                string newName = Console.ReadLine();
                map.MapName = newName;
                restService.Put(map, "maps");
                Console.WriteLine($"The map as been renamed from {oldName} to {newName}");
            }
            catch (System.NullReferenceException)
            {
                Console.WriteLine("Invalid id");
            }
            Console.ReadKey();
        }

        private static void DeleteMap(RestService restService)
        {
            try
            {
                Console.WriteLine("Id of the map you want to delete: ");
                int id = Convert.ToInt32(Console.ReadLine());
                restService.Delete(id, "maps");
                Console.WriteLine($"The map with the id of ({id}) has been deleted.");
            }
            catch (System.NullReferenceException)
            {
                Console.WriteLine("Invalid id");
            }
            Console.ReadKey();
        }
#endregion
        //CRUD METHODS FOR THE PLACEMENU------------------------------------------------------------------------------------
        #region PLACEMENU_CRUD
        private static void CreatePlace(RestService restService)
        {
            Console.WriteLine("Name of the new place: ");
            string name = Console.ReadLine();
            Console.WriteLine("Country of the new place: ");
            string country = Console.ReadLine();
            restService.Post(new Place
            {
                PlaceName = name,
                Country = country
            }, "places");
            Console.WriteLine("The new place has been created");
            Console.ReadKey();
        }

        private static void GetAllPlaces(RestService restService)
        {
            var places = restService.Get<Place>("places");
            foreach (var place in places)
            {
                Console.WriteLine($"{place.PlaceName} in {place.Country}");
            }
            Console.ReadKey();
        }

        private static void GetPlace(RestService restService)
        {
            try
            {
                Console.WriteLine("Id of the place: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Place place = restService.Get<Place>(id, "places");
                Console.WriteLine($"The place with the given id is {place.PlaceName} in {place.Country}");
            }
            catch (System.NullReferenceException)
            {
                Console.WriteLine("Invalid id");
            }
            Console.ReadKey();
        }

        private static void ChangePlace(RestService restService)
        {
            try
            {
                Console.WriteLine("Id of the place you want to change: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Place place = restService.Get<Place>(id, "places");
                string oldPlace = place.PlaceName;
                Console.WriteLine("New place in the same country: ");
                string newPlace = Console.ReadLine();
                place.PlaceName = newPlace;
                restService.Put(place, "places");
                Console.WriteLine($"The place has been changed from {oldPlace} to {newPlace}");
            }
            catch (System.NullReferenceException)
            {
                Console.WriteLine("Invalid id");
            }
            Console.ReadKey();
        }

        private static void DeletePlace(RestService restService)
        {
            try
            {
                Console.WriteLine("Id of the place you want to delete: ");
                int id = Convert.ToInt32(Console.ReadLine());
                restService.Delete(id, "places");
                Console.WriteLine($"The place with the id of ({id}) has been deleted.");
            }
            catch (System.NullReferenceException)
            {
                Console.WriteLine("Invalid id");
            }
            Console.ReadKey();
        }
        #endregion
        #region PLAYERMENU_CRUD
        private static void CreatePlayer(RestService restService)
        {
            Console.WriteLine("Name of the new player: ");
            string name = Console.ReadLine();
            Console.WriteLine("Date of born:");
            DateTime born = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Id of season which s/he registers: ");
            int seasonId = Convert.ToInt32(Console.ReadLine());
            restService.Post(new Player
            {
                PlayerName = name,
                Born = born,
                SeasonId = seasonId
            }, "players"); ;
            Console.WriteLine($"The new player has been registered for season {seasonId}");
            Console.ReadKey();
        }

        private static void GetAllPlayers(RestService restService)
        {
            var players = restService.Get<Player>("players");
            foreach (var player in players)
            {
                Console.WriteLine($"{player.PlayerName} played in season {player.SeasonId}");
            }
            Console.ReadKey();
        }

        private static void GetPlayer(RestService restService)
        {
            try
            {
                Console.WriteLine("Id of the player: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Player player = restService.Get<Player>(id, "players");
                Console.WriteLine($"The player with the given id is {player.PlayerName} from season {player.SeasonId}");
            }
            catch (System.NullReferenceException)
            {
                Console.WriteLine("Invalid id");
            }
            Console.ReadKey();
        }

        private static void EliminatePlayer(RestService restService)
        {
            try
            {
                Console.WriteLine("Id of the player who got eliminated: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Player player = restService.Get<Player>(id, "players");
                Console.WriteLine("Id of the map where the player got eliminated: ");
                int mapId = Convert.ToInt32(Console.ReadLine());
                player.AliveOrDead = false;
                player.EliminatedOnMap_MapId = mapId;
                restService.Put(player, "players");
                Console.WriteLine($"Player {player.PlayerId}, eliminated.");
            }
            catch (System.NullReferenceException)
            {
                Console.WriteLine("Invalid id");
            }
            Console.ReadKey();
        }

        private static void DeletePlayer(RestService restService)
        {
            try
            {
                Console.WriteLine("Id of the player you want to delete: ");
                int id = Convert.ToInt32(Console.ReadLine());
                restService.Delete(id, "players");
                Console.WriteLine($"Player {id} has been deleted.");
            }
            catch (System.NullReferenceException)
            {
                Console.WriteLine("Invalid id");
            }
            Console.ReadKey();
        }
        #endregion
    }
}
