using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;

namespace Feladat___03
{
    internal class Program
    {
        private static List<Motorcycle> _motorcycles = new List<Motorcycle>();
        private static void LoadData()
        {
            using (FileStream fs = new FileStream("./../../../data.json", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                {
                    string jsonData = sr.ReadToEnd();

                    _motorcycles = JsonSerializer.Deserialize<List<Motorcycle>>(jsonData);
                }
            }
        }

        private static void WriteToConsole(string text, ICollection<Motorcycle> motorcycles)
        {
            Console.WriteLine(text);
            Console.WriteLine(string.Join('\n', motorcycles));
        }

        private static void WriteToConsole(string text, Motorcycle motorcycle)
        {
            Console.WriteLine(text);
            Console.WriteLine(motorcycle);
        }

        static void Main(string[] args)
        {
            LoadData();
            WriteToConsole("Data", _motorcycles);

            // 1 - Hány motorkerékpár van az 'adatbázisban' ?
            int hanyDarab = _motorcycles.Count;

            // 2 - Hány 'Honda' gyártmányú motorkerékpár van az 'adatbázisban' ?
            int hanyHonda = _motorcycles.Count(x => x.Brand.ToLower() == "honda");

            // 3 - Mekkora a legnyaobb köbcenti az 'adatbázisban' ?
            int legnagyobb = _motorcycles.Max(x => x.Cubic);

            // 4 - Melyik a legkisebb végsebesség az 'adatbázisban' ?
            int legkisebbVegsebesseg = _motorcycles.Min(x => x.TopSpeed);

            // 5 - Van e olyan motorkerékpár az 'adatbázisban' amelyet 1960 előtt gyártottak?
            bool vane1960Elotti = _motorcycles.Any(x => x.ReleaseYear < 1960);

            // 6 - Van-e 'Honda' gyártmányú motorkerképár az 'adatbázisban' melynek beceneve 'Hornet' ?
            bool vaneHondaHornet = _motorcycles.Where(x => x.Brand.ToLower() == "honda").Where(x => x.Nickname.ToLower() == "hornet").Any();
            //vagy
            bool vaneHondaHornet2 = _motorcycles.Where(x => x.Brand.ToLower() == "honda")
                                                                            .Any(x => x.Nickname.ToLower() == "hornet");

            // 7 - Keressük ki a 'Yamaha' gyártmányú motorkerékpárokat!
            List<Motorcycle> yamahas = _motorcycles.Where(x => x.Brand.ToLower() == "yamaha").ToList();

            // 8 -Keressük a 'Suzuki' gyártotmányú motorkerékpárokat melyek 600ccm felett vannak!
            List<Motorcycle> suzukis = _motorcycles.Where(x => x.Brand.ToLower() == "suzuki").Where(x => x.Cubic > 600).ToList();

            // 9 - Keressük ki a 'Kawasaki' gyártotmányú motorkerékpárokat, melyek sebesságe nagyobb min 150km/h!
            List<Motorcycle> KawasakiGyorsabbmint150 = _motorcycles.Where(x => x.Brand.ToLower() == "kawasaki").Where(x => x.TopSpeed > 150).ToList();

            // 10 - Keressük ki a 'BMW' gyártotmányú motorkerékpárokat, melyeket 2010 előtt gyárottak és a motor köbcentije minimum 1000!
            List<Motorcycle> bmw = _motorcycles.Where(x => x.Brand == "bmw")
                                                                          .Where(x => x.ReleaseYear < 2010)
                                                                          .Where(x => x.Cubic >= 1000)
                                                                          .ToList();

            // 12 - Keressül a motorkerékpárok beceneveit (nickname)!
            List<string> becenevek = _motorcycles.Select(x => x.Nickname).ToList();

            // 13 - Keressük azokat a motorkerékpárokat, melyek neveiben szerepel 'FZ' kifejezés!
            List<Motorcycle> FZmotorok = _motorcycles.Where(x => x.Brand.ToLower().Contains("FZ")).ToList();

            // 14 - Keressük azokat a motorkerékpárokat, melyek nevei 'C' betűvel kezdődnek!
            List<Motorcycle> motorokCvelKezdve = _motorcycles.Where(x => x.Nickname.ToLower().StartsWith("c")).ToList();

            // 15 - Keressük az első motorkerékpárt az 'adatbázisunkból'!
            Motorcycle elsoMotor = _motorcycles.First();

            // 16 - Keressük az utolsó motorkerékpárt az 'adatbázisunkból'!
            Motorcycle utolsoMotor = _motorcycles.Last();

            // 17 - Rendezzük növekvő sorrendbe gyártási év alapján az 'adatbázisban' szereplő motorkerékpárokat.
            List<Motorcycle> novekvoGyartasbol = _motorcycles.OrderBy(x => x.ReleaseYear).ToList();

            // 18 - Rendezzük csökkenő sorrendbe a 'Honda' által gyártott motorkerékpárokat, melyek teljesítménye legalább 25kW és 2005 után gyártották őket.
            List<Motorcycle> csokkendoHondakTeljesitmennyel = _motorcycles.OrderByDescending(x => x.Brand == "Honda").Where(x => x.KW <= 25).Where(x => x.ReleaseYear > 2005).ToList();

            // 19 - Melyek azok a  motorkerékpárok, melyek nem rendelkeznek becenévvel?


            // 20 - Mekkora az 'adatbázisban' szereplő motorkerékpárok sebességének az átlaga?


            // 21 - Melyik a legyorsabb motorkerékpár? Feltételezzük, hogy csak egy ilyen van!
            int fastestTopSpeed = _motorcycles.Max(x => x.TopSpeed);

            Motorcycle fastest = _motorcycles.Single(x => x.TopSpeed == fastestTopSpeed);

            // 22 - Hány kategória található meg az 'adatbázisban'?
            int kategoriakSzama = _motorcycles.Select(x => x.Category).Distinct().Count();
                                                                

            // 23 - Határozza meg az 'adatbázisban' talalható motorkerékpárok átlag életkorát!


            // 24 - Van-e 'Java' gyártmányú motorkerékpár az 'adatbázisban'?
            bool vaneJava = _motorcycles.Any(x => x.Brand == "Java");

            // 25 - Rendezzül növekvő sorrende az 5 betűvel rendelkező gyártók motorkerékpárjait,
            //         majd csökkenő sorrendbe gyártási év alapján és az eredményben csak a nevet és
            //         a gyártási évet jelenítse meg!
            //List<UtolsoFeladat> feladat = _motorcycles.Where(x => x.Brand.Length == 5)
            //                                                                     .OrderBy(x => x.Brand)
            //                                                                     .ThenByDescending(x => x.ReleaseYear)
            //                                                                     .Select(x => new UtolsoFeladat(x.Brand, x.ReleaseYear))
            //                                                                     .ToList();
            //Console.ReadLine();
        }
    }
}
