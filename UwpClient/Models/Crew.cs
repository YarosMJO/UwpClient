using System.Collections.Generic;

namespace AirportWebApi.DAL.Models
{
    public class Crew
    {
        public int Id { get; set; }
        public Pilot Pilot { get; set; }
        public List<FlightAttendant> FlightAttendants { get; set; }

    }
}
