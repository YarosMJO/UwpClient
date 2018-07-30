using System;

namespace AirportWebApi.DAL.Models
{

    public class Pilot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public int Experience { get; set; }

    }

}
