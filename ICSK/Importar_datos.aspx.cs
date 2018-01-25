using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DataAccess;

namespace ICSK
{
    public partial class Importar_datos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_importar_Click1(object sender, EventArgs e)
        {
            try
            {
                string opcion = ddl_base_datos.SelectedValue;
                string bd = "";
                switch (opcion)
                {
                    case "bd_centra":
                        bd = "centralizacion";
                        Datos(bd);
                        break;
                    case "bd_bsk":
                        bd = "bsk";
                        Datos(bd);
                        break;
                    case "bd_bsk_ews":
                        bd = "BSKEWS";
                        Datos(bd);
                        break;
                    case "bd_comsa":
                        bd = "COMSA";
                        Datos(bd);
                        break;
                    case "bd_bsk_ogp1":
                        bd = "CONSBSKOGP1";
                        Datos(bd);
                        break;
                    case "bd_constructora_bsk":
                        bd = "ConstructoraBSK";
                        Datos(bd);
                        break;
                    case "bd_dessau":
                        bd = "Dessau";
                        Datos(bd);
                        break;
                    case "bd_logro":
                        bd = "Logro";
                        Datos(bd);
                        break;
                    case "bd_sk_capacitacion":
                        bd = "sk_capacitacion";
                        Datos(bd);
                        break;
                    case "bd_sk_ecologia":
                        bd = "sk_ecologia";
                        Datos(bd);
                        break;
                    case "bd_sk_comsa_1":
                        bd = "SKCOMSA1";
                        Datos(bd);
                        break;
                    case "bd_sk_comsa_maq":
                        bd = "SKCOMSAMAQ";
                        Datos(bd);
                        break;
                    case "bd_sk_industrial":
                        bd = "skindustrial";
                        Datos(bd);
                        break;
                    case "bd_sk_vv":
                        bd = "SKVV";
                        Datos(bd);
                        break;
                    default:
                        lbl_mensaje.Text = "def";
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void Datos(string p_bd)
        {
            try
            {
                lbl_mensaje.Text = "Datos Importados de: " + p_bd
                               + "<br/>" + new DAO_Empresa().ejecutarStoredProcedure_SFSF_SP_INSERT_EMPRESAS(p_bd)
                                + "<br/>" + new DAO_Categoria().ejecutarStoredProcedure_SFSF_SP_INSERT_CATEGORIA(p_bd)
                                + "<br/>" + new DAO_Obra().ejecutarStoredProcedure_SFSF_SP_INSERT_OBRAS(p_bd)
                                + "<br/>" + new DAO_Especialidad().ejecutarStoredProcedure_SFSF_SP_INSERT_ESPECIALIDAD(p_bd)
                                + "<br/>" + new DAO_Trabajador().ejecuparStoredProcedure_dboSFSF_SP_INSERT_TRABAJADOR(p_bd)
                                + "<br/>" + new DAO_Hist_Trabajador().ejecutarStoredProcedure_SFSF_SP_INSERT_HIST_TRABAJA(p_bd)
                                ;

            }
            catch (Exception ex)
            {

                throw new Exception("Error: " + ex.Message);
            }
        }
    }
}