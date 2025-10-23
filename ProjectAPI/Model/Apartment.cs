namespace ProjectAPI.Model
{
    public class Apartment:ProjectAPI.Model.Object
    {
        public string? Citi { get; set; }
        public string? PathPhoto { get; set; }
        public string? Street { get; set; }
       // public string? Desc { get; set; }
        public int House { get; set; }
        public int NumberApartment { get; set; }
        public int Floor { get; set; }
        public int AreaHouse { get; set; }
        public int Rooms { get; set; }
       // public bool BrandNew { get; set; }
        public decimal Price { get; set; }
        public Description? Description { get; set; }
        public List<Photo>? Photo { get; set; }
    }
}
