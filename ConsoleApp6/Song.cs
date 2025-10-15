using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Composer { get; set; }
        public string Lyricist { get; set; }
        public int Year { get; set; }
        public string Singer { get; set; }

        public Song(int id, string title, string composer, string lyricist, int year, string singer)
        {
            Id = id;
            Title = title;
            Composer = composer;
            Lyricist = lyricist;
            Year = year;
            Singer = singer;
        }

        public static Song FromFileString(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
                return null;

            var parts = line.Split(';');

            if (parts.Length != 6)
                return null;

            int id, duration;

            if (!int.TryParse(parts[0], out id))
                return null;

            string title = parts[1];
            string artist = parts[2];
            string album = parts[3];

            if (!int.TryParse(parts[4], out duration))
                return null;

            string genre = parts[5];

            return new Song(id, title, artist, album, duration, genre);
        }

        public override string ToString()
        {
            return $"{Id};{Title};{Composer};{Lyricist};{Year};{Singer}";
        }
    }
}

