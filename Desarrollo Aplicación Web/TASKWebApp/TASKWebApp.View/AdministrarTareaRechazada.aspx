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
                    <h2><asp:Label ID="lblTareasRechazadas" runat="server" Text="Tareas Rechazadas"></asp:Label></h2>
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
                                    <asp:Button ID="btnSubEdit"  runat="server" Text="Editar" OnClick="btnSubEditarRechazados_Click" UseSubmitBehavior="false" /></td>
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
                    <h2><asp:Label ID="lblTareasSuspendidas" runat="server" Text="Tareas Suspendidas"></asp:Label></h2>
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
                                        <asp:Label ID="hdlblEditar" runat="server" OnClick="btnSubEditarSuspendidos_Click" Text="Editar"></asp:Label></th>
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

         <asp:UpdatePanel ID="upEdicion" runat="server">
             <ContentTemplate>
                 <div id="divEditarInfo" runat="server" visible="false">
                     <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red" Font-Size="Medium"></asp:Label>
                     <div id="InformacionRechazo" runat="server">
                         <div class="row">
                             <asp:Label ID="lblInternalId" runat="server" Text="" Visible="false"></asp:Label>
                             <asp:Label ID="Label16" runat="server" Text="Responsable*:"></asp:Label>
                             &nbsp&nbsp&nbsp<asp:DropDownList ID="ddlResponsable" runat="server" AppendDataBoundItems="true"></asp:DropDownList><br />
                             <asp:Label ID="Label8" runat="server" Text="Nombre Tarea*:"></asp:Label>
                             <asp:TextBox ID="txtNombreTarea" runat="server" Font-Size="Smaller" Width="300px"></asp:TextBox>
                             <br />
                             <asp:Label ID="Label13" runat="server" Text="Descripcion"></asp:Label>
                             &nbsp&nbsp&nbsp&nbsp<asp:TextBox ID="txtDescripcion" TextMode="multiline" Columns="50" Rows="5" runat="server" MaxLength="500" />
                             <br />
                                 <div style="width: 50%; float: left;">
                                     <asp:Label ID="Label14" runat="server" Text="Inicio:"></asp:Label>
                                     <asp:TextBox ID="txtFechaInicio" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
                                 </div>
                                 <div style="width: 50%; float: right;">
                                     <asp:Label ID="Label15" runat="server" Text="Fin*:"></asp:Label>
                                     <asp:TextBox ID="txtFechaFin" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
                                 </div>
                         </div>
                        <div class="row">
                            <div class="col-md-3 form-group">
                                <asp:Button ID="btnEditar" runat="server" Text="Editar tarea" class="btn btn-info btn-lg btn-block" OnClick="btnEditar_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </section>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
