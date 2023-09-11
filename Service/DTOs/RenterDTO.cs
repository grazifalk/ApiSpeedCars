namespace Service.DTOs
{
    public class RenterDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string IdentityDocumentNumber { get; set; }
        public string DriverLicenseNumber { get; set; }
        public string DocumentType { get; set; }

        public RenterDTO() { }

        public RenterDTO(int id, string name, DateTime birth, string phoneNumber, string address, string email, string cPF, string identityDocumentNumber, string driverLicenseNumber, string documentType)
        {
            Id = id;
            Name = name;
            Birth = birth;
            PhoneNumber = phoneNumber;
            Address = address;
            Email = email;
            CPF = cPF;
            IdentityDocumentNumber = identityDocumentNumber;
            DriverLicenseNumber = driverLicenseNumber;
            DocumentType = documentType;
        }
    }
}
