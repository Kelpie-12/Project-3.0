namespace ProjectAPI.Model
{
    public class Description
    {
        public string? Title { get; set; }
        public IList<string> Paragrahs { get; set; } = [];//переделать
        public string? Paragraph_1 { get; set; }
        public string? Paragraph_2 { get; set; }
        public string? Paragraph_3 { get; set; }
    }
}
