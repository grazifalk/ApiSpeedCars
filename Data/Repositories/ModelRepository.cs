using Data.Context;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class ModelRepository : IModelRepository
    {
        private readonly ContextDb _db;
        public ModelRepository(ContextDb db)
        {
            this._db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<Model> Create(Model model)
        {
            _db.Models.Add(model);
            await _db.SaveChangesAsync();
            return model;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var model = await _db.Models.Where(r => r.Id == id).FirstOrDefaultAsync();
                if (model == null) return false;
                _db.Models.Remove(model);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ICollection<Model>> FindAll()
        {
            var model = await _db.Models.ToListAsync();
            return model;
        }

        public async Task<Model> FindById(int id)
        {
            var model = await _db.Models.FirstOrDefaultAsync(r => r.Id == id);
            return model;
        }

        public async Task<Model> FindByName(string name)
        {
            var model = await _db.Models.Include(r => r.Name).FirstOrDefaultAsync(r => r.Name == name);
            return model;
        }

        public async Task<bool> IsModelUnique(string name)
        {
            return !await _db.Models.AnyAsync(recipe => recipe.Name == name);
        }

        public async Task<Model> Update(Model model)
        {
            _db.Models.Update(model);
            await _db.SaveChangesAsync();
            return model;
        }
    }
}
