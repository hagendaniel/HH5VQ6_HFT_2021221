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
    }
}
