using Service.DTOs;
using Service.Exceptions;

namespace Service.Interfaces
{
    public interface IModelService
    {
        Task<ResultService<ICollection<ModelDTO>>> FindAll();
        Task<ResultService<ModelDTO>> FindById(int id);
        Task<ResultService<ModelDTO>> Create(ModelDTO modelDTO);
        Task<ResultService<ModelDTO>> Update(ModelDTO modelDTO);
        Task<ResultService> Delete(int id);
    }
}
