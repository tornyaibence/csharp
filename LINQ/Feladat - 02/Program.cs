using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Feladat___02
{
    internal class Program
    {
        private static List<Game> _games = new List<Game>();

        private static void LoadData()
        {
            using (FileStream fs = new FileStream("./../../../data.json", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                {
                    string jsonData = sr.ReadToEnd();

                    _games = JsonConvert.DeserializeObject<List<Game>>(jsonData);
                }
            }
        }

        private static void WriteToConsole(string text, ICollection<Game> games)
        {
            Console.WriteLine(text);
            Console.WriteLine(string.Join('\n', _games));
        }

        private static void WriteToConsole(string text, Game game)
        {
            Console.WriteLine(text);
            Console.WriteLine(game);
        }

        static void Main(string[] args)
        {
            LoadData();
            WriteToConsole("Data", _games);

            /*
             Hány adat van a listában?
            */
            int hanyAdat = _games.Count();

            /*
             Keressük ki azon játékokat, melyek MMORPG tipusuak (genre).
            */
            List <Game> mmorpgGames = _games.Where(x => x.Genre.ToLower() == "MMORPG").ToList();

            /*
            Keressük ki azon játékokat, melyek 2013-ban jelentek meg.
           */
            List<Game> evbenJelent = _games.Where(x => x.Release_date != "0000-00-00").Where(x => DateTime.Parse(x.Release_date).Year == 2013).ToList();
            /*
            Keressük ki azon játékokat, melyek Darkflow Distribution KFR fejlesztett.
           */
            List<Game> DarkflowGames = _games.Where(x => x.Publisher.ToLower() == "DARKFLOW DISTRIBUTION KFR").ToList();
            /*
            Keressük ki hány shooter játék van a listában.
           */
            List<Game> shooterGames = _games.Where(x => x.Genre.ToLower() == "shooter").ToList();
            /*
            Van-e olyan játék melyet Cryptic Studios fejleszett?
           */
            bool VaneOlyan = _games.Any(x => x.Publisher.ToLower() == "cryptic studios");
            /*
            Keressük ki azon játékokat, melyek a címében (title) szerepel a ,,winter,, szó.
           */
            List <Game> tartalmaz = _games.Where(x => x.Title.ToLower().Contains("winter")).ToList();
            /*
            Keressük ki a platformokat, de úgy, hogy mindegyik csak egyszer forduljon elő az eredménybe.
           */
            List<string> platformok = _games.Select(x => x.Platform).Distinct().ToList();
            /*
            Keressük ki , hogy típusonként (genre) hány játék van.
           */
            Dictionary<string, int> genreCountDictionary = new Dictionary<string, int>();
            List<string> genres = _games.Select(game => game.Genre)
                                                            .Distinct()
                                                            .ToList();
            /*
            Keressük ki az Electronic Arts álltal fejlesztett játékokat, melyek shooter típusúak.
           */
            List<Game> electronicArts = _games.Where(game => game.Developer.ToLower() == "electronic arts")
                                                                       .Where(game => game.Genre.ToLower() == "shooter")
                                                                       .ToList();
            /*
            Keressük ki a listában szereplő fejlesztők  játékainak címét.
           */
            //Dictionary<string, List<string>> hianyos
            /*
            Keressük ki azt a játékot mely legkorábban jelent meg.
           */
            //string FirstGame = _games.Min(x => x.Release_date.ToString());
            DateTime earlygamestime = _games.Where(x => x.Release_date != "0000-00-00")
                                                          .Min(x => DateTime.Parse(x.Release_date));

            Game gamegames = _games.FirstOrDefault(game => DateTime.Parse(game.Release_date).Date == earlygamestime.Date);
            /*
            Keressük ki azon játékok címét, melyeket az Ubisoft jelenített meg, 
            a Blue Byte fejlesztett ki 2010 és 2015 közt.
           */
            List<string> UbiGamesByDate = _games.Where(x => x.Publisher.ToLower() == "ubisoft")
                                                                .Where(x => x.Developer.ToLower() == "blue byte")
                                                                .Where(x => DateTime.Parse(x.Release_date).Year <= 2010)
                                                                .Where(x => DateTime.Parse(x.Release_date).Year >= 2015)
                                                                .Select(x => x.Title)
                                                                .ToList();
        }
    }
}
