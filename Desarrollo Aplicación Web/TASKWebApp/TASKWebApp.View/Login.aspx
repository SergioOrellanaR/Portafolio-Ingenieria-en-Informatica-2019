<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TASKWebApp.View.Login" %>

<!DOCTYPE html>
<html>
<head>
<meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Process SA</title>
    <link href="CSS/StyleSheet.css" rel="stylesheet" />
</head>
<body>
 <div class="imgLogo">
    <img src="img/TASKlogo.png"  alt="Logo" class="logo"/>
 </div>
<form method="post"> 
  <div class="imgcontainer">
      <h2>Iniciar sesión en T.A.S.K</h2>
    <img src="img/img_avatar2.png" alt="Avatar" class="avatar">
 
  </div>

  <div class="container">
    <label for="uname"><b>Email</b></label>
    <input type="text" placeholder="Ingrese Email" name="txtEmail" required >

    <label for="psw"><b>Contraseña</b></label>
    <input type="password" placeholder="Ingrese Contraseña" name="txtContraseña" required>
        
    <button type="submit" name="btnLogin">Iniciar sesión </button>
    <label>
      <input type="checkbox" checked="checked" name="checkRecordar"> Recordar usuario
    </label>
       <div class="container">
    <button type="button" class="cancelbtn" name="btnCancelar">Cancelar</button>
    <span class="psw">Olvidé mi <a href="#">contraseña?</a></span>
  </div>
  </div>
 
</form>

</body>
</html>
