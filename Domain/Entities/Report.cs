namespace Domain.Entities
{
    public class Report
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public DateTime SendDate { get; set; }
        public string User { get; set; }
        public string Status { get; set; }
    }
}