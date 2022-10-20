using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feladat___04
{
    class DirectorAndReleaseDate
    {
        public string Director { get; set; }
        public DateTime ReleaseDate { get; set; }

        public DirectorAndReleaseDate(string director, DateTime releaseDate)
        {
            Director = director;
            ReleaseDate = releaseDate;
        }
    }
}
