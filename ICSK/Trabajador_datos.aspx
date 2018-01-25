<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Trabajador_datos.aspx.cs" Inherits="ICSK.Trabajador_datos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        form-group2 {
            margin-bottom: 3px;
        }
    </style>
    <form id="form" runat="server">
        <div class="row" style="padding-top: 5px; padding-bottom: 5px;">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Historico de un Trabajador en Especifico                  
                    </div>
                    <div class="panel-body" style="padding-top: 5px;">
                        <div class="form-group2 col-lg-2">
                            <label>Rut del Trabajador</label>
                            <asp:TextBox ID="txt_rut_trabajador" CssClass="form-control" AutoPostBack="true"
                                placeholder="Ingrese rut completo"
                                runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                ControlToValidate="txt_rut_trabajador"
                                ForeColor="Red"
                                ValidationExpression="\d+"
                                runat="server" ErrorMessage="Ingrese solo numeros">
                            </asp:RegularExpressionValidator>
                        </div>
                        <div class="form-group2 col-lg-2">
                            <label>Busqueda</label>
                            <div class="form-group2">
                                <asp:Button class="btn btn-success" ID="btn_buscar_trabajador"
                                    runat="server" Text="Buscar" OnClick="btn_buscar_trabajador_Click" />
                                <br />
                                <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div id="dv_rut" runat="server" class="form-group2 col-lg-2">
                            <label>Rut Completo</label>
                            <asp:TextBox ID="txt_rut_antece" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div id="dv_nom" runat="server" class="form-group2 col-lg-3">
                            <label>Nombres</label>
                            <asp:TextBox ID="txt_nom_antece" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div id="dv_ape" runat="server" class="form-group2 col-lg-3">
                            <label>Apellido Paterno</label>
                            <asp:TextBox ID="txt_ape_antece" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div runat="server" id="historico" class="col-lg-12">
                            <div class="form-group2">
                                <div class="form-group2" style="overflow-x: auto;">
                                    <asp:GridView ID="gv_datos" runat="server" CssClass="table table-striped table-bordered table-hover">
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>


