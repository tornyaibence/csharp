using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Feladat___01
{
    internal class Program
    {
        private static List<Player> _players = new List<Player>();

        private static void LoadData()
        {
            using (FileStream fs = new FileStream("./../../../data.json", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                {
                    string jsonData = sr.ReadToEnd();

                    _players = JsonConvert.DeserializeObject<List<Player>>(jsonData);
                }
            }
        }

        private static void WriteToConsole(string text, ICollection<Player> players)
        {
            Console.WriteLine(text);
            Console.WriteLine(string.Join('\n', _players));
        }

        private static void WriteToConsole(string text, Player player)
        {
            Console.WriteLine(text);
            Console.WriteLine(player);
        }

        static void Main(string[] args)
        {
            LoadData();
            WriteToConsole("Data", _players);

            //hány játékos található az adatbázisban?
            int jatekosokSzama = _players.Count;

            //határozzuk meg a játékosok össz súlyát
            int osszSuly = _players.Sum(player => player.Weight);

            //mekkora a jatekosok atlag magassaga?
            double atlagMagassag = _players.Average(player => player.Height);

            //milyen magas a legalacsonyabb játékos
            double milyenMagasLegalacsony = _players.Min(player => player.Height);

            //milyen magas a legmagasabb játékos
            double milyenMagasLegmagasabb = _players.Max(player => player.Height);

            //Van-e olyan jatekos aki 1.78m magas?
            bool vanOlyan = _players.Any(x => x.Height == 1.78);

            //Kik játszanak a "Vasas Óbuda" klubban?
            List<Player> kikJatszanak = _players.Where(x => x.Club == "Vasas Óbuda").ToList(); //A ToList teszi bele a listába

            //novekvo sorrendbe magassag szerint
            List<string> kikJatszanakTobben = _players.Where(x => x.Club == "Vasas Óbuda").OrderBy(player => player.Height).Select(player => player.Name).ToList();

            //hany jatekos jatszik a Vasas Óbuda klubban?
            int vasasObudaPlayers = _players.Count(x => x.Club == "Vasas Óbuda");

            //rendezzük a jatekosokat nem szerint novekvo sorrendbe majd magassag szerint csokkeno sorrendbe
            List<Player> kikJatszanakTobbenSorban = _players.OrderBy(x => x.Name).ThenByDescending(x => x.Height).ToList();

            //Keressük ki azon játékosokat akik libero poszton jatszanak és magasabbak mint 1.5 es alacsonyabbak mint 1.71
            List<Player> liberoPlayers = _players.Where(x => x.Position == "liberó").Where(x => x.Height > 1.5).Where(x => x.Height < 1.71).ToList();

            //Keressük ki a különböző csapatneveket
            List<string> csapatnevek = _players.Select(player => player.Club).Distinct().ToList();

            //Keressuk ki a jatekosok nevet es klubjat!
            // List<Class1> playerNamesWithClubs = _players.Select(x => new Class1(Player.Name, Player.Club)).ToList();
            //List<Class1> playerNamesWithClubs2 = _players.Select(x => new Class1
            //{
            //     Name = x.Name, 
            //     Club = x.Club
            //})
            // .ToList();

            //Keresse ki azon játékosokat akik ütő poszton játszanak, magasabbak mint 1,8 es a nevuk ,,a,, beture vegzodik
            //Az eredmenyt rendezze csokkeno sorrendbe magassag szerint
            List<string> sokKitetel = _players.Where(x => x.Position.ToLower() == "HITTER").Where(x => x.Height > 1.8).Where(x => x.Name.EndsWith("a")).OrderByDescending(x => x.Height).Select(x => x.Name).ToList();

            //Keresse ki Juhar Dalma nevezetu jatekost
            Player juharDalma = _players.FirstOrDefault(x => x.Name.ToLower() == "juhár dalma");
            Player juharDalmaMashogy = _players.SingleOrDefault(x => x.Name.ToLower() == "juhár dalma");


        }
    }
}
