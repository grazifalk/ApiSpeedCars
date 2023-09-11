using Domain.Entities;

namespace Domain.Repositories
{
    public interface IRenterRepository
    {
        Task<Renter> FindById(int id);
        Task<Renter> FindByName(string name);
        Task<Renter> FindByCPF(string cpf);
        Task<Renter> FindByRG(string identityDocumentNumber);
        Task<Renter> FindByCNH(string driverLicenseNumber);
        Task<ICollection<Renter>> FindAll();
        Task<Renter> Create(Renter renter);
        Task<Renter> Update(Renter renter);
        Task<bool> Delete(int id);
        Task<bool> IsRenterUnique(string cpf);
    }
}
