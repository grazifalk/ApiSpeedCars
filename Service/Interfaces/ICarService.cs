using Service.DTOs;
using Service.Exceptions;

namespace Service.Interfaces
{
    public interface ICarService
    {
        Task<ResultService<ICollection<CarDTO>>> FindAll();
        Task<ResultService<CarDTO>> FindById(int id);
        Task<ResultService<CarDTO>> Create(CarDTO carDTO);
        Task<ResultService<CarDTO>> Update(CarDTO carDTO);
        Task<ResultService> Delete(int id);
    }
}
