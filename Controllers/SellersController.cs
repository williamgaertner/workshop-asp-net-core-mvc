using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;

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
    }
}