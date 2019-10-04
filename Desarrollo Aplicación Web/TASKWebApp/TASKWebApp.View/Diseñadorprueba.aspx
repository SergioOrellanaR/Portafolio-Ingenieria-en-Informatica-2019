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
            <asp:Label ID="Label1" runat="server" Text="Nombre Tarea"></asp:Label>
            <asp:TextBox ID="txtNombreTarea" runat="server"></asp:TextBox>
        </div>
            <div style="width: 50%; float: left;">
              <h1></h1>
        </div>
        <div style="width: 50%; float: left;">
              <h1></h1>
        </div>
        <div style="width: 50%; float: left;">
            <asp:Label ID="Label3" runat="server" Text="Descripcion"></asp:Label>

            &nbsp&nbsp&nbsp&nbsp<asp:TextBox ID="txtDescription" TextMode="multiline" Columns="50" Rows="5" runat="server" MaxLength="500"/>
        <br />
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
        <div style="width: 50%; float: left;"><h1> </h1></div>
         <div style="width: 50%; float: left;"><h1> </h1></div>
        <div style="width: 50%; float: left;">
            <div style="width: 50%; float: left;">
                <asp:Label ID="Label8" runat="server" Text="Fecha inicio"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" TextMode="Date"></asp:TextBox>
            </div>
            <asp:Label ID="Label9" runat="server" Text="Fecha fin"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" TextMode="Date"></asp:TextBox>
        </div>
            <div style="width: 100%; float: left;">
                <h4>Opciones de repetición</h4>
            </div>
            <div style="width: 100%; float: left;">
                <asp:CheckBox ID="CheckBox1" runat="server" Text="Lunes" />
                <asp:CheckBox ID="CheckBox2" runat="server" Text="Martes" />
                <asp:CheckBox ID="CheckBox3" runat="server" Text="Miercoles" />
                <asp:CheckBox ID="CheckBox4" runat="server" Text="Jueves" />
                <asp:CheckBox ID="CheckBox5" runat="server" Text="Viernes" />
                <asp:CheckBox ID="CheckBox6" runat="server" Text="Sábado" />
                <asp:CheckBox ID="CheckBox7" runat="server" Text="Domingo" />
            </div>
            <div style="width: 100%; float: left;">
                <asp:CheckBox ID="CheckBox8" runat="server" Text="Semana 1 " />
                <asp:CheckBox ID="CheckBox9" runat="server" Text="Semana 2 " />
                <asp:CheckBox ID="CheckBox10" runat="server" Text="Semana 3 " />
                <asp:CheckBox ID="CheckBox11" runat="server" Text="Semana 4 " />
                <asp:CheckBox ID="CheckBox12" runat="server" Text="Semana 5 " />
            </div>
            <div style="width: 100%; float: left;">
                <asp:CheckBox ID="CheckBox13" runat="server" Text="Por día del mes " />
                <asp:TextBox ID="TextBox3" runat="server" TextMode="Number"></asp:TextBox>
            </div>
            <div style="width: 100%; float: left;">
                <asp:CheckBox ID="CheckBox14" runat="server" Text="Por meses " />
                <asp:DropDownList ID="DropDownList3" runat="server"></asp:DropDownList>
            </div>
        </div>

        <div style="width: 50%; float: left;">
            <asp:GridView ID="gvDatos" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField HeaderText="Nombre Tarea" />
                    <asp:BoundField HeaderText="Descripcion" />
                    <asp:BoundField HeaderText="Fecha Inicio" />
                    <asp:BoundField HeaderText="Hora Inicio" />
                    <asp:BoundField HeaderText="Fecha Fin" />
                    <asp:BoundField HeaderText="Hora Fin" />
                    <asp:BoundField HeaderText="Depende De" />
                    <asp:ButtonField ButtonType="Button" Text="Agregar" />
                    <asp:ButtonField ButtonType="Button" Text="Eliminar" />
                    <asp:ButtonField ButtonType="Button" Text="Editar" />
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
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
