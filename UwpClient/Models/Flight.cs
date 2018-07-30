﻿using System;
using System.Collections.Generic;

namespace AirportWebApi.DAL.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public DateTime DepartureTime { get; set; }
        public string DeparturePoint { get; set; }
        public string Destination { get; set; }
        public DateTime ArrivalTime { get; set; }
        public List<Ticket> Tickets { get; set; }

    }
}
