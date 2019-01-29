using dotNetProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace dotNetProject.Services
{
    public class DepartmentService
    {
        private readonly dotNetProjectContext _context;

        public DepartmentService(dotNetProjectContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
