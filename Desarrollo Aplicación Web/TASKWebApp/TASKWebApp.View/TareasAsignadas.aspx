<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="TareasAsignadas.aspx.cs" Inherits="TASKWebApp.View.TareasAsignadas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="tittle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" runat="server">
    <section class="section">
        <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="upTablaTareas" runat="server">
            <ContentTemplate>
                <div class="container text-center">
                    <h2>
                        <asp:Label ID="Label7" runat="server" Text="Tareas Asignadas"></asp:Label></h2>
                    <br />
                </div>

                <table class="table table-hover">
                    <asp:Repeater ID="repTabla" runat="server">
                        <HeaderTemplate>
                            <thead>
                                <tr>
                                    <th scope="col">Nombre Tarea</th>
                                    <th scope="col">Asignada por</th>
                                    <th scope="col">Descripcion</th>
                                    <th scope="col">
                                        <asp:Label ID="hdlblFechaInicio" runat="server" Text="Fecha Inicio"></asp:Label></th>
                                    <th scope="col">
                                        <asp:Label ID="hdlblFechaFin" runat="server" Text="Fecha Fin"></asp:Label></th>
                                    <th scope="col">Dependencia de</th>
                                    <th scope="col">
                                        <asp:Label ID="hdlblAceptar" runat="server" Text="Aceptar"></asp:Label></th>
                                    <th scope="col">
                                        <asp:Label ID="hdlblRechazar" runat="server" Text="Rechazar"></asp:Label></th>
                                </tr>
                            </thead>
                            <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="lblSubSeparator" runat="server" Text=""></asp:Label><asp:Label ID="lblSubNombre" runat="server" Text=""></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblAsignadaPor" runat="server" Text=""></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblSubDescripcion" runat="server" Text=""></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblSubFechaInicio" runat="server" Text=""></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblSubFechaFin" runat="server" Text=""></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblSubDependencia" runat="server" Text=""></asp:Label></td>
                                <td>
                                <asp:LinkButton ID="btnSubAceptar" runat="server" CssClass="btn btn-primary" OnClick="btnSubAceptar_Click">
                                     <span aria-hidden="true" class="glyphicon glyphicon-plus"></span>
                                </asp:LinkButton>
                                <td>
                                <asp:LinkButton ID="btnSubRechazar" runat="server" CssClass="btn btn-danger " OnClick="btnSubRechazar_Click" UseSubmitBehavior="false">
                                     <span aria-hidden="true" class="glyphicon glyphicon-minus"></span>
                                </asp:LinkButton>
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

        <asp:UpdatePanel ID="upTarea" runat="server">
            <ContentTemplate>
                <div id="divTareaRechazada" runat="server" visible="false">
                    <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red" Font-Size="Medium"></asp:Label>
                    <div id="InformacionRechazo" runat="server">
                        <div class="row">
                            <div>
                                <asp:Label ID="Label3" CssClass="col-sm-4 " runat="server" Text="Ingrese en detalle el motivo de rechazo de la tarea: "></asp:Label>
                                <asp:Label ID="lblNombreTareaRechazada" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lblInternalId" runat="server" Text="" Visible="false"></asp:Label>

                            </div>
                            <div class="col-md-4 form-group">
                                <asp:TextBox ID="txtDescription" TextMode="multiline" Columns="50" Rows="5" runat="server" MaxLength="500" Style="margin: 0px; width: 539px; height: 190px;" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3 form-group">
                                <asp:Button ID="btnRechazar" runat="server" Text="Rechazar tarea" class="btn btn-info btn-lg btn-block" OnClick="btnRechazar_Click" />
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
