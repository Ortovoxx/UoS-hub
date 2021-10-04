using System;

namespace UoS_Hub.Models
{
    public class Lecture
    {
        public Guid Id { get; set; }
        public string Summary { get; set; }
        public string Location { get; set; }
        public string DurationHours { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}