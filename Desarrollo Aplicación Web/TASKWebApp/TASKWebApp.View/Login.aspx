<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TASKWebApp.View.Login" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Tareas empresariales en tiempo real</title>
    <link href="https://fonts.googleapis.com/css?family=Roboto" rel="stylesheet">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link href="CSS/StyleSheet.css" rel="stylesheet" />
</head>
<body>
        <div class="header">
            <a href="#default" class="logo">
                <img src="img/TASKlogo.png" /></a>
 
            <div class="header-right">
                <a class=" btn btn-primary " href="#Login">Iniciar sesión</a>
            </div>
        </div>
        <div class="login-form">
            <h2 class="text-center">Iniciar sesión en T.A.S.K</h2>
            <form method="post" runat="server">
                <div class="avatar">
                    <img src="img/avatar.png" alt="Avatar">
                </div>
                <div id="message"><center>
                    <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red" Font-Size="Medium" ></asp:Label></center>
                </div>
                <div class="form-group">
                    <!--  <input type="email" class="form-control input-lg" name="txtemail" placeholder="Email" required="required" maxlength="250"> -->
                    <asp:TextBox TextMode="Email" ID="txtEmail" runat="server" CssClass="form-control input-lg" placeholder="Email" MaxLength="250" required="true" ></asp:TextBox>
                </div>
                <div class="form-group">
                    <!--     <input       type="password"      class="form-control input-lg"    name="txtpassword" placeholder="Contraseña" required="required" maxlength="50"> -->
                    <asp:TextBox TextMode="Password" CssClass="form-control input-lg" ID="txtPassword" runat="server" placeholder="Contraseña" required="true" MaxLength="50" ></asp:TextBox>
                </div>
                <div class="form-group clearfix">
                    <label class="pull-left checkbox-inline">
                    <!--    <input type="checkbox" name="cbxrecuerdame">Recuérdame</label> -->
                    <asp:CheckBox ID="cbxrecuerdame" runat="server" Text="Recuérdame"/></label>
                    <!--     <button type="submit" class="btn btn-primary btn-lg pull-right" name="btningresar">Ingresar</button> -->
                    <asp:Button ID="btnLogin" CssClass="btn btn-primary btn-lg pull-right" runat="server" Text="Ingresar" OnClick="btnLogin_Click" />
                </div>
            </form>
            <div class="hint-text">¿Olvidaste tu contraseña? <a href="RecuperarContraseña.aspx">Recuperar</a></div>
        </div>
        <div class="footer">
            <p>By NOVA SMART Copyright © Todos los Derechos Reservados</p>
        </div>
</body>

</html>
