using Microsoft.EntityFrameworkCore;
using Temperature.Contexts;
using Temperature.Models;
using Temperature.Repositories;

namespace Temperature.Repositories
{
    public class TempDbRepository : ITempRepository
    {
        private TempDbContext _context;

            public TempDbRepository(TempDbContext context)
            {
            _context = context;
             }

        public Temperatures Add(Temperatures newTemp)
        {
            
            _context.temperatures.Add(newTemp);
            _context.SaveChanges();
            return newTemp;

        }

        public Temperatures? Delete(int Id)
        {
            Temperatures? TempBeDeleted = _context.temperatures.Find(Id);
            if (TempBeDeleted != null)
            {
                _context.temperatures.Remove(TempBeDeleted);
                _context.SaveChanges();
            }
            return TempBeDeleted;
        }

        public List<Temperatures> GetAll()
        {
            return _context.temperatures.ToList();
        }

        public Temperatures? GetById(int Id)
        {
            return _context.temperatures.Find(Id);
        }
    }
}
