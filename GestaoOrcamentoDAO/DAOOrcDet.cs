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
    public class DAOOrcDet:IDAO<OrcDet>
    {
         private IConnection _conexion;
        public DAOOrcDet(IConnection Conexion)
        {
            this._conexion = Conexion;
        }
        public OrcDet Insert(OrcDet model)
        {
            using (SqlCommand cmd = _conexion.Get().CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_OrcDetAdd";
                cmd.Parameters.Add("@Nro", SqlDbType.Int).Value = model.Nro;
                cmd.Parameters.Add("@IdProduto", SqlDbType.Int).Value = model.IdProduto;
                cmd.Parameters.Add("@PUnit", SqlDbType.Decimal).Value = model.PUnit;
                cmd.Parameters.Add("@Qtd", SqlDbType.Int).Value = model.Qtd;
                cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = model.Total;
                //model.Nro = int.Parse(cmd.ExecuteScalar().ToString());
                cmd.ExecuteNonQuery();
            }
            return model;
        }

        public void Update(OrcDet model)
        {
            using (SqlCommand cmd = _conexion.Get().CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_OrcDetEdit";
                cmd.Parameters.Add("@Nro", SqlDbType.Int).Value = model.Nro;
                cmd.Parameters.Add("@IdProduto", SqlDbType.Int).Value = model.IdProduto;
                cmd.Parameters.Add("@PUnit", SqlDbType.Decimal).Value = model.PUnit;
                cmd.Parameters.Add("@Qtd", SqlDbType.Int).Value = model.Qtd;
                cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = model.Total;
                cmd.ExecuteNonQuery();
            }
        }

        public bool Delete(OrcDet model)
        {
            bool _ret = false;
            
            using (SqlCommand cmd = _conexion.Get().CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_OrcDetDelete";

                cmd.Parameters.Add("@Nro", SqlDbType.Int).Value = model.Nro;
                cmd.Parameters.Add("@IdProduto", SqlDbType.Int).Value = model.IdProduto;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    _ret = true;
                }
            }
            
            return _ret;
        }

        public OrcDet FindOrDefault(params object[] keys)
        {
            OrcDet entity = null;
            /*
            using (SqlCommand cmd = _conexion.Get().CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_OrcDetGetOne";

                cmd.Parameters.Add("@Nro", SqlDbType.Int).Value = keys[0];

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        entity = new OrcDet();
                        reader.Read();
                        entity.Nro = reader.GetInt32(0);
                        entity.IdProduto = reader.GetInt32(1);
                        entity.PUnit = reader.GetDecimal(2);
                        entity.Qtd = reader.GetInt32(3);
                        entity.Total = reader.GetDecimal(4);
                    }
                }
            }
             */
            return entity;
        }

        public IEnumerable<OrcDet> All()
        {
            using (SqlCommand cmd = _conexion.Get().CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_OrcDetGetAll";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            yield return new OrcDet()
                            {
                                Nro = reader.GetInt32(0),
                                IdProduto = reader.GetInt32(1),
                                PUnit = reader.GetDecimal(2),
                                Qtd = reader.GetInt32(3),
                                Total = reader.GetDecimal(4),
                            };
                        }
                    }
                }
            }
        }

        public string CurremRegVal()
        {
            string codnew = "0";
            /*
            using (SqlCommand cmd = _conexion.Get().CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_CurrentCodOrc";
                codnew = cmd.ExecuteScalar().ToString();
            }
             */
            return codnew;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
