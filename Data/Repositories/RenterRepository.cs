using Data.Context;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Data.Repositories
{
    public class RenterRepository : IRenterRepository
    {
        private readonly ContextDb _db;

        public RenterRepository(ContextDb db)
        {
            this._db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<Renter> Create(Renter renter)
        {
            _db.Renters.Add(renter);
            await _db.SaveChangesAsync();
            return renter;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var renter = await _db.Renters.Where(r => r.Id == id).FirstOrDefaultAsync();
                if (renter == null) return false;
                _db.Renters.Remove(renter);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ICollection<Renter>> FindAll()
        {
            var renter = await _db.Renters.ToListAsync();
            return renter;
        }

        public async Task<Renter> FindByCNH(string driverLicenseNumber)
        {
            var renter = await _db.Renters.FirstOrDefaultAsync(r => r.DriverLicenseNumber == driverLicenseNumber);
            return renter;
        }

        public async Task<Renter> FindByCPF(string cpf)
        {
            var renter = await _db.Renters.FirstOrDefaultAsync(r => r.CPF == cpf);
            return renter;
        }

        public async Task<Renter> FindById(int id)
        {
            var renter = await _db.Renters.FirstOrDefaultAsync(r => r.Id == id);
            return renter;
        }

        public async Task<Renter> FindByName(string name)
        {
            var renter = await _db.Renters.Include(r => r.Name).FirstOrDefaultAsync(r => r.Name == name);
            return renter;
        }

        public async Task<Renter> FindByRG(string identityDocumentNumber)
        {
            var renter = await _db.Renters.FirstOrDefaultAsync(r => r.IdentityDocumentNumber == identityDocumentNumber);
            return renter;
        }

        public async Task<bool> IsRenterUnique(string cpf)
        {
            return !await _db.Renters.AnyAsync(car => car.CPF == cpf);
        }

        public async Task<Renter> Update(Renter renter)
        {
            _db.Renters.Update(renter);
            await _db.SaveChangesAsync();
            return renter;
        }
    }
}
