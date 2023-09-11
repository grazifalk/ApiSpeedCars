namespace Service.DTOs
{
    public class CarDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public int Doors { get; set; }
        public string Steering { get; set; }
        public bool PowerWindow { get; set; }
        public bool PowerDoorLocks { get; set; }
        public bool AirConditioner { get; set; }
        public string Trunk { get; set; }
        public double Price { get; set; }
        public bool Available { get; set; }
        public int ModelId { get; set; }

        public CarDTO() { }

        public CarDTO(int id, string name, string photo, string brand, string color, int doors, string steering, string trunk, double price, int modelId)
        {
            Id = id;
            Name = name;
            Photo = photo;
            Brand = brand;
            Color = color;
            Doors = doors;
            Steering = steering;
            Trunk = trunk;
            Price = price;
            ModelId = modelId;
        }

    }
}
