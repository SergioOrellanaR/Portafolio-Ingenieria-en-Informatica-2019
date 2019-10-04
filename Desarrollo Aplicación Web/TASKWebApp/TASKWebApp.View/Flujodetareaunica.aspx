<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Flujodetareaunica.aspx.cs" Inherits="TASKWebApp.View.Flujodetareaunica" %>
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
           

        <div style="float: left;">
            <asp:GridView ID="gvDatos" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
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
            <br />
            <div>
                <asp:Label ID="Label10" runat="server" Text="¿Esta tarea tiene dependencia?"></asp:Label>
                <asp:RadioButton ID="rbtSiDependencia" runat="server" Text="Si" GroupName="Dependencia" />
                <asp:RadioButton ID="rbtNoDependencia" runat="server" Text="No" GroupName="Dependencia" Checked="true" />
                <asp:Label ID="Label11" runat="server" Text="Seleccionar tarea dependiente"></asp:Label>
                <asp:DropDownList ID="DropDownList2" runat="server">
                </asp:DropDownList>
            </div>
            <div style="text-align:center">
                <asp:Button ID="btnAgregaralflujodetareas" runat="server" Text="Agregar al flujo de tareas" />
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
