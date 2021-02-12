using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Orcamento.Web.Controllers
{
    public class CadastroController : Controller
    {
        // GET: Cadastro
        public ActionResult Cliente()
        {
            return View();
        }
        public ActionResult Produto()
        {
            return View();
        }
        public ActionResult Orcamento()
        {
            return View();
        }
    }
}