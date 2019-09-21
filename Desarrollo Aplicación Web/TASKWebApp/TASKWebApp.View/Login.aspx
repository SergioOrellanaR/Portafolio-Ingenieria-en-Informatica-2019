<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1">
<title>TASK Tareas empresariales en tiempo real</title>
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
      <img src="img/TASKlogo.png" /> Tareas empresariales en tiempo real</a>
  <div class="header-right">
    <a class="active" href="#Login">Iniciar sesión</a>
    <a href="#about">Nosotros</a>
  </div>
</div>
<div class="login-form">
	<h2 class="text-center">Iniciar sesión T.A.S.K</h2>
    <form action="/examples/actions/confirmation.php" method="post">
		<div class="avatar">
		 <img src="img/avatar.png" alt="Avatar">
		</div>           
        <div class="form-group">
        	<input type="email" class="form-control input-lg" name="txtemail" placeholder="Email" required="required">	
        </div>
		<div class="form-group">
            <input type="password" class="form-control input-lg" name="txtpassword" placeholder="Contraseña" required="required">
        </div>        
        <div class="form-group clearfix">
			<label class="pull-left checkbox-inline"><input type="checkbox" name="cbxrecuerdame"> Recuérdame</label>
            <button type="submit" class="btn btn-primary btn-lg pull-right" name="btningresar">Ingresar</button>
        </div>		
    </form>
    <div class="hint-text">Olvidaste tu contraseña? <a href="RecuperarContraseña.aspx">Recuperar</a></div>
</div>
<div class="footer">
  <p> By NOVA SMART Copyright © Todos los Derechos Reservados</p>
</div>
</body>

</html>                            