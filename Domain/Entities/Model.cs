using Domain.Entities.Base;
using Domain.Validations;

namespace Domain.Entities
{
    public class Model : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Car> Cars { get; set; }
        public Model() { }

        public Model(string name, List<Car> cars)
        {
            Validation(name);
            Cars = cars;
        }

        public Model(int id, string name)
        {
            DomainValidationException.When(id < 0, "Id deve ser informado");
            Id = id;
            Cars = new List<Car>();
            Validation(name);
        }

        private void Validation(string name)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "O nome do modelo deve ser informado");

            Name = name;
        }

        public override string? ToString()
        {
            return $"{Id}";
        }
    }
}
