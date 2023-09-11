using Domain.Entities;

namespace Domain.Repositories
{
    public interface IModelRepository
    {
        Task<Model> FindById(int id);
        Task<Model> FindByName(string name);
        Task<ICollection<Model>> FindAll();
        Task<Model> Create(Model model);
        Task<Model> Update(Model model);
        Task<bool> Delete(int id);
        Task<bool> IsModelUnique(string name);
    }
}
