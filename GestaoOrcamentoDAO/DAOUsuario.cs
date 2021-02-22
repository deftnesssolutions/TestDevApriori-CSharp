using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GO.Providers;
using GO.DAO;
using GO.Entities;
using System.Data.SqlClient;
using System.Data;

namespace GO.DAO
{
    public class DAOUsuario : IDAO<Usuario>
    {
        private IConnection _conexion;
        public DAOUsuario(IConnection Conexion)
        {
            this._conexion = Conexion;
        }
        #region Consulta para Login de Sistema
        public static Usuario ValidarCredenciales(string login, string senha)
        {
            IConnection _conn = new Connection();
            Usuario entity = null;
            using (SqlCommand cmd = _conn.Get().CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_UsuarioLogin";

                cmd.Parameters.Add("@Login", SqlDbType.NVarChar).Value = login;
                cmd.Parameters.Add("@Senha", SqlDbType.NVarChar).Value = senha;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        entity = new Usuario();
                        reader.Read();
                        entity.Id = reader.GetInt32(0);
                        entity.Login = reader.IsDBNull(1) == false ? reader.GetString(1).ToString().Trim() : "";
                        entity.Senha = reader.IsDBNull(2) == false ? reader.GetString(2).ToString().Trim() : "";
                        entity.Nome  = reader.IsDBNull(3) == false ? reader.GetString(3).ToString().Trim() : "";
                    }
                }
            }
            return entity;
        }
        #endregion
        public IEnumerable<Usuario> All()
        {
            using (SqlCommand cmd = _conexion.Get().CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_UsuarioGetAll";
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            yield return new Usuario()
                            {
                                Id = reader.GetInt32(0),
                                Login = reader.IsDBNull(1) == false ? reader.GetString(1).ToString().Trim() : "",
                                Senha = reader.IsDBNull(2) == false ? reader.GetString(2).ToString().Trim() : "",
                                Nome = reader.IsDBNull(3) == false ? reader.GetString(3).ToString().Trim() : "",
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
                cmd.CommandText = "PA_CurrentCodUsuario";
                codnew = cmd.ExecuteScalar().ToString();
            }
            return codnew;
        }

        public Usuario FindOrDefault(params object[] keys)
        {
            Usuario entity = null;
            using (SqlCommand cmd = _conexion.Get().CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_UsuarioGetOne";

                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = keys[0];

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        entity = new Usuario();
                        reader.Read();
                        entity.Id = reader.GetInt32(0);
                        entity.Login = reader.IsDBNull(1) == false ? reader.GetString(1).ToString().Trim() : "";
                        entity.Senha = reader.IsDBNull(2) == false ? reader.GetString(2).ToString().Trim() : "";
                        entity.Nome = reader.IsDBNull(3) == false ? reader.GetString(3).ToString().Trim() : "";
                    }
                }
            }
            return entity;
        }
        public Usuario Insert(Usuario model)
        {
            using (SqlCommand cmd = _conexion.Get().CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_UsuarioAdd";
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = model.Id;
                cmd.Parameters.Add("@Login", SqlDbType.NVarChar).Value = model.Login;
                cmd.Parameters.Add("@Senha", SqlDbType.NVarChar).Value = model.Senha;
                cmd.Parameters.Add("@Nome", SqlDbType.NVarChar).Value = model.Nome;
                model.Id = int.Parse(cmd.ExecuteScalar().ToString());
            }
            return model;
        }

        public void Update(Usuario model)
        {
            using (SqlCommand cmd = _conexion.Get().CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_UsuarioEdit";
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = model.Id;
                cmd.Parameters.Add("@Login", SqlDbType.NVarChar).Value = model.Login;
                //cmd.Parameters.Add("@Senha", SqlDbType.NVarChar).Value = (object) model.Senha ?? DBNull.Value;
                cmd.Parameters.Add("@Nome", SqlDbType.NVarChar).Value = model.Nome;
                cmd.ExecuteNonQuery();
            }
        }

        public bool Delete(Usuario model)
        {
            bool _ret = false;
            using (SqlCommand cmd = _conexion.Get().CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_UsuarioDelete";

                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = model.Id;

                if (cmd.ExecuteNonQuery() > 0)
                {
                    _ret = true;
                }
            }
            return _ret;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
