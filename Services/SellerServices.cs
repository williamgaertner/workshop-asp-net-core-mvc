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
    }
}
