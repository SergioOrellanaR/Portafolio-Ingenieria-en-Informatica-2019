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
                    <asp:Label ID="Label7" runat="server"><h2>Tareas Asignadas</h2></asp:Label>
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
                                    <th scope="col"><asp:Label ID="hdlblFechaInicio" runat="server" Text="Fecha Inicio"></asp:Label></th>
                                    <th scope="col"><asp:Label ID="hdlblFechaFin" runat="server" Text="Fecha Fin"></asp:Label></th>
                                    <th scope="col">Dependencia de</th>
                                    <th scope="col"><asp:Label ID="hdlblAceptar" runat="server" Text="Aceptar"></asp:Label></th>
                                    <th scope="col"><asp:Label ID="hdlblRechazar" runat="server" Text="Rechazar"></asp:Label></th>
                                </tr>
                            </thead>
                        <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                            <tr>
                                <td><asp:Label ID="lblSubSeparator" runat="server" Text=""></asp:Label><asp:Label ID="lblSubNombre" runat="server" Text=""></asp:Label></td>
                                <td><asp:Label ID="lblAsignadaPor" runat="server" Text=""></asp:Label></td>
                                <td><asp:Label ID="lblSubDescripcion" runat="server" Text=""></asp:Label></td>
                                <td><asp:Label ID="lblSubFechaInicio" runat="server" Text=""></asp:Label></td>
                                <td><asp:Label ID="lblSubFechaFin" runat="server" Text=""></asp:Label></td>
                                <td><asp:Label ID="lblSubDependencia" runat="server" Text=""></asp:Label></td>
                                <td><asp:Button ID="btnSubAceptar" runat="server" Text="+"  UseSubmitBehavior="false" /></td>
                                <td><asp:Button ID="btnSubRechazar" runat="server" Text="-"  UseSubmitBehavior="false"/></td>
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
<asp:Repeater ID="repSubTask" runat="server">
    <HeaderTemplate>
        Contenido de repeater
    </HeaderTemplate>
    <ItemTemplate>
        <div id="divTarea" runat="server">
                    <div id="InformacionRechazo" runat="server">
                        <div class="row">
                            <asp:Label ID="Label3" CssClass="col-sm-2 " runat="server" Text="Motivo de Rechazo"></asp:Label>
                            <div class="col-md-4 form-group">
                                <asp:TextBox ID="txtDescription" TextMode="multiline" Columns="50" Rows="5" runat="server" MaxLength="500" Style="margin: 0px; width: 539px; height: 190px;" />
                            </div>
                        </div>
                        <div class="row">
            <div class="col-md-3 form-group">
                <asp:Button ID="btnEnviar" runat="server" Text="Enviar" class="btn btn-info btn-lg btn-block" />
            </div>
        </div>
                    </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
                </ContentTemplate>
            </asp:UpdatePanel>
        
    </section>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
