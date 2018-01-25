<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Trabajador_datos.aspx.cs" Inherits="ICSK.Trabajador_datos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form" runat="server">

        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Historico Trabajador</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Historico de un Trabajador en Especifico                  
                    </div>
                    <div class="panel-body">
                        <div class="form-group col-lg-2">
                            <label>Rut del Trabajador</label>
                            <div class="form-group">
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
                        </div>
                        <div class="form-group col-lg-2">
                            <label>Busqueda</label>
                            <div class="form-group">
                                <asp:Button class="btn btn-success" ID="btn_buscar_trabajador"
                                    runat="server" Text="Buscar" OnClick="btn_buscar_trabajador_Click" />
                                <br />
                                <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div id="dv_rut" runat="server" class="form-group col-lg-2">
                            <label>Rut Completo</label>
                            <asp:TextBox ID="txt_rut_antece" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div id="dv_nom" runat="server" class="form-group col-lg-3">
                            <label>Nombres</label>
                            <asp:TextBox ID="txt_nom_antece" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div id="dv_ape" runat="server" class="form-group col-lg-3">
                            <label>Apellido Paterno</label>
                            <asp:TextBox ID="txt_ape_antece" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div runat="server" id="historico" class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Historico Trabajador               
                    </div>
                    <div class="panel-body">
                        <div class="form-group">
                            <div class="form-group" style="overflow-x: auto;">
                                <asp:GridView ID="gv_datos" runat="server" CssClass="table table-striped table-bordered table-hover">
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>


