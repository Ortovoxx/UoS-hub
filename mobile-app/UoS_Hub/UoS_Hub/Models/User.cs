using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace UoS_Hub.Models
{
    public class User
    {
        [PrimaryKey] private int Id { get; set; } = 1;
        public string Tag { get; set; }
        public string Name { get; set; }
        public string iCal { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Lecture> Timetable { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Map Map { get; set; }
        public string Hall { get; set; }
        public string School { get; set; }
        public int SotonId { get; set; }
    }
}