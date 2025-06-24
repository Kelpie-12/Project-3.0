namespace Project_3._0.Model.Domain
{
    public class Apartment:Project_3._0.Model.Domain.Object
    {
        //public int ObjectId { get; set; }
        public string ? Citi { get; set; }
        public string ?Street{ get; set; }
        public string ?Desc{ get; set; }
        public int House { get; set; }
        public int NumberApartment { get; set; }
        public int Floor { get; set; }
        public int AreaHouse { get; set; }
        public int Rooms { get; set; }
        public decimal Price { get; set; }

    }
}
