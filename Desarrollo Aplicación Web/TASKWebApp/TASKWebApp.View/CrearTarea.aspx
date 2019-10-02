<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CrearTarea.aspx.cs" Inherits="TASKWebApp.View.CrearTarea" %>

<asp:Content ID="Content1" ContentPlaceHolderID="tittle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
        <style type="text/css">
    .disabledStyle
    {
        border: 1px solid gray;
        color: Gray;
    }
    .enabledStyle
    {
        border: 1px solid Blue;
    }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <div style="text-align: center">
            <h1>Crear Tarea</h1>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel4" runat="server" Height="350px">
        <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="udpTipoCargaTarea" runat="server">
            <ContentTemplate>
                <div style="width: 50%; float: left;">
                    <asp:RadioButtonList ID="rbtlTipoCargaTarea" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rbtlTipoCargaTarea_SelectedIndexChanged">
                        <asp:ListItem Value="TareaPropia" Text="Tarea propia" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="TareaPredeterminada" Text="Tarea predeterminada"></asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:DropDownList ID="ddlTareasPredeterminadas" runat="server" OnSelectedIndexChanged="ddlTareasPredeterminadas_SelectedIndexChanged" AutoPostBack="True" Enabled="false" Visible = "false" AppendDataBoundItems="true">
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="Label8" runat="server" Text="Nombre Tarea*:"></asp:Label>
                    <asp:TextBox ID="txtNombreTarea" runat="server" Font-Size="Smaller" Width="300px"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label13" runat="server" Text="Descripcion"></asp:Label>
                    &nbsp&nbsp&nbsp&nbsp<asp:TextBox ID="txtDescripcion" TextMode="multiline" Columns="50" Rows="5" runat="server" MaxLength="500" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdatePanel ID="udpTipoTarea" runat="server">
            <ContentTemplate>
                <asp:RadioButtonList ID="rbtlTipoTarea" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rbtlTipoTarea_SelectedIndexChanged" >
                     <asp:ListItem Value="TareaUnica" Text="Tarea unica" Selected="True"></asp:ListItem>
                     <asp:ListItem Value="TareaRepetitiva" Text="Tarea repetitiva"></asp:ListItem>
                </asp:RadioButtonList>

                <div id="divTareaUnica" style="width: 50%; float: right;" runat="server" >
                    <div style="width: 50%; float: left;">
                        <asp:Label ID="Label14" runat="server" Text="Inicio:"></asp:Label>
                        <asp:TextBox ID="txtFechaInicio" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
                    </div>
                    <div style="width: 50%; float: right;">
                        <asp:Label ID="Label15" runat="server" Text="Fin*:"></asp:Label>
                        <asp:TextBox ID="txtFechaFin" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
                    </div>
                </div>

                <div id="divTareaRepetitiva" style="width: 50%; float: right;" runat="server" visible="false">
                    <h4>Opciones de repetición</h4>
                    <div style="width: 50%; float: left;">
                        <asp:Label ID="Label9" runat="server" Text="Hora inicio"></asp:Label>   
                        <asp:TextBox ID="txtHoraInicio" runat="server" TextMode="Time"></asp:TextBox>
                    </div>
                    <div style="width: 50%; float: right;">
                        <asp:Label ID="Label12" runat="server" Text="Hora fin"></asp:Label>
                        <asp:TextBox ID="txtHoraFin" runat="server" TextMode="Time"></asp:TextBox>
                    </div>
                    <div style="width: 100%;">
                        <asp:Label ID="Label1" runat="server" Text="Dia de semana: "></asp:Label>
                        <asp:CheckBoxList ID="cbxDiaSemana" runat="server" RepeatDirection="Horizontal">
                        </asp:CheckBoxList>
                    </div>
                    <div style="width: 100%;">
                        <asp:Label ID="Label2" runat="server" Text="Número de semana: "></asp:Label>
                        <asp:CheckBoxList ID="cbxNumeroSemana" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1" Text ="Semana 1"></asp:ListItem>
                            <asp:ListItem Value="2" Text ="Semana 2"></asp:ListItem>
                            <asp:ListItem Value="3" Text ="Semana 3"></asp:ListItem>
                            <asp:ListItem Value="4" Text ="Semana 4"></asp:ListItem>
                            <asp:ListItem Value="5" Text ="Semana 5"></asp:ListItem>
                            <asp:ListItem Value="6" Text ="Semana 6"></asp:ListItem>
                        </asp:CheckBoxList>
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
            </ContentTemplate>
        </asp:UpdatePanel>
        <div style="width: 50%; float: left">
            <asp:Label ID="Label16" runat="server" Text="Responsable*:"></asp:Label>
            &nbsp&nbsp&nbsp<asp:DropDownList ID="ddlResponsable" runat="server"></asp:DropDownList>
            <br />
            <br />
            <asp:UpdatePanel ID="udpDependencia" runat="server">
                <ContentTemplate>
                    <div id="divDependencia" runat="server">
                        <asp:Label ID="Label17" runat="server" Text="¿Esta tarea tiene dependencia?" RepeatLayout="Flow"></asp:Label>
                        <asp:RadioButtonList ID="rbtDependencia" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rbtDependencia_SelectedIndexChanged" >
                            <asp:ListItem Value="No" Text="No" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="Si" Text="Si"></asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:DropDownList ID="ddlTareaDependiente" runat="server">
                        </asp:DropDownList>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </asp:Panel>

    <asp:UpdatePanel ID="updButtons" runat="server">
        <ContentTemplate>
            <div style="text-align: center">
                <asp:Button ID="btnCrearTarea" runat="server" Text="Crear Tarea" />
                <asp:Button ID="btnCrearFlujoTarea" runat="server" Text="Crear flujo de tareas" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
