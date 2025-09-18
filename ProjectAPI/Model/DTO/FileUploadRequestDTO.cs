namespace ProjectAPI.Model.DTO
{
    public class FileUploadRequestDTO
    {
        public string? Photo { get; set; }
        public string? Citi { get; set; }
        public string? Street { get; set; }
        public int House { get; set; }
        public int NumberApartment { get; set; }
        public int Floor { get; set; }
        public int AreaHouse { get; set; }
        public int Rooms { get; set; }
        public bool BrandNew { get; set; }
        public decimal Price { get; set; }
        public Description? Description { get; set; }
        public FileUploadRequestDTO(FileUploadRequest ap)
        {
            Citi = ap.Citi;
            Street = ap.Street;
            House = ap.House;
            NumberApartment = ap.NumberApartment;
            Floor = ap.Floor;
            AreaHouse = ap.AreaHouse;
            Rooms = ap.Rooms;
            BrandNew = ap.BrandNew;
            Price = ap.Price;
            Description = ap.Description;
                }
    }
}
