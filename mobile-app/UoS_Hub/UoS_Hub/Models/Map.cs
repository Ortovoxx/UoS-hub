using System;
using System.Collections.Generic;
using SQLiteNetExtensions.Attributes;

namespace UoS_Hub.Models
{
    public class Map
    {
        public Guid Id { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Building> Favourites { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Building> Timetable { get; set; }
    }
}