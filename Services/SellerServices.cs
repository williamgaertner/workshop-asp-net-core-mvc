using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Data;
using SalesWebMvc.Models;

namespace SalesWebMvc.Services
{
    public class SellerServices
    {
        private readonly SalesWebMvcContext _context; // declarando um dependencia para o banco de dados db context

        public SellerServices(SalesWebMvcContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll() // crinando operação para retornar todos os vendedores
        {
            // operação sincrona
            return _context.Seller.ToList(); // acessando os dados de todos os vendedores e convertendo para uma lista
        }

        public void Insert(Seller obj) // metodo para inserir seller no banco de dados 
        {
            _context.Add(obj); // inserindo seller no banco de dados 
            _context.SaveChanges(); // salvando dados no banco de dados 
        }
    }
}
