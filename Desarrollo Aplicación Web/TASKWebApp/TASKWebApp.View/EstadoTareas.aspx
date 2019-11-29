<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EstadoTareas.aspx.cs" Inherits="TASKWebApp.View.EstadoTareas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="tittle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
    <asp:Panel ID="Panel1" runat="server">
        <div style="text-align: center">
            <h1>Mis Tareas</h1>
        </div>
    </asp:Panel>

    <asp:Panel ID="Panel4" runat="server" Height="350px">


        <asp:UpdatePanel ID="udpTipoFiltro" runat="server">
            <ContentTemplate>
                <div style="width: 50%; float: left;">
                    <div class="row col-md-offset-4">
                        <asp:Label ID="Label16" runat="server" Text="Responsable:"></asp:Label>
                        <asp:DropDownList CssClass="form-control" ID="ddlResponsable" runat="server" AppendDataBoundItems="true"></asp:DropDownList>

                        <asp:Label ID="Label4" runat="server" Text="Meses: "></asp:Label>
                        <asp:DropDownList CssClass="form-control" ID="ddlMeses" runat="server">
                            <asp:ListItem Text="Todos los meses" Value="13"></asp:ListItem>
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


                        <asp:Label ID="lblAño" runat="server" Text="Año:"></asp:Label>
                        <asp:DropDownList ID="ddlAño" runat="server">
                            <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                            <asp:ListItem Text="2018" Value="2018"></asp:ListItem>
                            <asp:ListItem Text="2017" Value="2017"></asp:ListItem>
                            <asp:ListItem Text="2016" Value="2016"></asp:ListItem>
                        </asp:DropDownList>&nbsp&nbsp&nbsp&nbsp
                    

                        <asp:Label ID="lblEstado" runat="server" Text="Por estado:"></asp:Label>&nbsp&nbsp&nbsp&nbsp
                          <asp:DropDownList ID="ddlEstados" runat="server">
                              <asp:ListItem Text="Todos" Value="0"></asp:ListItem>
                              <asp:ListItem Text="Asignado" Value="1"></asp:ListItem>
                              <asp:ListItem Text="En proceso" Value="2"></asp:ListItem>
                              <asp:ListItem Text="Completado" Value="3"></asp:ListItem>
                              <asp:ListItem Text="Reasignado" Value="4"></asp:ListItem>
                              <asp:ListItem Text="Rechazado" Value="5"></asp:ListItem>
                              <asp:ListItem Text="Cerrado" Value="6"></asp:ListItem>
                              <asp:ListItem Text="Fallido" Value="7"></asp:ListItem>
                              <asp:ListItem Text="Vencido" Value="8"></asp:ListItem>
                              <asp:ListItem Text="Suspendido" Value="9"></asp:ListItem>
                          </asp:DropDownList>&nbsp&nbsp&nbsp&nbsp
                    
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" onclick="btnBuscar_Click" />
                        <br />
                    </div>
                </div>


                <asp:UpdatePanel ID="upTablaTareas" runat="server">
                    <ContentTemplate>
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />

                        <div>
                            <asp:GridView ID="grdTareas" runat="server" 
                                SelectedRowStyle-BackColor="Yellow" 
                                AutoGenerateColumns="false"
                                AllowPaging="true"
                                PageSize = "10" 
                                OnPageIndexChanging="grdTareas_PageIndexChanging" >
                                <Columns>
                                    <asp:BoundField  HeaderText="Fecha de asignación" DataField="AssignationDate" dataformatstring="{0:dd/MM/yyyy HH:mm}" htmlencode="false" />
                                    <asp:BoundField  HeaderText="Fecha de Inicio" DataField="StartDate" dataformatstring="{0:dd/MM/yyyy HH:mm}" htmlencode="false" />
                                    <asp:BoundField  HeaderText="Fecha de Fin" DataField="EndDate" dataformatstring="{0:dd/MM/yyyy HH:mm}" htmlencode="false" />
                                    <asp:BoundField  HeaderText="Estado" DataField="TaskStatus" />
                                    <asp:BoundField  HeaderText="Nombre" DataField="TaskName" />
                                    <asp:BoundField  HeaderText="Descripción" DataField="Description" />
                                    <asp:BoundField  HeaderText="Nombre de asignador" DataField="AssignerName" />
                                    <asp:BoundField  HeaderText="Nombre de recibidor" DataField="ReceiverName" />
                                    <asp:BoundField  HeaderText="Justificación" DataField="Justification" />
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div>
                            <asp:Button ID="btnGeneratePDF" runat="server" Text="Imprimir Reporte" Visible="false" OnClick="btnGeneratePDF_Click"/>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
