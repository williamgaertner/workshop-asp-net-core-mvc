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

        public async Task<List<Seller>> FindAllAsync() // crinando operação para retornar todos os vendedores
        {
            // operação sincrona
            return await _context.Seller.ToListAsync(); // acessando os dados de todos os vendedores e convertendo para uma lista
        }

        public async Task InsertAsync(Seller obj) // metodo para inserir seller no banco de dados 
        {
            //obj.Department = _context.Department.First(); // adiciona o primeiro departamento ao banco de dados.
            _context.Add(obj); // inserindo seller no banco de dados 
            await _context.SaveChangesAsync(); // salvando dados no banco de dados 
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Seller.FindAsync(id);
            _context.Seller.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Seller obj)
        {
            bool HasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
            if (!HasAny) // se não existir um seller x cujo id seja igual ao do objeto
            {
                throw new NotFoundException("Not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
