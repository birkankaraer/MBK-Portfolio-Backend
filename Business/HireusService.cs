using System.Collections.Generic;
using System.Linq;
using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Business
{
    public class HireusService
    {
        private readonly GlobalDbContext _context;

        public HireusService(GlobalDbContext context)
        {
            _context = context;
        }

        public List<Hireus> GetAllHireuses()
        {
            return _context.Hireuses.ToList();
        }

        public Hireus GetHireusById(int id)
        {
            return _context.Hireuses.Find(id);
        }

        public void AddHireus(Hireus hireus)
        {
            _context.Hireuses.Add(hireus);
            _context.SaveChanges();
        }

        public void UpdateHireus(Hireus hireus)
        {
            _context.Entry(hireus).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteHireus(int id)
        {
            var hireus = _context.Hireuses.Find(id);
            if (hireus != null)
            {
                _context.Hireuses.Remove(hireus);
                _context.SaveChanges();
            }
        }
    }
}
