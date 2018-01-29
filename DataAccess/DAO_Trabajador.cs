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
    public class DAO_Trabajador
    {
        private SqlConnection cone;

        public DAO_Trabajador()
        {
            if (cone==null)
            {
                cone = new CL_Conexion().obtenerConexion();
            }
        }

        public string ejecuparStoredProcedure_dboSFSF_SP_INSERT_TRABAJADOR(string p_bd)
        {
            string estado="";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SFSF_SP_INSERT_TRABAJADOR";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("bd", System.Data.SqlDbType.NVarChar).Value = p_bd;
                cmd.Connection = cone;
                if (cone.State != System.Data.ConnectionState.Open) { cone.Open(); }
                int resp = cmd.ExecuteNonQuery();
                if (resp>-1)
                {
                    estado = "Ejecutado Correctamente Procedimiento.. Filas Afectadas(SFSF_Trabajador): " + resp;
                }
                else
                {
                    estado = "Error!";
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error! DAO_Trabajador_Centralizacion."
                    +"ejecuparProcedimiento_dboSFSF_SP_INSERT_TRABAJADOR: "+ex.Message);
            }
            finally
            {
                cone.Close();
            }
            return estado;
        }


        public List<CL_Trabajador> listaDeTrabajadoresFiltradoPorNomApeMat(string p_nom,string p_ape,string p_mat)
        {
            List<CL_Trabajador> lista = new List<CL_Trabajador>();
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            return lista;
        }
    }
}
