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
            if (cone == null)
            {
                cone = new CL_Conexion().obtenerConexion();
            }
        }

        public string ejecuparStoredProcedure_dboSFSF_SP_INSERT_TRABAJADOR(string p_bd)
        {
            string estado = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SFSF_SP_INSERT_TRABAJADOR";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("bd", System.Data.SqlDbType.NVarChar).Value = p_bd;
                cmd.Connection = cone;
                if (cone.State != System.Data.ConnectionState.Open) { cone.Open(); }
                int resp = cmd.ExecuteNonQuery();
                if (resp > -1)
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
                    + "ejecuparProcedimiento_dboSFSF_SP_INSERT_TRABAJADOR: " + ex.Message);
            }
            finally
            {
                cone.Close();
            }
            return estado;
        }


        public List<CL_Trabajador> listaDeTrabajadoresFiltradoPorNomApeMat(string p_nom, string p_ape, string p_mat)
        {
            List<CL_Trabajador> lista = new List<CL_Trabajador>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SFSF_SELECT_FILTRA_TRABJAD";
                cmd.CommandTimeout = 9000;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("nom", System.Data.SqlDbType.VarChar).Value = p_nom;
                cmd.Parameters.Add("pat", System.Data.SqlDbType.VarChar).Value = p_ape;
                cmd.Parameters.Add("mat", System.Data.SqlDbType.VarChar).Value = p_mat;
                cmd.Connection = cone;
                if (cone.State != System.Data.ConnectionState.Open) { cone.Open(); }
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    CL_Trabajador aux_tra = new CL_Trabajador();
                    aux_tra.Rut = Convert.ToString(dr["RUT"].ToString());
                    aux_tra.Nombres = Convert.ToString(dr["NOMBRES"].ToString());
                    aux_tra.Paterno = Convert.ToString(dr["PATERNO"].ToString());
                    aux_tra.Materno = Convert.ToString(dr["MATERNO"].ToString());
                    lista.Add(aux_tra);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("error dao hist_tra" + ex.Message);
            }
            finally
            {
                cone.Close();
            }
            return lista;
        }
        public string rutCompleto(int p)
        {
            string rutSinFormato = p.ToString();
            string rutFormateado = String.Empty;
            string rutTemporal = rutSinFormato.Substring(0, rutSinFormato.Length - 1);
            try
            {
                //obtengo el Digito Verificador del RUT
                string dv = rutSinFormato.Substring(rutSinFormato.Length - 1, 1);
                Int64 rut;
                //aqui convierto a un numero el RUT si ocurre un error lo deja en CERO
                if (!Int64.TryParse(rutTemporal, out rut))
                { rut = 0; }
                //este comando es el que formatea con los separadores de miles
                rutFormateado = rut.ToString("N0");
                if (rutFormateado.Equals("0"))
                { rutFormateado = string.Empty; }
                else
                {
                    //si no hubo problemas con el formateo agrego el DV a la salida
                    rutFormateado += "-" + dv;
                    //y hago este replace por si el servidor tuviese configuracion anglosajona y reemplazo las comas por puntos
                    rutFormateado = rutFormateado.Replace(",", ".");
                }
            }
            catch
            { rutFormateado = p.ToString(); }
            return rutFormateado;
        }
    }
}
