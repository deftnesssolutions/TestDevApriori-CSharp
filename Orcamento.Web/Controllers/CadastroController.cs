﻿using Orcamento.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Orcamento.Web.Controllers
{
    public class CadastroController : Controller
    {
        private const int _quantMaxLinhasPorPagina = 5;
        #region CRUD Usuario
        private const string _senhaPadrao = "{$127;$188}";

        [Authorize]
        public ActionResult Usuario()
        {
            ViewBag.SenhaPadrao = _senhaPadrao;
            return View(UsuarioViewModel.GetAll());
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult RecuperarUsuario(int id)
        {
            //return Json(_listaUsuario.Find(x => x.Id == id));
            return Json(UsuarioViewModel.GetFindOrDefault(id));
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirUsuario(int id)
        {
            return Json(UsuarioViewModel.Delete(id));
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult SalvarUsuario(UsuarioViewModel model)
        {
            var resultado = "OK";
            var mensagens = new List<string>();
            var idSalvo = string.Empty;

            if (!ModelState.IsValid)
            {
                resultado = "AVISO";
                mensagens = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                try
                {
                    if (model.Senha == _senhaPadrao)
                    {
                        model.Senha = "";
                    }
                    var id = model.Salvar();
                    if (id > 0)
                    {
                        idSalvo = id.ToString();
                    }
                    else
                    {
                        resultado = "ERRO";
                    }
                }
                catch (Exception ex)
                {
                    resultado = "ERRO";
                }
            }

            return Json(new { Resultado = resultado, Mensagens = mensagens, IdSalvo = idSalvo });
        }
        #endregion
        #region CRUD Produto
        [Authorize]
        public ActionResult Produto()
        {
            var lista = ProdutoViewModel.GetAll();
            ViewBag.ListaTamPag = new SelectList(new int[] { _quantMaxLinhasPorPagina, 10, 15, 20 }, _quantMaxLinhasPorPagina);
            ViewBag.QuantMaxLinhasPorPagina = _quantMaxLinhasPorPagina;
            ViewBag.PaginaAtual = 1;

            var difQuantPaginas = (lista.Count % ViewBag.QuantMaxLinhasPorPagina) > 0 ? 1 : 0;
            ViewBag.QuantPaginas = (lista.Count / ViewBag.QuantMaxLinhasPorPagina) + difQuantPaginas;
            return View(ProdutoViewModel.GetAll());
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public JsonResult ProdutoPagina(int pagina, int tamPag)
        {
            var lst = ProdutoViewModel.GetAll();
            List<ProdutoViewModel> lista = new List<ProdutoViewModel>();
            var pos = (pagina - 1) * tamPag;
            var max = 0;
            if (pos == 0)
            {
                max = tamPag - 1;
            }
            else
            {

                max = pos + tamPag - 1;
                if (max >= lst.Count)
                {
                    max = lst.Count - 1;
                }
            }
            for (int i = pos; i <= (max); i++)
            {
                lista.Add(lst[i]);
            }
            return Json(lista);
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public JsonResult RecuperarProduto(int id)
        {
            //return Json(_listaProduto.Find(x => x.Id == id));
            return Json(ProdutoViewModel.GetFindOrDefault(id));
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public JsonResult ExcluirProduto(int id)
        {
            #region Teste de funcionalidade com lista na memoria
            /*
            var ret = false;
            var registroBD = _listaProduto.Find(x => x.Id == id);
            if (registroBD != null)
            {
                _listaProduto.Remove(registroBD);
                ret = true;
            }*/
            #endregion
            return Json(ProdutoViewModel.Delete(id));
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public JsonResult SalvarProduto(ProdutoViewModel model)
        {
            var resultado = "OK";
            var mensagens = new List<string>();
            var idSalvo = string.Empty;

            if (!ModelState.IsValid)
            {
                resultado = "AVISO";
                mensagens = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                try
                {
                    #region Teste funcionalidade com lista em memoria
                    /*
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
                    idSalvo = registroBD.Id.ToString();
                    */
                    #endregion
                    var id = model.Salvar();
                    if (id > 0)
                    {
                        idSalvo = id.ToString();
                    }
                    else
                    {
                        resultado = "ERRO";
                    }
                }
                catch (Exception ex)
                {
                    resultado = "ERRO";
                }
            }

            return Json(new { Resultado = resultado, Mensagens = mensagens, IdSalvo = idSalvo });
        }
        #endregion
        [Authorize]
        public ActionResult Cliente()
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