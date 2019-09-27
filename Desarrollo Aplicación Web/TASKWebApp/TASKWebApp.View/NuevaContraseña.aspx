<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NuevaContraseña.aspx.cs" Inherits="TASKWebApp.View.NuevaContraseña" %>
<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1">
<link href="https://fonts.googleapis.com/css?family=Roboto:400,700" rel="stylesheet">
<title>TASK Tareas empresariales en tiempo real</title>
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script> 
<link href="CSS/StyleSheetRC.css" rel="stylesheet" />
<link href="CSS/StyleSheet.css" rel="stylesheet" />
</head>
<body>
<div class="header">
  <a href="#default" class="logo">
      <img src="img/TASKlogo.png" /> Tareas empresariales en tiempo real</a>
</div>
<div class="signup-form">
    <form  method="post" runat="server">
		<h2>Recuperar Contraseña</h2>
		<p>Ingrese su nueva contraseña</p>
		<hr>
        <div id="message">
            <asp:Label ID="lblErrorMessage" runat="server" Text="" ForeColor="Red" Font-Size="Medium"></asp:Label>
        </div>
        <div class="form-group">
			<div class="input-group">
				<span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                <asp:TextBox TextMode="Password" CssClass="form-control" ID="txtPass" placeholder="Nueva Contraseña" runat="server" required="true" MaxLength="50"></asp:TextBox>
			</div>
        </div>
		<div class="form-group">
			<div class="input-group">
				<span class="input-group-addon"><i class="glyphicon glyphicon-ok"></i></span>
				<asp:TextBox TextMode="Password" CssClass="form-control" ID="txtConfirmPass" placeholder="Confirmar contraseña" runat="server" required="true" MaxLength="50"></asp:TextBox>
			</div>
        </div>
		<div class="form-group">
            <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn1 btn-primary btn-lg" OnClick="btnVolver_Click"/>
            <asp:Button ID="btnAceptar" CssClass="btn btn-primary btn-lg" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" />
        </div>
    </form>
	<div class="text-center">Ya tienes cuenta? <a href="Login.aspx">Ingresa aquí</a></div>
</div>
<div class="footer">
  <p> By NOVA SMART Copyright © Todos los Derechos Reservados</p>
</div>
</body>
</html>                            

