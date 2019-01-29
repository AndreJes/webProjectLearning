using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace dotNetProject.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Invalid {0} Size: {0} must be between {2} and {1}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Enter a valid Email!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Range(100.0, 50000.0, ErrorMessage = "Base Salary must be from {1} to {2}")]
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();


        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime date, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            Date = date;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSale(SalesRecord sale)
        {
            Sales.Add(sale);
        }

        public void RemoveSale(SalesRecord sale)
        {
            Sales.Remove(sale);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sale => sale.Date >= initial && sale.Date <= initial).Sum(sale => sale.Amount);
        }
    }
}
