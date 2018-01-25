using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//conexion
using System.Data.SqlClient;
using Model;


namespace DataAccess
{
    public class DAO_Obra
    {
        private SqlConnection cone;
        public DAO_Obra()
        {
            if (cone == null)
            {
                cone = new CL_Conexion().obtenerConexion();
            }
        }

        public string ejecutarStoredProcedure_SFSF_SP_INSERT_OBRAS(string p_bd)
        {
            string estado = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SFSF_SP_INSERT_OBRAS";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("bd", System.Data.SqlDbType.NVarChar).Value = p_bd;
                cmd.Connection = cone;
                if (cone.State != System.Data.ConnectionState.Open) { cone.Open(); }
                int resp = cmd.ExecuteNonQuery();
                if (resp > -1)
                {
                    estado = "Ejecutado Correctamente Procedimiento.. Filas Afectadas(SFSF_Obras): " + resp;
                }
                else
                {
                    estado = "Error!";
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error! DAO_Obra_Centralizacion.ejecutarStoredProcedure_SFSF_SP_INSERT_OBRAS: "+ex.Message);
            }
            finally
            {
                cone.Close();
            }
            return estado;
        }


        public List<CL_Obra> listado_obras()
        {
            List<CL_Obra> lista = new List<CL_Obra>();
            try
            {
                string sql = "SELECT em.RUT_EMPRESA,NOM_EMPRESA,COD_SOCIEDAD_SAP,COD_OBRA,NOM_OBRA "
                              + "FROM SFSF_Empresa as em "
                              + "inner JOIN SFSF_Obra as ob "
                              + "ON(em.RUT_EMPRESA = ob.RUT_EMPRESA)";
                if (cone.State != System.Data.ConnectionState.Open) { cone.Open(); }
                SqlCommand cmd = new SqlCommand(sql, cone);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    CL_Obra aux_obra = new CL_Obra();
                    CL_Empresa aux_empresa = new CL_Empresa();
                    aux_empresa.Rut_empresa = Convert.ToString(dr["RUT_EMPRESA"].ToString());
                    aux_empresa.Nom_empresa = Convert.ToString(dr["NOM_EMPRESA"].ToString());
                    aux_empresa.Cod_sociedad_sap = Convert.ToString(dr["COD_SOCIEDAD_SAP"].ToString());
                    aux_obra.Empresa = aux_empresa;
                    aux_obra.Cod_obra = Convert.ToInt32(dr["COD_OBRA"].ToString());
                    aux_obra.Nom_obra = Convert.ToString(dr["NOM_OBRA"].ToString());
                    lista.Add(aux_obra);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error: DAO_Obra.listado_obras: " + ex.Message);
            }
            finally
            {
                cone.Close();
            }
            return lista;
        }



    }
}
