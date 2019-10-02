<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Creartareaprueba.aspx.cs" Inherits="TASKWebApp.View.Creartareaprueba" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <title>
    </title>
    <link href="https://fonts.googleapis.com/css?family=Roboto" rel="stylesheet"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link href="CSS/StyleSheetMP.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <div style="text-align: center">
            <h1>Crear Tarea</h1>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" Height="200px">
        <div style="width: 50%; float: left;">
            <asp:RadioButton ID="rbtTareaPropia" runat="server" Text="Tarea propia" GroupName="TipoCargaTarea" Checked="true" />
            <asp:RadioButton ID="rbtTareaPredeterminada" runat="server" Text="Tarea predeterminada" GroupName="TipoCargaTarea" />
            <asp:DropDownList ID="ddlTareaPredet" runat="server">
            </asp:DropDownList>
        </div>
        <div style="width: 50%; float: left;">
            <asp:RadioButton ID="rbtTareaUnica" runat="server" Text="Tarea única" GroupName="TipoTarea" Checked="true" />
            <asp:RadioButton ID="rbtTareaRepetitiva" runat="server" Text="Tarea repetitiva" GroupName="TipoTarea" />
        </div>
        <div style="width: 50%; float: left;">
            <asp:Label ID="Label1" runat="server" Text="Nombre Tarea"></asp:Label>
            <asp:TextBox ID="txtNombreTarea" runat="server"></asp:TextBox>
        </div>
        <div style="width: 50%; float: left;">
            <div style="width: 50%; float: left;">
                <asp:Label ID="Label2" runat="server" Text="Hora inicio"></asp:Label>
                &nbsp
               <asp:TextBox ID="txtHoraInicio" runat="server" TextMode="Time"></asp:TextBox>
            </div>
            <asp:Label ID="Label5" runat="server" Text="Hora fin"></asp:Label>
            &nbsp
            <asp:TextBox ID="txtHorafin" runat="server" TextMode="Time"></asp:TextBox>
        </div>

        <div style="width: 50%; float: left;">
            <asp:Label ID="Label3" runat="server" Text="Descripcion"></asp:Label>

            &nbsp&nbsp&nbsp&nbsp<asp:TextBox ID="txtDescription" TextMode="multiline" Columns="50" Rows="5" runat="server" MaxLength="500"/>

        </div>
        <div style="width: 50%; float: left;">
            <div style="width: 50%; float: left;">
                <asp:Label ID="Label4" runat="server" Text="Fecha inicio"></asp:Label>
                <asp:TextBox ID="txtFechainicio" runat="server" TextMode="Date"></asp:TextBox>
            </div>
            <asp:Label ID="Label6" runat="server" Text="Fecha fin"></asp:Label>
            <asp:TextBox ID="txtFechafin" runat="server" TextMode="Date"></asp:TextBox>
            <div style="width: 100%; float: left;">
                <h4>Opciones de repetición</h4>
            </div>
            <div style="width: 100%; float: left;">
                <asp:CheckBox ID="cbxLunes" runat="server" Text="Lunes" />
                <asp:CheckBox ID="cbxMartes" runat="server" Text="Martes" />
                <asp:CheckBox ID="cbxMiercoles" runat="server" Text="Miercoles" />
                <asp:CheckBox ID="cbxJueves" runat="server" Text="Jueves" />
                <asp:CheckBox ID="cbxViernes" runat="server" Text="Viernes" />
                <asp:CheckBox ID="cbxSabado" runat="server" Text="Sábado" />
                <asp:CheckBox ID="cbxDomingo" runat="server" Text="Domingo" />
            </div>
            <div style="width: 100%; float: left;">
                <asp:CheckBox ID="cbxSemana1" runat="server" Text="Semana 1 " />
                <asp:CheckBox ID="cbxSemana2" runat="server" Text="Semana 2 " />
                <asp:CheckBox ID="cbxSemana3" runat="server" Text="Semana 3 " />
                <asp:CheckBox ID="cbxSemana4" runat="server" Text="Semana 4 " />
                <asp:CheckBox ID="cbxSemana5" runat="server" Text="Semana 5 " />
            </div>
            <div style="width: 100%; float: left;"> 
                <asp:CheckBox ID="cbxDiadelmes" runat="server" Text="Por día del mes " />
                <asp:TextBox ID="txtDiadelmes" runat="server" TextMode="Number" ></asp:TextBox>
            </div>
            <div style="width: 100%; float: left;"> 
                <asp:CheckBox ID="cbxMeses" runat="server" Text="Por meses " />
                <asp:DropDownList ID="ddlMeses" runat="server"></asp:DropDownList>
            </div>
        </div>

        <div style="width: 50%; ">
            <asp:Label ID="Label7" runat="server" Text="Responsable"></asp:Label>&nbsp&nbsp&nbsp<asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
            <br />
            <div>
                <asp:Label ID="Label10" runat="server" Text="¿Esta tarea tiene dependencia?"></asp:Label>
                <asp:RadioButton ID="rbtSiDependencia" runat="server" Text="Si" GroupName="Dependencia" />
                <asp:RadioButton ID="rbtNoDependencia" runat="server" Text="No" GroupName="Dependencia" Checked="true" />
                <asp:Label ID="Label11" runat="server" Text="Seleccionar tarea dependiente"></asp:Label>
                <asp:DropDownList ID="DropDownList2" runat="server">
                </asp:DropDownList>
            </div>
        </div>
    </asp:Panel>
    <div style="text-align: center">
        <asp:Button ID="btnCrearTarea" runat="server" Text="Crear Tarea" />
        <asp:Button ID="btnCrearFlujoTarea" runat="server" Text="Crear flujo de tareas" />
    </div>
    </form>
</body>
</html>
