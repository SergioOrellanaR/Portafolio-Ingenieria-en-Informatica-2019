<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ActualizarDatos.aspx.cs" Inherits="TASKWebApp.View.ActualizarDatos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="tittle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
	body{
		color: #fff;
		background: #4bc8c7;
		font-family: 'Roboto', sans-serif;
	}
    .form-control{
		height: 41px;
		background: #f2f2f2;
		box-shadow: none !important;
		border: none;
	}
	.form-control:focus{
		background: #e2e2e2;
	}
    .form-control, .btn{        
        border-radius: 3px;
    }
	.signup-form{
		width: 750px;
		margin: 30px auto;
	}
	.signup-form form{
		color: #999;
		border-radius: 3px;
    	margin-bottom: 15px;
        background: #fff;
        box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
        padding: 30px;
    }
	.signup-form h2 {
		color: #333;
		font-weight: bold;
        margin-top: 0;
    }
    .signup-form hr {
        margin: 0 -30px 20px;
    }    
	.signup-form .form-group{
		margin-bottom: 20px;
	}
	.signup-form input[type="checkbox"]{
		margin-top: 3px;
	}
	.signup-form .row div:first-child{
		padding-right: 10px;
	}
	.signup-form .row div:last-child{
		padding-left: 10px;
	}
    .signup-form .btn{        
        font-size: 16px;
        font-weight: bold;
		background: #3598dc;
		border: none;
		min-width: 140px;
    }
	.signup-form .btn:hover, .signup-form .btn:focus{
		background: #2389cd !important;
        outline: none;
	}
    .signup-form a{
		color: #fff;
		text-decoration: underline;
	}
	.signup-form a:hover{
		text-decoration: none;
	}
	.signup-form form a{
		color: #3598dc;
		text-decoration: none;
	}	
	.signup-form form a:hover{
		text-decoration: underline;
	}
    .signup-form .hint-text {
		padding-bottom: 15px;
		text-align: center;
    }
</style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" runat="server">
    <div class="signup-form">
    <form runat="server" method="post">
		<h2>Datos Usuario</h2>
		<p>Por favor, complete este formulario para actualizar sus datos</p>
		<hr>
        <div class="form-group">
			<div class="row">
				<div class="col-xs-6"><asp:TextBox CssClass="form-control" ID="txtNombre" runat="server" Enabled="False" >Nombre</asp:TextBox></div>
				<div class="col-xs-6"><asp:TextBox CssClass="form-control" ID="txtApellido" runat="server" Enabled="False" >Apellido</asp:TextBox></div></div>
			</div>        	
  
        <div class="form-group">
        	<asp:TextBox CssClass="form-control" ID="txtEmail" runat="server" Enabled="False" TextMode="Email">Email</asp:TextBox></div>
		  <div class="form-group">
        	<asp:TextBox CssClass="form-control" ID="txtEmpresa" runat="server" Enabled="False">Empresa</asp:TextBox></div>
        <div class="form-group">
        <asp:TextBox CssClass="form-control" ID="txtCargo" runat="server" Enabled="False">Cargo</asp:TextBox></div>
		<div class="form-group">
            <asp:Label ID="Label3" runat="server" Text="Ingrese su nuevo numero telefonico +569"></asp:Label>
        	<asp:TextBox CssClass="form-control" ID="txtCelular" runat="server" Enabled="True" TextMode="Number"></asp:TextBox></div>
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="Ingrese su actual contraseña:"></asp:Label>
        	<asp:TextBox CssClass="form-control" ID="txtActualContraseña" runat="server" Enabled="True" TextMode="Password">Ingrese actual contraseña</asp:TextBox></div>
          <div class="form-group">
              <asp:Label ID="Label2" runat="server" Text="Ingrese su nueva contraseña"></asp:Label>
              <asp:TextBox CssClass="form-control" ID="txtNuevaContraseña" runat="server" Enabled="True" TextMode="Password">Nueva contraseña</asp:TextBox></div>
        <div class="form-group" >
        <asp:Button ID="btnVolver" CssClass="btn btn-primary btn-lg" runat="server" Text="Volver" />
        <asp:Button ID="btnActualizar" CssClass="btn btn-primary btn-lg" runat="server" Text="Actualizar Datos" />
        </div>
     </form>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
