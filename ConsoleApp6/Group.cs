using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearFormed { get; set; }
        public string Country { get; set; }
        public int ChartPosition { get; set; }
        public List<Song> Repertoire { get; set; }
        public List<Tour> Tours { get; set; }

        public Group(int id, string name, int yearFormed, string country, int chartPosition)
        {
            Id = id;
            Name = name;
            YearFormed = yearFormed;
            Country = country;
            ChartPosition = chartPosition;
            Repertoire = new List<Song>();
            Tours = new List<Tour>();
        }

        public static Group FromFileString(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
                return null;

            var parts = line.Split(';');

            if (parts.Length != 5)
                return null;

            int id, number, value;

            if (!int.TryParse(parts[0], out id))
                return null;

            string name = parts[1];

            if (!int.TryParse(parts[2], out number))
                return null;

            string description = parts[3];

            if (!int.TryParse(parts[4], out value))
                return null;

            return new Group(id, name, number, description, value);
        }

        public override string ToString()
        {
            return $"{Id};{Name};{YearFormed};{Country};{ChartPosition}";
        }
    }
}

