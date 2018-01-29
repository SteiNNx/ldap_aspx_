<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="Trabajador_datos.aspx.cs" Inherits="ICSK.Trabajador_datos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function openModal() {
            $('#myModal').appendTo("body").modal({backdrop: 'static', keyboard: false},'show');
        }
        //function closeModal() {
        //    $('.myModal').modal('hide'); $('body').removeClass('myModal-open');
        //    $('.myModal-backdrop').remove();
        //}
    </script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        form-group2 {
            margin-bottom: 3px;
        }
    </style>
    <form autopostback="true" id="form" runat="server">
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
                            <div class="form-group2">
                                <asp:Button ID="btn_filtrar" class="btn btn-success" data-target="#myModal" data-toggle="modal"
                                    runat="server" Text="Filtrar" OnClick="btn_filtrar_Click1" />
                                <br />
                            </div>
                        </div>
                        <div id="dv_rut" runat="server" class="form-group2 col-lg-2">
                            <label>Rut Completo</label>
                            <asp:TextBox AutoPostBack="true" ID="txt_rut_antece" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div id="dv_nom" runat="server" class="form-group2 col-lg-3">
                            <label>Nombres</label>
                            <asp:TextBox AutoPostBack="true" ID="txt_nom_antece" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div id="dv_ape" runat="server" class="form-group2 col-lg-3">
                            <label>Apellido Paterno</label>
                            <asp:TextBox AutoPostBack="true" ID="txt_ape_antece" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div runat="server" id="historico" class="col-lg-12">
                            <div class="form-group2">
                                <div class="form-group2" style="overflow-x: auto;">
                                    <asp:GridView ID="gv_datos" AutoPostBack="true" runat="server" CssClass="table table-striped table-bordered table-hover">
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>

                        <div runat="server" id="filtrarTrabajadores" class="col-lg-12">
                            <h1>Busqueda: </h1>
                            <asp:Label ID="lblMensajeFiltrar" runat="server" Text=""></asp:Label>
                            <div class="form-group2">
                                <div class="form-group2" style="overflow-x: auto;">
                                    <asp:GridView ID="gv_trabajadores_filtrar" AutoPostBack="true" runat="server" CssClass="table table-striped table-bordered table-hover">
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                        -
                        <!-- FIN Filtrar Trabajadores-->
                    </div>
                </div>
            </div>
            <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
                aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title" id="myModalLabel">Modal title</h4>
                        </div>
                        <div class="modal-body">
                            <asp:TextBox UseSubmitBehavior="false" ID="txt_nombre_completo_popup" runat="server" placeholder="Nombre Completo" class="form-control"></asp:TextBox><br />
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btn_fl_pop" runat="server" Text="Button" OnClick="btn_fl_pop_Click" UseSubmitBehavior="false" />
                            <asp:Label runat="server" ID="lblMensajePopup"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
    </form>
</asp:Content>


