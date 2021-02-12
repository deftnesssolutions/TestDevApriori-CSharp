using Orcamento.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Orcamento.Web.Controllers
{
    public class CadastroController : Controller
    {

        private static List<ProdutoViewModel> _listaProduto = new List<ProdutoViewModel>()
        {
            new ProdutoViewModel() { Id=1, Nome="Livros", Preco = 10 },
            new ProdutoViewModel() { Id=2, Nome="Mouses", Preco = 20 },
            new ProdutoViewModel() { Id=3, Nome="Monitores", Preco = 30 }
        };

        [Authorize]
        public ActionResult Cliente()
        {
            return View();
        }

        [Authorize]
        public ActionResult Produto()
        {
            return View(_listaProduto);
        }

        [HttpPost]
        [Authorize]
        public ActionResult RecuperarProduto(int id)
        {
            return Json(_listaProduto.Find(x => x.Id == id));
        }

        [HttpPost]
        [Authorize]
        public ActionResult ExcluirProduto(int id)
        {
            var ret = false;

            var registroBD = _listaProduto.Find(x => x.Id == id);
            if (registroBD != null)
            {
                _listaProduto.Remove(registroBD);
                ret = true;
            }

            return Json(ret);
        }

        [HttpPost]
        [Authorize]
        public ActionResult SalvarProduto(ProdutoViewModel model)
        {
            var registroBD = _listaProduto.Find(x => x.Id == model.Id);

            if (registroBD == null)
            {
                registroBD = model;
                registroBD.Id = _listaProduto.Max(x => x.Id) + 1;
                _listaProduto.Add(registroBD);
            }
            else
            {
                registroBD.Nome = model.Nome;
                registroBD.Preco = model.Preco;
            }

            return Json(registroBD);
        }

        [Authorize]
        public ActionResult Orcamento()
        {
            return View();
        }
    }
}