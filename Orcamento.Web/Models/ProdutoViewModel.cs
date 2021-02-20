using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GO.DAO;
using GO.Providers;
using GO.Entities;

namespace Orcamento.Web.Models
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o nome.")]
        [MaxLength(50, ErrorMessage = "O nome pode ter no máximo 50 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o preço.")]
        public decimal Preco { get; set; }

        //Recupera todos os produtos da tabela Produto do Banco de Dados
        public static List<ProdutoViewModel> GetAll()
        {
            var ret = new List<ProdutoViewModel>();
            using (IConnection Conexion = new Connection())
            {
                IDAO<Produto> dao = new DAOProduto(Conexion);
                foreach (Produto p in dao.All())
                {
                    ret.Add(new ProdutoViewModel
                    {
                        Id = p.Id,
                        Nome = p.Nome,
                        Preco = p.preço
                    });
                }
            }
            return ret;
        }
        //Recupera o produto pelo ID da Base de dados
        public static ProdutoViewModel GetFindOrDefault(int id)
        {
            ProdutoViewModel ret = null;
            using (IConnection conexion = new Connection())
            {
                IDAO<Produto> dao = new DAOProduto(conexion);
                Produto p = dao.FindOrDefault(id);
                if (p != null)
                {
                    ret = new ProdutoViewModel
                    {
                        Id = p.Id,
                        Nome = p.Nome,
                        Preco = p.preço
                    };
                }
            }
            return ret;
        }
        //Deleta o produto da Base de Dados pelo ID 
        public static bool Delete(int id)
        {
            var ret = false;
            using (IConnection Conexion = new Connection())
            {
                IDAO<Produto> dao = new DAOProduto(Conexion);
                Produto p = dao.FindOrDefault(id);
                if (p != null)
                {
                    ret = dao.Delete(p);
                }
            }

            return ret;
        }

        //Persiste os dados do produto na Base de Dados
        public int Salvar()
        {
            var ret = 0;
            var model = GetFindOrDefault(this.Id);
            if (model == null)
            {
                using (IConnection Conexion = new Connection())
                {
                    IDAO<Produto> dao = new DAOProduto(Conexion);
                    Produto p = new Produto();//Objeto tipo Modulos(tabela)
                    p.Nome = this.Nome;
                    p.preço = this.Preco;
                    ret = dao.Insert(p).Id;
                }
            }
            else
            {
                using (IConnection Conexion = new Connection())
                {
                    IDAO<Produto> dao = new DAOProduto(Conexion);
                    Produto p = new Produto();
                    p.Id = this.Id;
                    p.Nome = this.Nome;
                    p.preço = this.Preco;
                    dao.Update(p);
                    ret = this.Id;
                }
            }
            return ret;
        }
    }
}