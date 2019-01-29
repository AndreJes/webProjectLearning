using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNetProject.Models;

namespace dotNetProject.Services
{
    public class SellerService
    {
        private readonly dotNetProjectContext _context;

        public SellerService(dotNetProjectContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Sellers.ToList();
        }

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
