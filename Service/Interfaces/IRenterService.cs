using Domain.Entities;
using Service.DTOs;
using Service.Exceptions;

namespace Service.Interfaces
{
    public interface IRenterService
    {
        Task<ResultService<ICollection<RenterDTO>>> FindAll();
        Task<ResultService<RenterDTO>> FindById(int id);
        Task<ResultService<RenterDTO>> FindByName(string name);
        Task<ResultService<RenterDTO>> FindByCPF(string cpf);
        Task<ResultService<RenterDTO>> FindByRG(string identityDocumentNumber);
        Task<ResultService<RenterDTO>> FindByCNH(string driverLicenseNumber);
        Task<ResultService<RenterDTO>> Create(RenterDTO renterDTO);
        Task<ResultService<RenterDTO>> Update(RenterDTO renterDTO);
        Task<ResultService> Delete(int id);
    }
}