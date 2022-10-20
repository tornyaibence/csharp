using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Linq;

namespace Feladat___04
{
    internal class Program
    {
        private static List<Movie> _movies = new List<Movie>();

        private static void LoadData()
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                PropertyNameCaseInsensitive = true,
                WriteIndented = true,
            };

            options.Converters.Add(new DateFormatConverter());

            using (FileStream fs = new FileStream("./../../../data.json", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                {
                    string jsonData = sr.ReadToEnd();

                    _movies = JsonSerializer.Deserialize<List<Movie>>(jsonData, options);
                }
            }
        }

        private static void WriteToConsole(string text, ICollection<Movie> movies)
        {
            Console.WriteLine(text);
            Console.WriteLine(string.Join('\n', _movies));
        }

        private static void WriteToConsole(string text, Movie movie)
        {
            Console.WriteLine(text);
            Console.WriteLine(movie);
        }

        static void Main(string[] args)
        {
            LoadData();
            WriteToConsole($"Data ({_movies.Count})", _movies);
        }

        // 1 - Hány film adatát dolgozzuk fel?
        int hanyFilm = _movies.Count;

        // 2 - Mekkora bevételt hoztak a filmek Amerikában?
        int bevetelAmerikaban = _movies.Where(x => x.USGross.HasValue)
                                                             .Sum(x => x.USGross.Value);

        // 3 - Mekkora bevételt hoztak a filmek Világszerte?
        long bevetelVilagban = _movies.Where(x => x.WorldwideGross.HasValue)
                                                        .Sum(x => x.WorldwideGross.Value);

        // 4 - Hány film jelent meg az 1990-es években?
        //int hanyFilmVan = _movies.Where((x => Release.Year = 1990);

        // 5 - Hányan szavaztak összessen az IMDB-n?
        int hanyanSzavaztak = _movies.Where(x => x.IMDBVotes.HasValue)
                                                          .Sum(x => x.IMDBVotes.Value);

        // 6 - Hányan szavaztak átlagossan az IMDB-n?
        double hanyanSzavaztakAtlagban = _movies.Where(x => x.IMDBVotes.HasValue)
                                                                              .Average(x => x.IMDBVotes.Value);

        // 7 - A filmek  világszerte átlagban mennyit hoztak a konyhára?
        double atlagKereset = _movies.Where(x => x.WorldwideGross.HasValue)
                                                         .Average(x => x.IMDBVotes.Value);

        // 8 - Hány filmet rendezett 'Christopher Nolan' ?
        int hanyFilmet = _movies.Count(x => x.Director.ToLower() == "Christopher Nolan");

        // 9 - Melyik filmeket rendezte 'James Cameron'?
        List<Movie> FilmByJC = _movies.Where(x => x.Director.ToLower() == "'James Cameron").ToList();
        // 10 - Keresse ki a 'Fantasy' kaland (Adventure) zsáner kategóriájjú filmeket.
        List<Movie> fantasyVagyAdventure = _movies.Where(x => x.MajorGenre.ToLower() == "adventure")
                                                                                .Where(x => x.CreativeType.ToLower() == "fantasy")
                                                                                .ToList();
        // 11 - Kik rendeztek akció (Action) filmeket és mikor?
        List<DirectorAndReleaseDate> kikRendeztekAkciotMikor = _movies.Where(x => x.MajorGenre.ToLower() == "action")
                                                                                    .Select(x => new DirectorAndReleaseDate(x.Director, x.ReleaseDate))
                                                                                    .ToList();

        // 12 - 'Paramount Pictures' horror filmjeinek cime?

        // 13 - Van-e olyan film melyet 'Tom Crusie' rendezett?

        // 14 - A 'Little Miss Sunshine' filme mekkora össz bevételt hozott?

        // 15 - Hány olyan film van amely az IMDB-n 6 feletti osztályzatot ért el és a 'Rotten Tomatoes'-n pedig legalább 25-t?

        // 16 - 'Michael Bay' filmjei átlagban mekkora bevételt hoztak?
        long bevetelekMBtol = _movies.Where(x => x.WorldwideGross.HasValue)
                                                         .Where(x => x.Director.ToLower == "michaelbay")
                                                         .Sum(x => x.WorldwideGross.Value);

        // 17 - Melyek azok a 'Michael Bay' a 'Walt Disney Pictures' által forgalmazott fimek melyek legalább 150min hosszúak.

        // 18 - Listázza ki a forgalmazókat úgy, hogy mindegyik csak egyszer jelenjen meg!

        // 19 - Rendezze a filmeket az 'IMDB Votes' szerint  növekvő sorrendbe.

        // 20 - Rendezze a filmeket címük szerint csökkenő sorrendbe!

        // 21 - Melyek azok a filmek melyek hossza meghaladja a 120 percet?

        // 22 - Hány film jelent meg december hónapban?

        // 23 - Egyes besorolásokban (Rating) hány film található?

        // 24 - Keresse ki azokat a filmeket melyeket 'Ron Howard' rendezett a 2000 években, 'PG-13' bsorolású, lagalább 80 perc hosszú és az IMDB legalább 6.5 átlagot ért el.

        // 25 - A 'Lionsgate' kiadónál kik rendeztek filmeket?

        // 26 - Az 'Universal' forgalmazó átlagban mennyit kültött film forgatására?

        // 27 - Az 'IMDB Votes' alapján melyek azok a filmek, melyeket többen értékeltek min 30 000-n?

        // 28 - Az 'American Pie' című filmnek hány része van?

        // 29 - Van-e olyan film melynek a címében szerepel a 'fantasy' szó és a zsánere 'Adventure'?

        // 30 - Átlagban hányan szavaztak az IMDB-n?

        // 31 - Kik rendeztek a 'Warner Bros.' forgalmazónál dráma filmeket 1970 és 1975 közt melyre az 'IMDB Votes' alapján többen szavaztak az átlagnál?

        // 32 - Van e olyan film amely karácsony napján jelent meg?

        // 33 - 'Spider-Man' című filmek USA-ban mekkora bevételt hoztak?

        // 34 - Keresse ki  szuperhősös (Super Hero) filmek címeit.
    }
}
