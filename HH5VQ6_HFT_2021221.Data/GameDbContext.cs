using HH5VQ6_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH5VQ6_HFT_2021221.Data
{
    public class GameDbContext : DbContext
    {
        //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\SquidGame.mdf;Integrated Security=True

        //Creating/Define Tables
        public /*virtual*/ DbSet<Map> Maps { get; set; }
        public /*virtual*/ DbSet<Place> Places { get; set; }
        public /*virtual*/ DbSet<Player> Players { get; set; }
        public /*virtual*/ DbSet<Season> Seasons { get; set; }

        public GameDbContext()
        {
            //this.Database.EnsureCreated();
            Database?.EnsureCreated();
        }

        public GameDbContext(DbContextOptions<GameDbContext> options) : base(options)
        {
            //this.Database.EnsureCreated();
            Database?.EnsureCreated();
        }

        /*public GameDbContext(DbContextOptions<GameDbContext> options) : base(options)
        {

        }*/

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //Connection string - Copied and edited
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\SquidGame.mdf;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Place choi = new Place() { PlaceId = 1, PlaceName = "Choi", Country = "South Korea" };
            Place buda = new Place() { PlaceId = 2, PlaceName = "Buda", Country = "Hungary" };
            Place tokyo = new Place() { PlaceId = 3, PlaceName = "Tokyo", Country = "Japan" };

            Season season1 = new Season() { SeasonId = 1, SeasonNickname = "Personal Bankruptcy", PlaceId = 1 };
            Season season2 = new Season() { SeasonId = 2, SeasonNickname = "Medieval Knockout", PlaceId = 2 };
            Season season3 = new Season() { SeasonId = 3, SeasonNickname = "Tokyo Drift", PlaceId = 3 };
            Season season4 = new Season() { SeasonId = 4, SeasonNickname = "Winter Knockout", PlaceId = 2 };

            Player player001 = new Player() { PlayerId = 1, PlayerName = "Danca Kong", Born = Convert.ToDateTime("2000.07.23."), Debt = 0, Age = 21, AliveOrDead = true, SeasonId = 1 };
            Player player456 = new Player() { PlayerId = 2, PlayerName = "Zsolszesz Fodi", Born = Convert.ToDateTime("2000.12.24."), Debt = 9000, Age = 21, AliveOrDead = true, SeasonId = 1 };
            Player player252 = new Player() { PlayerId = 3, PlayerName = "Benedek James", Born = Convert.ToDateTime("2000.03.31."), Debt = 20000, Age = 21, AliveOrDead = false, EliminatedOnMap_MapId=1, SeasonId = 1 };
            Player player199 = new Player() { PlayerId = 4, PlayerName = "Ricsi 00", Born = Convert.ToDateTime("2000.09.17."), Debt = 20000, Age = 21, AliveOrDead = true, SeasonId = 1 };
            Player player002 = new Player() { PlayerId = 5, PlayerName = "Cirno Fumo", Born = Convert.ToDateTime("2000.08.20."), Debt = 20000, Age = 21, AliveOrDead = false, EliminatedOnMap_MapId=3, SeasonId = 1 };

            Map rglight = new Map() { MapId = 1, MapName = "Red Light Green Light", Difficulty = 6 };
            Map pccandy = new Map() { MapId = 2, MapName = "Ppopgi/Honeycomb Candy", Difficulty = 8 };
            Map tugofwar = new Map() { MapId = 3, MapName = "Tud-of-War", Difficulty = 5 };
            Map marbles = new Map() { MapId = 4, MapName = "Marbles", Difficulty = 2 };


            //SaveChanges();

            //fluent api - Relations
            modelBuilder.Entity<Season>(entity =>
            {
                entity.HasOne(season => season.Place)
                .WithMany(place => place.Seasons)
                .HasForeignKey(season => season.PlaceId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasOne(player => player.Season)
                .WithMany(season => season.Players) //was withmany
                .HasForeignKey(player => player.SeasonId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasOne(player => player.Map)
                .WithMany(map => map.Players)
                .HasForeignKey(player => player.EliminatedOnMap_MapId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

            //Adding the data to the tables
            modelBuilder.Entity<Place>().HasData(choi, buda, tokyo);
            modelBuilder.Entity<Season>().HasData(season1, season2, season3, season4);
            modelBuilder.Entity<Player>().HasData(player001, player456, player252, player199, player002);
            modelBuilder.Entity<Map>().HasData(rglight, pccandy, tugofwar, marbles);
        }

    }
}
