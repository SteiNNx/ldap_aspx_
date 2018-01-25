<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ICSK.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Bienvenido <asp:Label ID="txt_nombre" runat="server" Text=""></asp:Label>  </h1>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Sistema de Importacion de Datos ICSK beta    
                </div>
                <div class="panel-body">
                    <p>Este sistema esta destinada a importar los datos historicos de los trabajadores a una base de datos, que posteriormente hara integracion con la plataforma Success Factors SAP</p>
                </div>
                <div class="panel-footer">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
