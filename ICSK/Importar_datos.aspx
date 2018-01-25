<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Importar_datos.aspx.cs" Inherits="ICSK.Importar_datos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Importar Datos</h1>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Las Operaciones se pueden tardar unos minutos                   
                </div>
                <div class="panel-body">
                    <form runat="server">
                        <div class="form-group">
                            <label>Base de Datos</label>
                            <asp:DropDownList CssClass="form-control" ID="ddl_base_datos" runat="server">
                                <asp:ListItem Value="bd_centra">Centralizacion
                                </asp:ListItem>
                                <asp:ListItem Value="bd_bsk">Bsk
                                </asp:ListItem>
                                <asp:ListItem Value="bd_bsk_ews">Bskews
                                </asp:ListItem>
                                <asp:ListItem Value="bd_comsa">COMSA
                                </asp:ListItem>
                                <asp:ListItem Value="bd_bsk_ogp1">CONSBSKOGP1
                                </asp:ListItem>
                                <asp:ListItem Value="bd_constructora_bsk">ConstructoraBSK
                                </asp:ListItem>
                                <asp:ListItem Value="bd_dessau">Dessau
                                </asp:ListItem>
                                <asp:ListItem Value="bd_logro">Logro
                                </asp:ListItem>
                                <asp:ListItem Value="bd_sk_capacitacion">sk_capacitacion
                                </asp:ListItem>
                                <asp:ListItem Value="bd_sk_ecologia">sk_ecologia
                                </asp:ListItem>
                                <asp:ListItem Value="bd_sk_comsa_1">SKCOMSA1
                                </asp:ListItem>
                                <asp:ListItem Value="bd_sk_comsa_maq">SKCOMSAMAQ
                                </asp:ListItem>
                                <asp:ListItem Value="bd_sk_industrial">SKINDUSTRIAL
                                </asp:ListItem>
                                <asp:ListItem Value="bd_sk_vv">SKVV
                                </asp:ListItem>
                            </asp:DropDownList>

                        </div>
                        <div class="form-group">
                            <asp:Button class="btn btn-success" ID="btn_importar"
                                runat="server" Text="Importar" OnClick="btn_importar_Click1" />
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lbl_mensaje" runat="server" Text=""></asp:Label>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
