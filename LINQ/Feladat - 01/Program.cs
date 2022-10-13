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
            List<string> kikJatszanak = _players.Where(x => x.Club == "Vasas Óbuda").ToList(); //A ToList teszi bele a listába

            //novekvo sorrendbe magassag szerint
            List<string> kikJatszanakTobben = _players.Where(x => x.Club == "Vasas Óbuda").OrderBy(player => player.Height).Select(player => player.Name).ToList();





        }
    }
}
