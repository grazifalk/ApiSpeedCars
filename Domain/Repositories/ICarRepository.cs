using Domain.Entities;

namespace Domain.Repositories
{
    public interface ICarRepository
    {
        Task<Car> FindById(int id);
        Task<Car> FindByName(string name);
        Task<ICollection<Car>> FindAll();
        Task<Car> Create(Car car);
        Task<Car> Update(Car car);
        Task<bool> Delete(int id);
        Task<bool> IsCarUnique(string name);
    }
}
