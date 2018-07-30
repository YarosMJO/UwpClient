using System;

namespace AirportWebApi.DAL.Models
{
    public class Plane
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PlaneType Type { get; set; }
        public DateTime ReleaseDate { get; set; }
        public TimeSpan LifeTime { get; set; }
    }
}
