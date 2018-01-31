using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using Model;

namespace DataAccess
{
    public class DAO_Hist_Trabajador
    {
        private SqlConnection cone;

        public DAO_Hist_Trabajador()
        {
            if (cone == null)
            {
                cone = new CL_Conexion().obtenerConexion();
            }
        }

        public string ejecutarStoredProcedure_SFSF_SP_INSERT_HIST_TRABAJA(string p_bd)
        {
            string estado = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SFSF_SP_INSERT_HIST_TRABAJA";
                cmd.CommandTimeout = 9000;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("bd", System.Data.SqlDbType.NVarChar).Value = p_bd;
                cmd.Connection = cone;
                if (cone.State != System.Data.ConnectionState.Open) { cone.Open(); }
                int resp = cmd.ExecuteNonQuery();
                if (resp > -1)
                {
                    estado = "Ejecutado Correctamente Procedimiento.. Filas Afectadas(SFSF_Historico_Trabajador): " + resp;
                }
                else
                {
                    estado = "Error!";
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error! DAO_Hist_Trabajador_Centralizacion.ejecutarStoredProcedure_SFSF_SP_INSERT_HIST_TRABAJA: " + ex.Message);
            }
            return estado;
        }

        public List<CL_Historico_Trabajador> historicoTrabajadorPorRut(string p_rut)
        {
            List<CL_Historico_Trabajador> lista = new List<CL_Historico_Trabajador>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SFSF_SELECT_TRABAJ_POR_RUT  ";
                cmd.CommandTimeout = 9000;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("rut", System.Data.SqlDbType.VarChar).Value = p_rut;
                cmd.Connection = cone;
                if (cone.State != System.Data.ConnectionState.Open) { cone.Open(); }
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    #region datos
                    CL_Historico_Trabajador aux_hist = new CL_Historico_Trabajador();
                    if (dr["ROL"].ToString() != "")
                    {
                        aux_hist.Rol = Convert.ToInt32(dr["ROL"].ToString());
                        aux_hist.Fecha_contrato = Convert.ToDateTime(dr["FECHA_CONTRATO"].ToString()).ToString("dd-MM-yyyy");
                        aux_hist.Fecha_finiquito = Convert.ToDateTime(dr["FECHA_FINIQUITO"].ToString()).ToString("dd-MM-yyyy");
                        CL_Trabajador aux_tra = new CL_Trabajador();
                        int rutNum = Convert.ToInt32(dr["RUT"].ToString());
                        string rutComple = rutCompleto(rutNum);
                        aux_tra.Rut = rutComple;
                        aux_tra.Nombres = Convert.ToString(dr["NOMBRES"].ToString());
                        aux_tra.Paterno = Convert.ToString(dr["PATERNO"].ToString());
                        aux_tra.Materno = Convert.ToString(dr["MATERNO"].ToString());
                        aux_hist.Trabajador = aux_tra;
                        CL_Empresa aux_empre = new CL_Empresa();
                        aux_empre.Rut_empresa = Convert.ToString(dr["RUT_EMPRESA"].ToString());
                        aux_empre.Nom_empresa = Convert.ToString(dr["NOM_EMPRESA"].ToString());
                        aux_empre.Cod_sociedad_sap = Convert.ToString(dr["COD_SOCIEDAD_SAP"].ToString());
                        aux_hist.Empresa = aux_empre;
                        CL_Obra aux_obra = new CL_Obra();
                        aux_obra.Empresa = aux_empre;
                        aux_obra.Cod_obra = Convert.ToInt32(dr["COD_OBRA"].ToString());
                        aux_obra.Nom_obra = Convert.ToString(dr["NOM_OBRA"].ToString());
                        aux_hist.Obra = aux_obra;
                        CL_Categoria aux_cat = new CL_Categoria();
                        aux_cat.Empresa = aux_empre;
                        aux_cat.Cod_categoria = Convert.ToInt32(dr["COD_CATEGORIA"].ToString());
                        aux_cat.Nom_categoria = Convert.ToString(dr["NOM_CATEGORIA"].ToString());
                        aux_cat.Cod_categoria_sap = Convert.ToString(dr["COD_CAT_SAP"].ToString());
                        aux_cat.Abrev_categoria = Convert.ToString(dr["ABREV"].ToString());
                        aux_hist.Categoria = aux_cat;
                        CL_Especialidad aux_esp = new CL_Especialidad();
                        aux_esp.Empresa = aux_empre;
                        aux_esp.Cod_especialidad = Convert.ToInt32(dr["COD_ESPECIALIDAD"].ToString());
                        aux_esp.Nom_especialidad = Convert.ToString(dr["NOM_ESPECIALIDAD"].ToString());
                        aux_esp.Cod_especialidad_sap = Convert.ToString(dr["COD_ESP_SAP"].ToString());
                        aux_hist.Especialidad = aux_esp;
                    }
                    else
                    {
                        CL_Trabajador aux_tra = new CL_Trabajador();
                        int rutNum = Convert.ToInt32(dr["RUT"].ToString());
                        string rutComple = rutCompleto(rutNum);
                        aux_tra.Rut = rutComple;
                        aux_tra.Nombres = Convert.ToString(dr["NOMBRES"].ToString());
                        aux_tra.Paterno = Convert.ToString(dr["PATERNO"].ToString());
                        aux_tra.Materno = Convert.ToString(dr["MATERNO"].ToString());
                        aux_hist.Trabajador = aux_tra;
                        CL_Empresa aux_empre = null;
                        aux_hist.Empresa = aux_empre;
                    }

                    lista.Add(aux_hist);
                    #endregion
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
