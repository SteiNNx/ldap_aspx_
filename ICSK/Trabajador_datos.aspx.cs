using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Model;
using DataAccess;

namespace ICSK
{
    public partial class Trabajador_datos : System.Web.UI.Page
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            textVisibles(false);
            filtrarDiv(false);
        }



        protected void btn_buscar_trabajador_Click(object sender, EventArgs e)
        {
            try
            {
                Buscar();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private void Buscar()
        {
            textVisibles(true);
            gv_datos.DataSource = null;
            gv_datos.DataBind();
            txt_nom_antece.Text = "";
            txt_rut_antece.Text = "";
            txt_ape_antece.Text = "";
            txt_rut_trabajador.Text.Replace(".", "");
            txt_rut_trabajador.Text.Replace("-", "");
            filtrarDiv(false);
            lblMensajeFiltrar.Visible = false;
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
                    foreach (CL_Historico_Trabajador item in op)
                    {
                        if (item.Empresa != null)
                        {
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
                        }
                        else
                        {
                            lblMensaje.Text = "Trabajador sin datos";
                        }
                        break;
                    }
                    op.Clear();
                }
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


        protected void btn_filtrar_Click1(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }


        private void filtrarDiv(bool v)
        {
            try
            {

                if (v)
                {
                    filtrarTrabajadores.Visible = true;
                }
                else
                {
                    filtrarTrabajadores.Visible = false;
                }


            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
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

        protected void btn_fl_pop_Click(object sender, EventArgs e)
        {

            lblMensajeFiltrar.Text = "Busqueda: " + txt_nombre_completo_popup.Text.ToString() + " " + txt_ape_pa_popup.Text.ToString() + " " + txt_ape_mat_popup.Text.ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop2", "closeModal();", true);
            filtrarTrabajadores.Visible = true;
            gv_trabajadores_filtrar.DataSource = new DAO_Trabajador()
                .listaDeTrabajadoresFiltradoPorNomApeMat(txt_nombre_completo_popup.Text.ToString()
                , txt_ape_pa_popup.Text.ToString(), txt_ape_mat_popup.Text.ToString());
            //gv_trabajadores_filtrar.Columns.Add(new ButtonField() { Text = "Button" });
            gv_trabajadores_filtrar.DataBind();

        }
        protected string llenar(string z)
        {
            return "ejemplo";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            lblMensajeFiltrar.Text = "nada";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "PopClose", "closeModal();", true);
            lblMensaje.Text = "";
        }

        protected void gv_trabajadores_filtrar_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = gv_trabajadores_filtrar.Rows[index];
                    txt_rut_trabajador.Text = row.Cells[1].Text.ToString().Replace(".", "").Replace("-", "");
                    filtrarDiv(false);
                    Buscar();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "closeModal();", true);
        //    filtrarDiv(true);
        //lblMensajeFiltrar.Text = txt_nombre_completo_popup.Text;
    }
}