using Domain.Entities.Base;
using Domain.Validations;

namespace Domain.Entities
{
    public sealed class Car : BaseEntity
    {
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
        public int ModelId { get; set; } // Chave estrangeira para o modelo
        public Model Model { get; set; } // Propriedade de navegação para o modelo

        public Car() { }

        public Car(string name, string photo, string brand, string color, int doors, string steering, bool powerWindow, bool powerDoorLocks, bool airConditioner, string trunk, double price, bool available, int modelId, Model model)
        {
            Validation(name, photo, brand, color, doors, steering, trunk, price);
            PowerWindow = powerWindow;
            PowerDoorLocks = powerDoorLocks;
            AirConditioner = airConditioner;
            Available = available;
        }

        public Car(int id, string name, string photo, string brand, string color, int doors, string steering, bool powerWindow, bool powerDoorLocks, bool airConditioner, string trunk, double price, bool available, int modelId, Model model)
        {
            DomainValidationException.When(id < 0, "Id deve ser maior do que zero");
            Id = id;
            PowerWindow = powerWindow;
            PowerDoorLocks = powerDoorLocks;
            AirConditioner = airConditioner;
            Available = available;
            Validation(name, photo, brand, color, doors, steering, trunk, price);
        }

        private void Validation(string name, string photo, string brand, string color, int doors, string steering, string trunk, double price)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "O nome deve ser informado corretamente");
            DomainValidationException.When(string.IsNullOrEmpty(photo), "A url da foto do carro deve ser informada corretamente");
            DomainValidationException.When(string.IsNullOrEmpty(brand), "A marca deve ser informada corretamente");
            DomainValidationException.When(string.IsNullOrEmpty(color), "A cor deve ser informada corretamente");
            DomainValidationException.When(doors <= 0, "A quantidade de portas deve ser informada corretamente");
            DomainValidationException.When(string.IsNullOrEmpty(steering), "O tipo de direção deve ser informado corretamente");
            DomainValidationException.When(string.IsNullOrEmpty(trunk), "O tamanho do porta malas deve ser informado corretamente");
            DomainValidationException.When(price <= 0, "O preço do aluguel deve ser informado corretamente");

            Name = name;
            Photo = photo;
            Brand = brand;
            Color = color;
            Doors = doors;
            Steering = steering;
            Trunk = trunk;
            Price = price;
        }

        public override string? ToString()
        {
            return $"{Id}";
        }
    }
}
