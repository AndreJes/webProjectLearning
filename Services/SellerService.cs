using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNetProject.Models;
using Microsoft.EntityFrameworkCore;
using dotNetProject.Services.Exceptions;

namespace dotNetProject.Services
{
    public class SellerService
    {
        private readonly dotNetProjectContext _context;

        public SellerService(dotNetProjectContext context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Sellers.ToListAsync();
        }

        public async Task Insert(Seller obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Sellers.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Sellers.FindAsync(id);
                _context.Sellers.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException("Can't delete seller because he/she has sales");
            }
        }

        public async Task UpdateAsync(Seller obj)
        {
            bool HasAny = await _context.Sellers.AnyAsync(x => x.Id == obj.Id);

            if (!HasAny)
            {
                throw new NotFoundException("ID not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException("An exception occured: " + e.Message);
            }
        }
    }
}
