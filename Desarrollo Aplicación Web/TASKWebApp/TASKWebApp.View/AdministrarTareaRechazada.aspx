<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdministrarTareaRechazada.aspx.cs" Inherits="TASKWebApp.View.AdministrarTareaRechazada" %>
<asp:Content ID="Content1" ContentPlaceHolderID="tittle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" runat="server">
     <section class="section">
        <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
        
         <asp:UpdatePanel ID="upTablaTareasRechazadas" runat="server">
            <ContentTemplate>
                <div class="container text-center">
                    <asp:Label ID="Label7" runat="server"><h2>Tareas Rechazadas</h2></asp:Label>
                    <br />
                </div>

                <table class="table table-hover">
                    <asp:Repeater ID="repTablaRechazo" runat="server">
                        <HeaderTemplate>
                            <thead>
                                <tr>
                                    <th scope="col">Nombre Tarea</th>
                                    <th scope="col">Descripcion</th>
                                    <th scope="col">
                                        <asp:Label ID="hdlblFechaInicio" runat="server" Text="Fecha Inicio"></asp:Label></th>
                                    <th scope="col">
                                        <asp:Label ID="hdlblFechaFin" runat="server" Text="Fecha Fin"></asp:Label></th>
                                    <th scope="col">Responsable</th>
                                    <th scope="col">Motivo Rechazo</th>
                                    <th scope="col">
                                        <asp:Label ID="hdlblEditar" runat="server" Text="Editar"></asp:Label></th>
                                    <th scope="col">
                                        <asp:Label ID="hdlblEliminar" runat="server" Text="Eliminar"></asp:Label></th>

                                </tr>
                            </thead>
                            <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>

                            <tr>
                                <td>
                                    <asp:Label ID="lblSubSeparator" runat="server" Text=""></asp:Label><asp:Label ID="lblSubNombre" runat="server" Text=""></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblSubDescripcion" runat="server" Text=""></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblSubFechaInicio" runat="server" Text=""></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblSubFechaFin" runat="server" Text=""></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblResponsable" runat="server" Text=""></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblMotivo" runat="server" Text=""></asp:Label></td>
                                <td>
                                    <asp:Button ID="btnSubEdit"  runat="server" Text="Editar" UseSubmitBehavior="false" /></td>
                                <td>
                                    <asp:Button ID="btnSubDelete"  runat="server" Text="-" OnClick="btnSubEliminarRechazado_Click" UseSubmitBehavior="false"/></td>
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


         <br />
         <br />
         <br />
         <br />

                <asp:UpdatePanel ID="upTablaTareasSuspendidas" runat="server">
            <ContentTemplate>
                <div class="container text-center">
                    <asp:Label ID="Label1" runat="server"><h2>Tareas Suspendidas</h2></asp:Label>
                    <br />
                </div>

                <table class="table table-hover">
                    <asp:Repeater ID="repTablaSuspension" runat="server">
                        <HeaderTemplate>
                            <thead>
                                <tr>
                                    <th scope="col">Nombre Tarea</th>
                                    <th scope="col">Descripcion</th>
                                    <th scope="col">
                                        <asp:Label ID="hdlblFechaInicio" runat="server" Text="Fecha Inicio"></asp:Label></th>
                                    <th scope="col">
                                        <asp:Label ID="hdlblFechaFin" runat="server" Text="Fecha Fin"></asp:Label></th>
                                    <th scope="col">Responsable</th>
                                    <th scope="col">Motivo Suspensión</th>
                                    <th scope="col">
                                        <asp:Label ID="hdlblEditar" runat="server" Text="Editar"></asp:Label></th>
                                    <th scope="col">
                                        <asp:Label ID="hdlblEliminar" runat="server" Text="Eliminar"></asp:Label></th>
                                </tr>
                            </thead>
                            <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>

                            <tr>
                                <td>
                                    <asp:Label ID="lblSubSeparator" runat="server" Text=""></asp:Label><asp:Label ID="lblSubNombre" runat="server" Text=""></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblSubDescripcion" runat="server" Text=""></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblSubFechaInicio" runat="server" Text=""></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblSubFechaFin" runat="server" Text=""></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblResponsable" runat="server" Text=""></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblMotivo" runat="server" Text=""></asp:Label></td>
                                <td>
                                    <asp:Button ID="btnSubEdit"  runat="server" Text="Editar" UseSubmitBehavior="false" /></td>
                                <td>
                                    <asp:Button ID="btnSubDelete"  runat="server" Text="-"  OnClick="btnSubEliminarProblema_Click" UseSubmitBehavior="false" /></td>
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
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
