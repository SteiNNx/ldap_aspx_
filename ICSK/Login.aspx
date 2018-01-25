<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ICSK.Login" %>

<%@ Import Namespace="ICSK" %>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Sistema ICSK S.A</title>


    <!-- Bootstrap Core CSS -->
    <link href="../css/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <!-- MetisMenu CSS -->
    <link href="../css/vendor/metisMenu/metisMenu.min.css" rel="stylesheet">
    <!-- Custom CSS -->
    <link href="../css/dist/css/sb-admin-2.css" rel="stylesheet">
    <!-- Morris Charts CSS -->
    <link href="../css/vendor/morrisjs/morris.css" rel="stylesheet">
    <!-- Custom Fonts -->
    <link href="../css/vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <link rel="shortcut icon" href="img/icon.ico">
    <script src="../scripts/typed.js"></script>
    <script type="text/javascript">
        $(function () {
            $(".typed").typed({
                strings: ["Developers.", "Designers.", "People."]
            });
        });

    </script>
</head>
<body>

    <div class="container">
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="login-panel panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Login <span class="typed"></span></h3>
                    </div>
                    <div class="panel-body">
                        <form id="Login" method="post" runat="server">
                            <fieldset>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control"
                                        ID="txtUsername" runat="server"
                                        placeholder="Nombre Usuario">
                                    </asp:TextBox>
                                    <br />
                                    <asp:TextBox CssClass="form-control"
                                        ID="txtPassword" runat="server"
                                        placeholder="Contraseña Usuario"
                                        TextMode="Password">
                                    </asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:CheckBox Visible="false" ID="chkPersist" runat="server" Text="Guardar Datos" />
                                    <br />
                                    <asp:Button CssClass="btn btn-lg btn-success btn-block" ID="btnLogin" runat="server" Text="Login" OnClick="Login_Click"></asp:Button><br>
                                    <asp:Label ID="errorLabel" runat="server" ForeColor="#ff3300"></asp:Label>
                                </div>
                            </fieldset>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- jQuery -->
    <script src="../css/vendor/jquery/jquery.min.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="../css/vendor/bootstrap/js/bootstrap.min.js"></script>

    <!-- Metis Menu Plugin JavaScript -->
    <script src="../css/vendor/metisMenu/metisMenu.min.js"></script>

    <!-- Morris Charts JavaScript -->
    <script src="../css/vendor/raphael/raphael.min.js"></script>
    <script src="../css/vendor/morrisjs/morris.min.js"></script>
    <script src="../css/data/morris-data.js"></script>

    <!-- Custom Theme JavaScript -->
    <script src="../css/dist/js/sb-admin-2.js"></script>
    <!--Hecho por Jorge Reyes, Practica Informatica -->

</body>
</html>
