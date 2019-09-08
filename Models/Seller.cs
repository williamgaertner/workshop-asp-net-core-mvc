using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
        public ICollection<SalesRecord> SalesRecordy { get; set; } = new List<SalesRecord>();
        public Department Department { get; set; }

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
