namespace UoS_Hub.Models
{
    public class Update
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Source { get; set; } //essentially an author
    }
}