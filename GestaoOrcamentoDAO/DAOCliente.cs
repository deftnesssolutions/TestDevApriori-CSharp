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
    public class DAOCliente:IDAO<Cliente>
    {
        private IConnection _conexion;
        public DAOCliente(IConnection Conexion)
        {
            this._conexion = Conexion;
        }

        public Cliente Insert(Cliente model)
        {
            using (SqlCommand cmd = _conexion.Get().CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_ClienteAdd";
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = model.Id;
                cmd.Parameters.Add("@Nome", SqlDbType.NVarChar).Value = model.Nome;
                cmd.Parameters.Add("@Telefone", SqlDbType.NVarChar).Value = model.Telefone;
                model.Id = int.Parse(cmd.ExecuteScalar().ToString());
            }
            return model;
        }

        public void Update(Cliente model)
        {
            using (SqlCommand cmd = _conexion.Get().CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_ClienteEdit";
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = model.Id;
                cmd.Parameters.Add("@Nome", SqlDbType.NVarChar).Value = model.Nome;
                cmd.Parameters.Add("@Telefone", SqlDbType.NVarChar).Value = model.Telefone;
                cmd.ExecuteNonQuery();
            }            
        }

        public bool Delete(Cliente model)
        {
            bool _ret = false;
            using (SqlCommand cmd = _conexion.Get().CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_ClienteDelete";

                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = model.Id;

                if (cmd.ExecuteNonQuery() > 0)
                {
                    _ret = true;
                }
            }
            return _ret;
        }

        public Cliente FindOrDefault(params object[] keys)
        {
            Cliente entity = null;
            using (SqlCommand cmd = _conexion.Get().CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_ClienteGetOne";

                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = keys[0];

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        entity = new Cliente();
                        reader.Read();
                        entity.Id = reader.GetInt32(0);
                        entity.Nome = reader.IsDBNull(1) == false ? reader.GetString(1).ToString().Trim() : "";
                        entity.Telefone = reader.IsDBNull(2) == false ? reader.GetString(2).ToString().Trim() : "";
                    }
                }
            }
            return entity;
        }
        
        public IEnumerable<Cliente> All()
        {
            using (SqlCommand cmd = _conexion.Get().CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_ClienteGetAll";                
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            yield return new Cliente()
                            {
                                Id = reader.GetInt32(0),
                                Nome = reader.IsDBNull(1) == false ? reader.GetString(1).ToString().Trim() : "",
                                Telefone = reader.IsDBNull(2) == false ? reader.GetString(2).ToString().Trim() : "",
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
                cmd.CommandText = "PA_CurrentCodCli";
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
