using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Model;
using DataAccess;
using System.Web.UI.HtmlControls;

namespace ICSK
{
    public partial class Trabajador_datos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            textVisibles(false);
        }

        private void textVisibles(bool v)
        {
            if (v)
            {
                dv_rut.Visible = true;
                dv_nom.Visible = true;
                dv_ape.Visible = true;
                historico.Visible = true;
                lblMensaje.Text = "";
            }
            else
            {
                dv_rut.Visible = false;
                dv_nom.Visible = false;
                dv_ape.Visible = false;
                historico.Visible = false;
            }
        }

        protected void btn_buscar_trabajador_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_rut_trabajador.Text.Length < 5 || txt_rut_trabajador.Text.Length > 11)
                {
                    lblMensaje.Text = "Ingrese el rut completo, </br> sin guion y sin puntos";
                    txt_rut_trabajador.Text = "";
                }
                else
                {
                    string p_rut = txt_rut_trabajador.Text;
                    DAO_Hist_Trabajador dao_historial = new DAO_Hist_Trabajador();
                    var op = dao_historial.historicoTrabajadorPorRut(p_rut);
                    if (op.ToList() == null || op.ToList().Count == 0)
                    {
                        lblMensaje.Text = "No Exite, </br> intentelo otra vez";
                    }
                    else
                    {
                        CL_Historico_Trabajador tra = (CL_Historico_Trabajador)op.ToList().First();
                        CargarAntecedentesUsuario(tra);
                        gv_datos.DataSource = from datos in op
                                              select new
                                              {
                                                  datos.Empresa.Nom_empresa,
                                                  datos.Obra.Nom_obra,
                                                  datos.Fecha_contrato,
                                                  datos.Fecha_finiquito,
                                                  datos.Especialidad.Nom_especialidad,
                                                  datos.Categoria.Nom_categoria,
                                                  datos.Rol
                                              };
                        gv_datos.DataBind();
                        FormatoGridview();
                        textVisibles(true);
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private void CargarAntecedentesUsuario(CL_Historico_Trabajador tra)
        {
            txt_rut_antece.Text = tra.Trabajador.Rut;
            txt_nom_antece.Text = tra.Trabajador.Nombres;
            txt_ape_antece.Text = tra.Trabajador.Paterno + ' ' + tra.Trabajador.Materno;
        }

        private void FormatoGridview()
        {

            gv_datos.HeaderRow.Cells[0].Text = "Nombre Empresa";
            gv_datos.HeaderRow.Cells[1].Text = "Nombre Obra";
            gv_datos.HeaderRow.Cells[2].Text = "Fecha Contrato";
            gv_datos.HeaderRow.Cells[3].Text = "Fecha Finiquito";
            gv_datos.HeaderRow.Cells[4].Text = "Especialidad";
            gv_datos.HeaderRow.Cells[5].Text = "Categoria";
            gv_datos.HeaderRow.Cells[6].Text = "Rol";
        }
    }
}