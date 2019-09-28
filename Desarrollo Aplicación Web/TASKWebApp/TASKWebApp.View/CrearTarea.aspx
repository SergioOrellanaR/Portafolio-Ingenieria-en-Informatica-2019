<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CrearTarea.aspx.cs" Inherits="TASKWebApp.View.CrearTarea" %>
<asp:Content ID="Content1" ContentPlaceHolderID="tittle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" runat="server">
    <asp:Panel ID="Panel1" runat="server">
       <div style="text-align:center">
           <h1>Crear Tarea</h1>
       </div>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" Height="475px">
        <div style="width:50%; float:left;">
            <asp:CheckBox ID="cbxTareaPropia" runat="server" Text="Tarea propia" />
            <asp:CheckBox ID="cbxTareaPredeterminada" runat="server" OnCheckedChanged="cbxTareaPredeterminada_CheckedChanged" Text="Tarea predeterminada" />
            <asp:DropDownList ID="ddlTareaPredet" runat="server">
            </asp:DropDownList>
        </div>
        <div style="width:50%; float:left;">
            <asp:CheckBox ID="cbxTareaunica" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" Text="Tarea única" />
            <asp:CheckBox ID="cbxTarearepetitiva" runat="server" Text="Tarea repetitiva" />
        </div>
        <div style="width:50%; float:left;"></div>
        <div style="width:50%; float:left;">
            <asp:Label ID="Label1" runat="server" Text="Nombre Tarea"></asp:Label> <asp:TextBox ID="txtNombreTarea" runat="server"></asp:TextBox>
        </div>
        <div style="width:50%; float:left;">
            <div style="width:50%; float:left;">
              <asp:Label ID="Label2" runat="server" Text="Hora inicio"></asp:Label> 
               <asp:TextBox ID="txtHoraInicio" runat="server" TextMode="Time"></asp:TextBox></div>
            <asp:Label ID="Label5" runat="server" Text="Hora fin"></asp:Label> 
            <asp:TextBox ID="txtHorafin" runat="server" TextMode="Time"></asp:TextBox></div>
            <div style="width:50%; float:left;">

            </div>
     
        <div style="width:50%; float:left;">
              

        </div>
              
        <div style="width:50%; float:left;"><asp:Label ID="Label3" runat="server" Text="Nombre Tarea"></asp:Label> <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></div>
        <div style="width:50%; float:left;">
            <div style="width:50%; float:left;">
              <asp:Label ID="Label4" runat="server" Text="Fecha inicio"></asp:Label> 
                <asp:TextBox ID="txtFechainicio" runat="server" TextMode="Date"></asp:TextBox>
                </div>
            <asp:Label ID="Label6" runat="server" Text="Fecha fin"></asp:Label> 
                <asp:TextBox ID="txtFechafin" runat="server" TextMode="Date"></asp:TextBox>
            </div>
       
            <div style="width:50%; float:left;">
                <asp:Label ID="Label7" runat="server" Text="Responsable"></asp:Label><asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
        </div>
        <div style="width:50%; float:left;">
        </div>
        <div style="width:50%; float:left;">
        </div>
        <div style="width:50%; float:left;">
           
            <asp:Label ID="Label8" runat="server" Text="¿Esta tarea tiene dependencia?"></asp:Label>
           
        </div>
        <div style="width:50%; float:left;">
        </div>
        <v style="width:50%; float:left;">
            <asp:CheckBox ID="cbxSidependencia" runat="server" Text="Si" /> 
             <div style="width:50%; float:left;">
                 <div style="width:50%; float:left; margin-top: 3px;">
                     <asp:CheckBox ID="cbxNodependencia" runat="server" Text="No" />
                 </div>
                 <asp:Label ID="Label9" runat="server" Text="Seleccionar tarea dependiente"></asp:Label>
                 <asp:DropDownList ID="ddlTareaDependiente" runat="server">
                 </asp:DropDownList>
            </div>
            <div style="width:50%; float:left; height: 44px;">
                
        </div>
        <div style="width:50%; float:left;">
            <asp:Button ID="btnCrearflujo" runat="server" Text="Crear flujo de tareas" />
        </div>
        <div style="width:50%; float:left;">
            <asp:Button ID="btnAceptar" runat="server" OnClick="Button1_Click" Text="Aceptar" />
        </div>    
       
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" runat="server">
    <div>
    </div>
</asp:Content>
