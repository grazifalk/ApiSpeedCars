using Data.Context;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly ContextDb _db;

        public CarRepository(ContextDb db)
        {
            this._db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<Car> Create(Car car)
        {
            _db.Cars.Add(car);
            await _db.SaveChangesAsync();
            return car;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var car = await _db.Cars.Where(r => r.Id == id).FirstOrDefaultAsync();
                if (car == null) return false;
                _db.Cars.Remove(car);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ICollection<Car>> FindAll()
        {
            var car = await _db.Cars.ToListAsync();
            return car;
        }

        public async Task<Car> FindById(int id)
        {
            var car = await _db.Cars.FirstOrDefaultAsync(r => r.Id == id);
            return car;
        }

        public async Task<Car> FindByName(string name)
        {
            var car = await _db.Cars.Include(r => r.Model).FirstOrDefaultAsync(r => r.Name == name);
            return car;
        }

        public async Task<bool> IsCarUnique(string name)
        {
            return !await _db.Cars.AnyAsync(car => car.Name == name);
        }

        public async Task<Car> Update(Car car)
        {
            _db.Cars.Update(car);
            await _db.SaveChangesAsync();
            return car;
        }
    }
}
