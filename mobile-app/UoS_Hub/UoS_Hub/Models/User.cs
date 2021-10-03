using System.Collections.Generic;

namespace UoS_Hub.Models
{
    public class User
    {
        public string Tag { get; set; }
        public string Name { get; set; }
        public string iCal { get; set; }
        public List<Lecture> Timetable { get; set; }
        public Map Map { get; set; }
        public string Hall { get; set; }
        public string School { get; set; }
        public int SotonId { get; set; }
    }
}