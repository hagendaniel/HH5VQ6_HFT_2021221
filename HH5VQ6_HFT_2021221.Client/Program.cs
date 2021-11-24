using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
//using HH5VQ6_HFT_2021221.Data; //For testing, also Data should be added in Project reference


namespace HH5VQ6_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
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
            Console.WriteLine("Hello World!");
        }

        static void AddMap(string mapName, int difficulty)
        {
            HttpClient httpClient = new HttpClient();

            //HttpContent httpContent = new HttpContent(JsonConvert.SerializeObject())
        }
    }
}
