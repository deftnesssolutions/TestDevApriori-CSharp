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
    public class DAOOrcCab:IDAO<OrcCab>
    {
         private IConnection _conexion;
        public DAOOrcCab(IConnection Conexion)
        {
            this._conexion = Conexion;
        }
        public OrcCab Insert(OrcCab model)
        {
            using (SqlCommand cmd = _conexion.Get().CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_OrcCabAdd";
                cmd.Parameters.Add("@Nro", SqlDbType.Int).Value = model.Nro;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = model.IdCliente;
                cmd.Parameters.Add("@Data", SqlDbType.DateTime).Value = (object)model.Data ?? DBNull.Value;
                model.Nro = int.Parse(cmd.ExecuteScalar().ToString());
            }
            return model;
        }

        public void Update(OrcCab model)
        {
            using (SqlCommand cmd = _conexion.Get().CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_OrcCabEdit";
                cmd.Parameters.Add("@Nro", SqlDbType.Int).Value = model.Nro;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = model.IdCliente;              
                cmd.Parameters.Add("@Data", SqlDbType.DateTime).Value = (object)model.Data ?? DBNull.Value;              
                cmd.ExecuteNonQuery();
            }
        }

        public bool Delete(OrcCab model)
        {
            bool _ret = false;
            using (SqlCommand cmd = _conexion.Get().CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_OrcCabDelete";

                cmd.Parameters.Add("@Nro", SqlDbType.Int).Value = model.Nro;

                if (cmd.ExecuteNonQuery() > 0)
                {
                    _ret = true;
                }
            }
            return _ret;
        }

        public OrcCab FindOrDefault(params object[] keys)
        {
            OrcCab entity = null;
            using (SqlCommand cmd = _conexion.Get().CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_OrcCabGetOne";

                cmd.Parameters.Add("@Nro", SqlDbType.Int).Value = keys[0];

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        entity = new OrcCab();
                        reader.Read();
                        entity.Nro = reader.GetInt32(0);
                        entity.IdCliente = reader.GetInt32(1);
                        entity.Data = reader.IsDBNull(2) == false ? DateTime.Parse(reader.GetDateTime(2).ToString()) : DateTime.MinValue;                        
                    }
                }
            }
            return entity;
        }

        public IEnumerable<OrcCab> All()
        {
            using (SqlCommand cmd = _conexion.Get().CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_OrcCabGetAll";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            yield return new OrcCab()
                            {
                                Nro = reader.GetInt32(0),
                                IdCliente = reader.GetInt32(1),                              
                                Data = reader.IsDBNull(2) == false ? DateTime.Parse(reader.GetDateTime(2).ToString()) : DateTime.MinValue,                                
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
                cmd.CommandText = "PA_CurrentCodOrc";
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
