using GO.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GO.Entities;
using GO.Providers;
using GO.DAO;

namespace Teste
{
    class Program
    {
        public static string xid = "1";
        static void Main(string[] args)
        {
            using (IConnection conn = new Connection())
            {
                conn.Open();
                conn.Close();
            }
           
            #region Teste Cliente       
            int i = 0; // Usa-se o nome i ou j a variavel, pois é usal em lógica matemática.
            /*
           for (i = 1; i <= 3; i++)
           {
               using (IConnection Conexion = new Connection())
               {
                   IDAO<Cliente> dao = new DAOCliente(Conexion);
                   Cliente cli = new Cliente();//Objeto tipo Modulos(tabela)
                   Cliente result = new Cliente();
                   //cli.Id = i;
                   cli.Nome = "teste insert";
                   cli.Telefone = "67123456";
                   // gravo los datos como registro en la tabla modulos
                   result = dao.Insert(cli);
               }

           }
           xid = "2";
           using (IConnection Conexion = new Connection())
           {
               IDAO<Cliente> dao = new DAOCliente(Conexion);
               Cliente cli = dao.FindOrDefault(xid);
               cli.Nome = "Teste Update";
               cli.Telefone = "67123456";
              dao.Update(cli);                
           }

           xid = "3";
           using (IConnection Conexion = new Connection())
           {
               IDAO<Cliente> dao = new DAOCliente(Conexion);
               Cliente cli = dao.FindOrDefault(xid);
               bool result = dao.Delete(cli);
                
           }
             
           using (IConnection Conexion = new Connection())
           {
               IDAO<Cliente> dao = new DAOCliente(Conexion);
               Cliente cli = new Cliente();
               List<Cliente> listCli = new List<Cliente>();
               foreach (Cliente c in dao.All())
               {
                   cli.Id = c.Id;
                   cli.Nome = c.Nome;
                   cli.Telefone = c.Telefone;
                   listCli.Add(cli);
               }
               int result = listCli.Count;                
           }

           using (IConnection Conexion = new Connection())
           {
               IDAO<Cliente> dao = new DAOCliente(Conexion);
               string result = dao.CurremRegVal();

           }  
             */
           #endregion
            
           #region Teste Produto
            /*
           i = 0; // Usa-se o nome i ou j a variavel, pois é usal em lógica matemática.
           for (i = 1; i <= 3; i++)
           {
               using (IConnection Conexion = new Connection())
               {
                   IDAO<Produto> dao = new DAOProduto(Conexion);
                   Produto p = new Produto();//Objeto tipo Modulos(tabela)
                   Produto result = new Produto();
                   //p.Id = i;
                   p.Nome = "teste insert";
                   p.preço = 10;
                   // gravo los datos como registro en la tabla modulos
                   result = dao.Insert(p);
               }

           }

           xid = "2";
           using (IConnection Conexion = new Connection())
           {
               IDAO<Produto> dao = new DAOProduto(Conexion);
               Produto p = dao.FindOrDefault(xid);
               p.Nome = "Teste Update";
               p.preço = 15;
               dao.Update(p);
           }

           xid = "3";
           using (IConnection Conexion = new Connection())
           {
               IDAO<Produto> dao = new DAOProduto(Conexion);
               Produto p = dao.FindOrDefault(xid);
               bool result = dao.Delete(p);

           }

           using (IConnection Conexion = new Connection())
           {
               IDAO<Produto> dao = new DAOProduto(Conexion);
               Produto prd = new Produto();
               List<Produto> listPrd = new List<Produto>();
               foreach (Produto p in dao.All())
               {
                   prd.Id = p.Id;
                   prd.Nome = p.Nome;
                   prd.preço = p.preço;
                   listPrd.Add(prd);
               }
               int result = listPrd.Count;
           }

           using (IConnection Conexion = new Connection())
           {
               IDAO<Produto> dao = new DAOProduto(Conexion);
               string result = dao.CurremRegVal();

           }
            */
           #endregion

            #region Teste OrcCab
            //*
            /*
            i = 0; // Usa-se o nome i ou j a variavel, pois é usal em lógica matemática.            
            for (i = 1; i <= 2; i++)
            {
                using (IConnection Conexion = new Connection())
                {
                   IDAO<OrcCab> dao = new DAOOrcCab(Conexion);
                   OrcCab o = new OrcCab();//Objeto tipo Modulos(tabela)
                   OrcCab result = new OrcCab();
                   o.IdCliente = 1;
                   o.Data = DateTime.Now;
                    // gravo los datos como registro en la tabla modulos
                   result = dao.Insert(o);
                }

            }
           
            xid = "2";
            using (IConnection Conexion = new Connection())
            {
                IDAO<OrcCab> dao = new DAOOrcCab(Conexion);
                OrcCab orc = dao.FindOrDefault(xid);
                orc.IdCliente = 2;
               dao.Update(orc);                
            }
            /*
            xid = "3";
            using (IConnection Conexion = new Connection())
            {
                IDAO<OrcCab> dao = new DAOOrcCab(Conexion);
                OrcCab p = dao.FindOrDefault(xid);
                bool result = dao.Delete(p);
                
            }
             */
            using (IConnection Conexion = new Connection())
            {
                IDAO<OrcCab> dao = new DAOOrcCab(Conexion);
                OrcCab orc = new OrcCab();
                List<OrcCab> listOrc = new List<OrcCab>();
                foreach (OrcCab o in dao.All())
                {
                    orc.Nro = o.Nro;
                    orc.IdCliente = o.IdCliente;
                    orc.Data = o.Data;
                    listOrc.Add(orc);
                }
                int result = listOrc.Count;                
            }

            using (IConnection Conexion = new Connection())
            {
                IDAO<OrcCab> dao = new DAOOrcCab(Conexion);
                string result = dao.CurremRegVal();
            }
            //*/
            #endregion
            #region Teste OrcDet
            /*
            i = 0; // Usa-se o nome i ou j a variavel, pois é usal em lógica matemática.
            for (i = 1; i <= 2; i++)
            {
                using (IConnection Conexion = new Connection())
                {
                    IDAO<OrcDet> dao = new DAOOrcDet(Conexion);
                    OrcDet o = new OrcDet();//Objeto tipo Modulos(tabela)
                    OrcDet result = new OrcDet();
                    o.Nro = 1;
                    o.IdProduto = i;
                    o.PUnit = 10;
                    o.Qtd = 5;
                    o.Total = o.PUnit * o.Qtd;
                    // gravo los datos como registro en la tabla modulos
                    result = dao.Insert(o);
                }

            }

            xid = "2";
            using (IConnection Conexion = new Connection())
            {
                IDAO<OrcDet> dao = new DAOOrcDet(Conexion);
                OrcDet orc = dao.FindOrDefault(xid);
                IDAO<Produto> daoProd = new DAOProduto(Conexion);
                Produto p = daoProd.FindOrDefault("1");
                orc.IdProduto = p.Id;
                orc.PUnit = p.preço;
                orc.Qtd = 4;
                orc.Total = orc.PUnit * orc.Qtd;
                dao.Update(orc);
            }

            xid = "3";
            using (IConnection Conexion = new Connection())
            {
                IDAO<OrcDet> dao = new DAOOrcDet(Conexion);
                OrcDet p = dao.FindOrDefault(xid);
                bool result = dao.Delete(p);

            }
            */
            using (IConnection Conexion = new Connection())
            {
                IDAO<OrcDet> dao = new DAOOrcDet(Conexion);
                OrcDet orc = new OrcDet();
                List<OrcDet> listOrc = new List<OrcDet>();
                foreach (OrcDet o in dao.All())
                {
                    orc.Nro = o.Nro;
                    orc.IdProduto = o.IdProduto;
                    orc.PUnit = o.PUnit;
                    orc.Qtd = o.Qtd;
                    orc.Total = o.Total;
                    listOrc.Add(orc);
                }
                int result = listOrc.Count;
            }

            using (IConnection Conexion = new Connection())
            {
                IDAO<OrcDet> dao = new DAOOrcDet(Conexion);
                string result = dao.CurremRegVal();
            }

            #endregion
        }
    }
}
