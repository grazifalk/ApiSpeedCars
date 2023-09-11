using Domain.Entities.Base;
using Domain.Validations;

namespace Domain.Entities
{
    public class Renter : BaseEntity
    {
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string IdentityDocumentNumber { get; set; }
        public string DriverLicenseNumber { get; set; }
        public string DocumentType { get; set; }

        public Renter() { }

        public Renter(string name, DateTime birth, string phoneNumber, string address, string email, string cpf, string identityDocumentNumber, string driverLicenseNumber, string documentType)
        {
            Validation(name, birth, phoneNumber, address, email, cpf, identityDocumentNumber, driverLicenseNumber, documentType);
        }

        public Renter(int id, string name, DateTime birth, string phoneNumber, string address, string email, string cpf, string identityDocumentNumber, string driverLicenseNumber, string documentType)
        {
            DomainValidationException.When(id < 0, "Id deve ser maior do que zero");
            Id = id;
            Validation(name, birth, phoneNumber, address, email, cpf, identityDocumentNumber, driverLicenseNumber, documentType);
        }

        private void Validation(string name, DateTime birth, string phoneNumber, string address, string email, string cpf, string identityDocumentNumber, string driverLicenseNumber, string documentType)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "O nome deve ser informado corretamente");
            DomainValidationException.When(birth == DateTime.MinValue, "A data de nascimento deve ser informada corretamente");
            DomainValidationException.When(string.IsNullOrEmpty(phoneNumber), "O número de telefone deve ser informado corretamente");
            DomainValidationException.When(string.IsNullOrEmpty(address), "O endereço deve ser informado corretamente");
            DomainValidationException.When(string.IsNullOrEmpty(email), "O e-mail deve ser informado corretamente");
            DomainValidationException.When(string.IsNullOrEmpty(cpf), "O CPF deve ser informado corretamente");
            DomainValidationException.When(string.IsNullOrEmpty(identityDocumentNumber), "O número do documento de identidade deve ser informado corretamente");
            DomainValidationException.When(string.IsNullOrEmpty(driverLicenseNumber), "O número da carteira de motorista deve ser informado corretamente");
            DomainValidationException.When(string.IsNullOrEmpty(documentType), "O tipo do documento deve ser informado corretamente");

            Name = name;
            Birth = birth;
            PhoneNumber = phoneNumber;
            Address = address;
            Email = email;
            CPF = cpf;
            IdentityDocumentNumber = identityDocumentNumber;
            DriverLicenseNumber = driverLicenseNumber;
            DocumentType = documentType;
        }

        public override string? ToString()
        {
            return $"{Id}";
        }
    }
}
