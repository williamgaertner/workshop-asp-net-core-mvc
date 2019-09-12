using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerServices _sellerService; // criando uma dependencia para sellers services
        private readonly DepartmentServices _departmentService;

        public SellersController(SellerServices sellerService, DepartmentServices departmentService) // criando construtor com injeção de dependencia 
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll(); //retornar uma lista de service seller
            return View(list); // dinamica do mvc
        }

        public IActionResult Create() // retorna a visualização apos açao de apertar o botão create 
        {
            var departments = _departmentService.FindAll(); // procurar todos os departamentos
            var depviewmodel = new SallerFormViewModel() {Departments = departments}; // instanciando a classe e inicializando com os departamentos
            return View(depviewmodel); // mostrando a tela de departamentos
        }

        [HttpPost] // metodo post
        [ValidateAntiForgeryToken] // validação de segurança para seções abertas
        public IActionResult Create(Seller seller) // criando o metodo crete post para envio apos a usuario apertar o botao enviar
        {
            _sellerService.Insert(seller); // insere o seller no banco de dados acessando o metodo insert (SellerService)
            return RedirectToAction(nameof(Index)); // redireciona para a pagina index
        }

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var obj = _sellerService.FindById(id.Value);
            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
    }
}