using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} tamanho tem que ser entre {2} e {1}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [EmailAddress(ErrorMessage = "{0} email required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Range(100.0, 5000.0, ErrorMessage = "{0} salary betwen {2} and {1}")]
        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BaseSalary { get; set; }
        public ICollection<SalesRecord> SalesRecordy { get; set; } = new List<SalesRecord>();
        public Department Department { get; set; }
        public int DepartmentId { get; set; }

        public Seller()
        {

        }

        public Seller(int id, string name, string email, DateTime date, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = date;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord sr)
        {
            SalesRecordy.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            SalesRecordy.Remove(sr);
        }

        public double TotalSales(DateTime inital, DateTime final)
        {
            return SalesRecordy.Where(sr => sr.Date >= inital && sr.Date <= final).Sum(sr => sr.Amount); // caulcula o total de vendas de um vendedor pelo periodo
        }


    }
}
