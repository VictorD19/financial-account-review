namespace account_review_api.Application.DTOs
{
    public class ReportDTO
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string User { get; set; }
        public string Status { get; set; }
    }
}
