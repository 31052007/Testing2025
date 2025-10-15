using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class Tour
    {
        public int Id { get; set; }
        public string City { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TicketPrice { get; set; }

        public Tour(int id, string city, DateTime startDate, DateTime endDate, decimal ticketPrice)
        {
            Id = id;
            City = city;
            StartDate = startDate;
            EndDate = endDate;
            TicketPrice = ticketPrice;
        }

        public static Tour FromFileString(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
                return null;

            var parts = line.Split(';');

            if (parts.Length != 5)
                return null;

            int id;
            DateTime startDate, endDate;
            decimal price;

            if (!int.TryParse(parts[0], out id))
                return null;

            string name = parts[1];

            if (!DateTime.TryParse(parts[2], out startDate))
                return null;

            if (!DateTime.TryParse(parts[3], out endDate))
                return null;

            if (!decimal.TryParse(parts[4], out price))
                return null;

            return new Tour(id, name, startDate, endDate, price);
        }

        public override string ToString()
        {
            return $"{Id};{City};{StartDate:yyyy-MM-dd};{EndDate:yyyy-MM-dd};{TicketPrice}";
        }
    }
}

