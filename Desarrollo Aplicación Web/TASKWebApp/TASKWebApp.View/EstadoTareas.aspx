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
                    <asp:RadioButtonList ID="rbtlTipoFiltro" runat="server" RepeatLayout="Flow" RepeatDirection="Vertical" AutoPostBack="true">
                        <asp:ListItem Value="Buscar todas las tareas" Text="Buscar todas las tareas" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="Filtrar" Text="Filtrar"></asp:ListItem>
                    </asp:RadioButtonList>      &nbsp&nbsp&nbsp              
                         <asp:DropDownList ID="ddlMesesFiltro" runat="server">
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
                        </asp:DropDownList>&nbsp&nbsp&nbsp&nbsp
                    <asp:DropDownList ID="ddlAño" runat="server">
                            <asp:ListItem Text="2019" Value="1"></asp:ListItem>
                            <asp:ListItem Text="2018" Value="2"></asp:ListItem>
                            <asp:ListItem Text="2017" Value="3"></asp:ListItem>
                            <asp:ListItem Text="2016" Value="4"></asp:ListItem>
                            <asp:ListItem Text="2015" Value="5"></asp:ListItem>
                            <asp:ListItem Text="2014" Value="6"></asp:ListItem>
                            <asp:ListItem Text="2013" Value="7"></asp:ListItem>
                            <asp:ListItem Text="2012" Value="8"></asp:ListItem>
                            <asp:ListItem Text="2011" Value="9"></asp:ListItem>
                            <asp:ListItem Text="2010" Value="10"></asp:ListItem>
                        </asp:DropDownList>&nbsp&nbsp&nbsp&nbsp
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" />
                    <br />
                    <section class="section">
         <asp:UpdatePanel ID="upTablaTareas" runat="server">
            <ContentTemplate> 
     
                </div>
                
                <table class="table table-hover">
                <asp:Repeater ID="repTabla" runat="server">
                    <HeaderTemplate>
                            <thead>
                                <tr>
                                    <th scope="col">Nombre Tarea</th>
                                    <th scope="col">Estado</th>
                                    <th scope="col"><asp:Label ID="hdlblFechaFin" runat="server" Text="Fecha Fin"></asp:Label></th>
                                    <th scope="col">Avance</th>
                                </tr>
                            </thead>
                        <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                            <tr>
                                <td><asp:Label ID="lblSubSeparator" runat="server" Text=""></asp:Label><asp:Label ID="lblSubNombre" runat="server" Text=""></asp:Label></td>
                                <td><asp:Label ID="lblEstado" runat="server" Text=""></asp:Label></td>
                                <td><asp:Label ID="lblSubFechaFin" runat="server" Text=""></asp:Label></td>
                                <td><asp:Label ID="lblAvance" runat="server" Text=""></asp:Label></td>
                                <asp:Label ID="lblIdTarea" runat="server" Text="" Visible="false"></asp:Label>
                            </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                    </FooterTemplate>
                </asp:Repeater>
                </table>
             </ContentTemplate>
        </asp:UpdatePanel>

    

    </section>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdatePanel ID="udpTipoTarea" runat="server">
            <ContentTemplate>
                <asp:Label ID="Label6" runat="server" Text="Generar Reporte"></asp:Label>
                <div id="divReporte" style="width: 50%; float: right;" runat="server" >
                    <div style="width: 50%; float: left;">
                        <asp:Label ID="Label14" runat="server" Text="Por mes:"></asp:Label>&nbsp&nbsp&nbsp&nbsp
                        <asp:DropDownList ID="ddlMesReporte" runat="server">
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
                        <br />
                        <br />
                        <asp:Label ID="lblAño" runat="server" Text="Por año:"></asp:Label>&nbsp&nbsp&nbsp&nbsp
                          <asp:DropDownList ID="ddlAñosReporte" runat="server">
                            <asp:ListItem Text="2019" Value="1"></asp:ListItem>
                            <asp:ListItem Text="2018" Value="2"></asp:ListItem>
                            <asp:ListItem Text="2017" Value="3"></asp:ListItem>
                            <asp:ListItem Text="2016" Value="4"></asp:ListItem>
                            <asp:ListItem Text="2015" Value="5"></asp:ListItem>
                            <asp:ListItem Text="2014" Value="6"></asp:ListItem>
                            <asp:ListItem Text="2013" Value="7"></asp:ListItem>
                            <asp:ListItem Text="2012" Value="8"></asp:ListItem>
                            <asp:ListItem Text="2011" Value="9"></asp:ListItem>
                            <asp:ListItem Text="2010" Value="10"></asp:ListItem>
                        </asp:DropDownList>&nbsp&nbsp&nbsp&nbsp
                        <br />
                        <br />
                        <asp:Label ID="lblEstado" runat="server" Text="Por estado:"></asp:Label>&nbsp&nbsp&nbsp&nbsp
                          <asp:DropDownList ID="ddlEstados" runat="server">
                            <asp:ListItem Text="Todos los estados" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Completado" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Pendiente" Value="3"></asp:ListItem>
                        </asp:DropDownList>&nbsp&nbsp&nbsp&nbsp
                        <br />
                        <br />
                        <asp:Button ID="btnReporte" runat="server" Text="Imprimir Reporte"  />
                    </div>
              
                </div>

                
            </ContentTemplate>
        </asp:UpdatePanel>
       
   
    </asp:Panel>

   
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
