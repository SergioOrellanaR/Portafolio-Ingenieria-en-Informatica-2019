<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CrearTarea.aspx.cs" Inherits="TASKWebApp.View.CrearTarea" %>

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
 
    <asp:Panel ID="Panel4" runat="server" Height="350px">
        <div style="width: 50%; float: left;">
            <asp:RadioButton ID="rbtTareaPropia" runat="server" Text="Tarea propia" GroupName="TipoCargaTarea" Checked="true" />
            <asp:RadioButton ID="rbtTareaPredeterminada" runat="server" Text="Tarea predeterminada" GroupName="TipoCargaTarea" />
            <asp:DropDownList ID="ddlTareasPredeterminadas" runat="server">
            </asp:DropDownList>
        </div>
        <div style="width: 50%; float: right;">
            <asp:RadioButton ID="rbtTareaUnica" runat="server" Text="Tarea única" GroupName="TipoTarea" Checked="true" />
            <asp:RadioButton ID="rbtTareaRepetitiva" runat="server" Text="Tarea repetitiva" GroupName="TipoTarea" />
        </div>
        <div style="width: 50%; float: left;">
            <asp:Label ID="Label8" runat="server" Text="Nombre Tarea*:"></asp:Label>
            <asp:TextBox ID="txtNombreTarea" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label13" runat="server" Text="Descripcion"></asp:Label>
            &nbsp&nbsp&nbsp&nbsp<asp:TextBox ID="txtDescripcion" TextMode="multiline" Columns="50" Rows="5" runat="server" MaxLength="500"/>
        </div>

        <div style="width: 50%; float: right;">
            <div style="width: 50%; float: left;">
                <asp:Label ID="Label14" runat="server" Text="Inicio:"></asp:Label>
                <asp:TextBox ID="txtFechaInicio" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
            </div>
            <div style="width: 50%; float: right;">
            <asp:Label ID="Label15" runat="server" Text="Fin*:"></asp:Label>
            <asp:TextBox ID="txtFechaFin" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
                </div>
        </div>
        <div style="float:left;">
                <h4>Opciones de repetición</h4>
            <div >
                <asp:Label ID="Label9" runat="server" Text="Hora inicio"></asp:Label>
                &nbsp
               <asp:TextBox ID="txtHoraInicio" runat="server" TextMode="Time"></asp:TextBox>
                <asp:Label ID="Label12" runat="server" Text="Hora fin"></asp:Label>
                 &nbsp
                <asp:TextBox ID="txtHoraFin" runat="server" TextMode="Time"></asp:TextBox>
            </div>
            <div style="width: 100%;">
                <asp:CheckBox ID="cbxLunes" runat="server" Text="Lunes" />
                <asp:CheckBox ID="cbxMartes" runat="server" Text="Martes" />
                <asp:CheckBox ID="cbxMiercoles" runat="server" Text="Miercoles" />
                <asp:CheckBox ID="cbxJueves" runat="server" Text="Jueves" />
                <asp:CheckBox ID="cbxViernes" runat="server" Text="Viernes" />
                <asp:CheckBox ID="cbxSabado" runat="server" Text="Sábado" />
                <asp:CheckBox ID="cbxDomingo" runat="server" Text="Domingo" />
            </div>
            <div style="width: 100%;">
                <asp:CheckBox ID="cbxSemana1" runat="server" Text="Semana 1 " />
                <asp:CheckBox ID="cbxSemana2" runat="server" Text="Semana 2 " />
                <asp:CheckBox ID="cbxSemana3" runat="server" Text="Semana 3 " />
                <asp:CheckBox ID="cbxSemana4" runat="server" Text="Semana 4 " />
                <asp:CheckBox ID="cbxSemana5" runat="server" Text="Semana 5 " />
            </div>
            <div style="width: 100%;"> 
                <asp:CheckBox ID="cbxDiadelmes" runat="server" Text="Por día del mes " />
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                    <asp:ListItem Text="6" Value="6"></asp:ListItem>
                    <asp:ListItem Text="7" Value="7"></asp:ListItem>
                    <asp:ListItem Text="8" Value="8"></asp:ListItem>
                    <asp:ListItem Text="9" Value="9"></asp:ListItem>
                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                    <asp:ListItem Text="11" Value="11"></asp:ListItem>
                    <asp:ListItem Text="12" Value="12"></asp:ListItem>
                    <asp:ListItem Text="13" Value="13"></asp:ListItem>
                    <asp:ListItem Text="14" Value="14"></asp:ListItem>
                    <asp:ListItem Text="15" Value="15"></asp:ListItem>
                    <asp:ListItem Text="16" Value="16"></asp:ListItem>
                    <asp:ListItem Text="17" Value="17"></asp:ListItem>
                    <asp:ListItem Text="18" Value="18"></asp:ListItem>
                    <asp:ListItem Text="19" Value="19"></asp:ListItem>
                    <asp:ListItem Text="20" Value="20"></asp:ListItem>
                    <asp:ListItem Text="21" Value="21"></asp:ListItem>
                    <asp:ListItem Text="22" Value="22"></asp:ListItem>
                    <asp:ListItem Text="23" Value="23"></asp:ListItem>
                    <asp:ListItem Text="24" Value="24"></asp:ListItem>
                    <asp:ListItem Text="25" Value="25"></asp:ListItem>
                    <asp:ListItem Text="26" Value="26"></asp:ListItem>
                    <asp:ListItem Text="27" Value="27"></asp:ListItem>
                    <asp:ListItem Text="28" Value="28"></asp:ListItem>
                    <asp:ListItem Text="29" Value="29"></asp:ListItem>
                    <asp:ListItem Text="30" Value="30"></asp:ListItem>
                    <asp:ListItem Text="31" Value="31"></asp:ListItem>
                    <asp:ListItem Text="Último día de cada mes" Value="32"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div style="width: 100%;"> 
                <asp:CheckBox ID="cbxMeses" runat="server" Text="Por mes" />
                <asp:DropDownList ID="ddlMeses" runat="server">
                    <asp:ListItem Text="Enero" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Febrero" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Marzo" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Abril" Value="4"></asp:ListItem>
                    <asp:ListItem Text="Mayo" Value="5"></asp:ListItem>
                    <asp:ListItem Text="Junio" Value="6"></asp:ListItem>
                    <asp:ListItem Text="Julio" Value="7"></asp:ListItem>
                    <asp:ListItem Text="Agosto" Value="8"></asp:ListItem>
                    <asp:ListItem Text="Septiembre" Value="9"></asp:ListItem>
                    <asp:ListItem Text="Octubre" Value="10"></asp:ListItem>
                    <asp:ListItem Text="Noviembre" Value="11"></asp:ListItem>
                    <asp:ListItem Text="Diciembre" Value="12"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div style="width: 50%; float:left ">
            <asp:Label ID="Label16" runat="server" Text="Responsable*:"></asp:Label>
            &nbsp&nbsp&nbsp<asp:DropDownList ID="DropDownList4" runat="server"></asp:DropDownList>
            <br />
            <div>
                <asp:Label ID="Label17" runat="server" Text="¿Esta tarea tiene dependencia?"></asp:Label>
                <asp:RadioButton ID="rbtNoDependencia" runat="server" Text="No" GroupName="Dependencia" Checked="true" />
                <asp:RadioButton ID="rbtSiDependencia" runat="server" Text="Si" GroupName="Dependencia" />
                <asp:Label ID="Label18" runat="server" Text="Seleccionar tarea dependiente"></asp:Label>
                <asp:DropDownList ID="ddlTareaDependiente" runat="server">
                </asp:DropDownList>
            </div>
        </div>
    </asp:Panel>
    <div style="text-align: center">
        <asp:Button ID="btnCrearTarea" runat="server" Text="Crear Tarea" />
        <asp:Button ID="btnCrearFlujoTarea" runat="server" Text="Crear flujo de tareas" />
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
