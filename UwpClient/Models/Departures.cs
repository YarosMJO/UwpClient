using System;

namespace AirportWebApi.DAL.Models
{
    public class Departure
    {
        public int Id { get; set; }
        public int FlightNumber { get; set; }
        public DateTime DepartureDate { get; set; }
        public Crew Crew { get; set; }
        public Plane Plane { get; set; }
    }
}
