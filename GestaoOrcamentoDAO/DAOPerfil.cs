using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GO.Providers;
using GO.Entities;
using GO.DAO;
using System.Data.SqlClient;
using System.Data;

namespace GO.DAO
{
    public class DAOPerfil:IDAO<Perfil>
    {
        private IConnection _conexion;
        public DAOPerfil(IConnection Conexion)
        {
            this._conexion = Conexion;
        }
        public Perfil Insert(Perfil model)
        {
            using (SqlCommand cmd = _conexion.Get().CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_PerfilAdd";
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = model.Id;
                cmd.Parameters.Add("@Nome", SqlDbType.NVarChar).Value = model.Nome;
                cmd.Parameters.Add("@Ativo", SqlDbType.Bit).Value = model.Ativo;
                model.Id = int.Parse(cmd.ExecuteScalar().ToString());
            }
            return model;
        }

        public void Update(Perfil model)
        {
            using (SqlCommand cmd = _conexion.Get().CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_PerfilEdit";
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = model.Id;
                cmd.Parameters.Add("@Nome", SqlDbType.NVarChar).Value = model.Nome;
                cmd.Parameters.Add("@Ativo", SqlDbType.Bit).Value = model.Ativo;
                cmd.ExecuteNonQuery();
            }
        }

        public bool Delete(Perfil model)
        {
            bool _ret = false;
            using (SqlCommand cmd = _conexion.Get().CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_PerfilDelete";

                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = model.Id;

                if (cmd.ExecuteNonQuery() > 0)
                {
                    _ret = true;
                }
            }
            return _ret;
        }

        public Perfil FindOrDefault(params object[] keys)
        {
            Perfil entity = null;
            using (SqlCommand cmd = _conexion.Get().CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_PerfilGetOne";

                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = keys[0];

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        entity = new Perfil();
                        reader.Read();
                        entity.Id = reader.GetInt32(0);
                        entity.Nome = reader.IsDBNull(1) == false ? reader.GetString(1).ToString().Trim() : "";
                        entity.Ativo = reader.GetBoolean(2);
                    }
                }
            }
            return entity;
        }

        public IEnumerable<Perfil> All()
        {
            using (SqlCommand cmd = _conexion.Get().CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_PerfilGetAll";
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            yield return new Perfil()
                            {
                                Id = reader.GetInt32(0),
                                Nome = reader.IsDBNull(1) == false ? reader.GetString(1).ToString().Trim() : "",
                                Ativo = reader.GetBoolean(2),
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
