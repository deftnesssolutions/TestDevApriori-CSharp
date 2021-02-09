using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GO.Providers;
using GO.Entities;
using System.Data.SqlClient;
using System.Data;

namespace GO.DAO
{
    public class DAOProduto:IDAO<Produto>
    {
        private IConnection _conexion;
        public DAOProduto(IConnection Conexion)
        {
            this._conexion = Conexion;
        }
        public Produto Insert(Produto model)
        {
            using (SqlCommand cmd = _conexion.Get().CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_ProdutoAdd";
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = model.Id;
                cmd.Parameters.Add("@Nome", SqlDbType.NVarChar).Value = model.Nome;
                cmd.Parameters.Add("@Preco", SqlDbType.Decimal).Value = model.preço ;
                model.Id = int.Parse(cmd.ExecuteScalar().ToString());
            }
            return model;
        }

        public void Update(Produto model)
        {
            using (SqlCommand cmd = _conexion.Get().CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_ProdutoEdit";
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = model.Id;
                cmd.Parameters.Add("@Nome", SqlDbType.NVarChar).Value = model.Nome;
                cmd.Parameters.Add("@Preco", SqlDbType.Decimal).Value = model.preço;
                cmd.ExecuteNonQuery();
            }
        }

        public bool Delete(Produto model)
        {
            bool _ret = false;
            using (SqlCommand cmd = _conexion.Get().CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_ProdutoDelete";

                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = model.Id;

                if (cmd.ExecuteNonQuery() > 0)
                {
                    _ret = true;
                }
            }
            return _ret;
        }

        public Produto FindOrDefault(params object[] keys)
        {
            Produto entity = null;
            using (SqlCommand cmd = _conexion.Get().CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_ProdutoGetOne";

                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = keys[0];

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        entity = new Produto();
                        reader.Read();
                        entity.Id = reader.GetInt32(0);
                        entity.Nome = reader.IsDBNull(1) == false ? reader.GetString(1).ToString().Trim() : "";
                        entity.preço = reader.GetDecimal(2);
                    }
                }
            }
            return entity;
        }

        public IEnumerable<Produto> All()
        {
            using (SqlCommand cmd = _conexion.Get().CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_ProdutoGetAll";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            yield return new Produto()
                            {
                                Id = reader.GetInt32(0),
                                Nome = reader.IsDBNull(1) == false ? reader.GetString(1).ToString().Trim() : "",
                                preço = reader.GetDecimal(2),
                            };
                        }
                    }
                }
            }
        }

        public string CurremRegVal()
        {
            string codnew = "0";
            using (SqlCommand cmd = _conexion.Get().CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_CurrentCodProd";
                codnew = cmd.ExecuteScalar().ToString();
            }
            return codnew;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
