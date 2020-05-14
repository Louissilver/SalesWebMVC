using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        //ID
        public int Id { get; set; }

        //NAME
        [Required(ErrorMessage ="{0} required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage ="Name size should be between 3 and 60")]
  
        public string Name { get; set; }
        
        //EMAIL
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="Enter a valid e-mail")]
        [Required(ErrorMessage = "{0} required")]
        public string Email { get; set; }
        
        //BIRTHDATE
        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        //BASESALARY
        [Required(ErrorMessage = "{0} required")]
        [Range(100.00, 50000.00, ErrorMessage ="{0} must be from {1} to {2}")]
        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BaseSalary { get; set; }

        //DEPARTMENT
        public Department Department { get; set; }

        //DEPARTMENTID
        public int DepartmentId { get; set; }

        //SALES
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }
        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
