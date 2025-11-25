namespace ProjectAPI.Model
{
    public class Description
    {
        public string? Title { get; set; }
        public IList<string> Paragrahs { get; set; } = [];  
    }
}
