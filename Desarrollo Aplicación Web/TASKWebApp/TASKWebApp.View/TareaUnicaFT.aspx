<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="TareaUnicaFT.aspx.cs" Inherits="TASKWebApp.View.TareaUnicaFT" %>
<asp:Content ID="Content1" ContentPlaceHolderID="tittle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" runat="server">
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
                <asp:TextBox ID="txtDiadelmes" runat="server" TextMode="Number"></asp:TextBox>
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
        <asp:button id="btnCrearFlujoTarea" runat="server" text="Crear flujo de tareas" />
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
