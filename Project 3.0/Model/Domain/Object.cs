﻿namespace Project_3._0.Model.Domain
{
    public abstract class Object
    {
        public int Id { get; set; }
        public int AgentId { get; set; }
        public string TypeObject { get; set; }
        public string TypeOffer { get; set; }
        
        //public string? Citi { get; set; }
        //public string? Street { get; set; }
        //public int House { get; set; }
        //public int Apartment { get; set; }
        //public int Floor { get; set; }
        //public int AreaHouse { get; set; }
        //public int Rooms{ get; set; }
        //public decimal Price{ get; set; }
        //public string? Desc { get; set; }
    }
}
