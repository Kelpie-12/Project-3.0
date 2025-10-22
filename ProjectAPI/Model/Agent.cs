namespace ProjectAPI.Model
{
    public class Agent
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int UserId { get; set; }
        public double Rate { get; set; }
        public DateTime WorkSince { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Position { get; set; }
        public string? Photo { get; set; }

    }
}
