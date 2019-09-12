using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Services.Exception;

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
            //obj.Department = _context.Department.First(); // adiciona o primeiro departamento ao banco de dados.
            _context.Add(obj); // inserindo seller no banco de dados 
            _context.SaveChanges(); // salvando dados no banco de dados 
        }

        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Seller obj)
        {
            if(!_context.Seller.Any(x => x.Id == obj.Id)) // se não existir um seller x cujo id seja igual ao do objeto
            {
                throw new NotFoundException("Not found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
