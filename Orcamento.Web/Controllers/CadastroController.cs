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
        [Authorize]
        public ActionResult Cliente()
        {
            return View();
        }
        [Authorize]
        public ActionResult Produto()
        {
            return View();
        }
        [Authorize]
        public ActionResult Orcamento()
        {
            return View();
        }
    }
}