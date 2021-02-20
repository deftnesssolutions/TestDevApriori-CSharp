using Orcamento.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using GO.DAO;
using GO.Entities;
using GO.Providers;
using System.ComponentModel.DataAnnotations;

namespace Orcamento.Web.Models
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe o senha")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o e-mail")]
        public string Email { get; set; }

        public static UsuarioViewModel ValidarUsuario(string login, string senha)
        {
            UsuarioViewModel ret = null;
            Usuario u = new Usuario();
            u = DAOUsuario.ValidarCredenciales(login, CriptoHelper.HashMD5(senha));
            if (u != null)
            {
                ret = new UsuarioViewModel
                {
                    Id = u.Id,
                    Login = u.Login,
                    Senha = u.Senha,
                    Nome = u.Nome
                };
            }
            
            return ret;
        }

        //Recupera todos os usuarios da tabela Usuario do Banco de Dados
        public static List<UsuarioViewModel> GetAll()
        {
            var ret = new List<UsuarioViewModel>();
            using (IConnection Conexion = new Connection())
            {
                IDAO<Usuario> dao = new DAOUsuario(Conexion);
                foreach (Usuario u in dao.All())
                {
                    ret.Add(new UsuarioViewModel
                    {
                        Id = u.Id,
                        Nome = u.Nome,
                        Login = u.Login
                    });
                }
            }
            return ret;
        }
        //Recupera o Usuario pelo ID da Base de dados
        public static UsuarioViewModel GetFindOrDefault(int id)
        {
            UsuarioViewModel ret = null;
            using (IConnection conexion = new Connection())
            {
                IDAO<Usuario> dao = new DAOUsuario(conexion);
                Usuario u = dao.FindOrDefault(id);
                if (u != null)
                {
                    ret = new UsuarioViewModel
                    {
                        Id = u.Id,
                        Nome = u.Nome,
                        Login = u.Login,
                    };
                }
            }
            return ret;
        }
        //Deleta o Usuario da Base de Dados pelo ID 
        public static bool Delete(int id)
        {
            var ret = false;
            using (IConnection Conexion = new Connection())
            {
                IDAO<Usuario> dao = new DAOUsuario(Conexion);
                Usuario u = dao.FindOrDefault(id);
                if (u != null)
                {
                    ret = dao.Delete(u);
                }
            }

            return ret;
        }

        //Persiste os dados do Usuario na Base de Dados
        public int Salvar()
        {
            var ret = 0;
            var model = GetFindOrDefault(this.Id);
            if (model == null)
            {
                using (IConnection Conexion = new Connection())
                {
                    IDAO<Usuario> dao = new DAOUsuario(Conexion);
                    Usuario u = new Usuario();//Objeto tipo Modulos(tabela)
                    u.Login = this.Login;
                    u.Senha = CriptoHelper.HashMD5(this.Senha);
                    u.Nome = this.Nome;
                    ret = dao.Insert(u).Id;
                }
            }
            else
            {
                using (IConnection Conexion = new Connection())
                {
                    IDAO<Usuario> dao = new DAOUsuario(Conexion);
                    Usuario u = new Usuario();
                    u.Login = this.Login;
                    u.Senha = CriptoHelper.HashMD5(this.Senha);
                    u.Nome = this.Nome;
                    dao.Update(u);
                    ret = this.Id;
                }
            }
            return ret;
        }

        internal static UsuarioViewModel RecuperarPeloId(int id)
        {
            throw new NotImplementedException();
        }
    }
}