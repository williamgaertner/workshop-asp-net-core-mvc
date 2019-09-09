using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;
using SalesWebMvc.Models;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerServices _sellerService; // criando uma dependencia para sellers services

        public SellersController(SellerServices sellerService) // criando construtor com injeção de dependencia 
        {
            _sellerService = sellerService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll(); //retornar uma lista de service seller
            return View(list); // dinamica do mvc
        }

        public IActionResult Create() // retorna a visualização apos açao de apertar o botão create 
        {
            return View(); 
        }

        [HttpPost] // metodo post
        [ValidateAntiForgeryToken] // validação de segurança para seções abertas
        public IActionResult Create(Seller seller) // criando o metodo crete post para envio apos a usuario apertar o botao enviar
        {
            _sellerService.Insert(seller); // insere o seller no banco de dados acessando o metodo insert (SellerService)
            return RedirectToAction(nameof(Index)); // redireciona para a pagina index
        }
    }
}