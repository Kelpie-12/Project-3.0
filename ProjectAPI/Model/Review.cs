namespace ProjectAPI.Model
{
    public class Review
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Text { get; set; }
        public int Mark { get; set; }
        public string JobTitle { get; set; }
        public DateTime Date { get; set; }
    }
}
