using System;

namespace AirportWebApi.DAL.Models
{
    public class FlightAttendant
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }

    }
}
