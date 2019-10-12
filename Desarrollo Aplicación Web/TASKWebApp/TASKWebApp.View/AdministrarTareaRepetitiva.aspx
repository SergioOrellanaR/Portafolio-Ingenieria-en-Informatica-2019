<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdministrarTareaRepetitiva.aspx.cs" Inherits="TASKWebApp.View.AdministrarTareaRepetitiva" %>

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
                                    <th scope="col">Descripcion</th>
                                    <th scope="col">
                                        <asp:Label ID="hdlblFechaRepeticion" runat="server" Text="Fecha Repeticion"></asp:Label></th>
                                    <th scope="col">Responsable</th>
                                    <th scope="col">Dependencia de</th>
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
                                    <asp:Label ID="lblSubFechaRepeticion" runat="server" Text=""></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblResponsable" runat="server" Text=""></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblSubDependencia" runat="server" Text=""></asp:Label></td>
                                <td>
                                    <asp:Button ID="btnSubEdit" runat="server" Text="Editar" OnClick="btnSubEdit_Click" UseSubmitBehavior="false" /></td>
                                <td>
                                    <asp:Button ID="btnSubDelete" runat="server" Text="-" OnClick="btnSubDelete_Click" UseSubmitBehavior="false" /></td>

                            </tr>

                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                        </FooterTemplate>
                    </asp:Repeater>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>

        <div class="row">
            <div class="col-md-3 form-group">
                <asp:Button ID="btnVolver" runat="server" Text="Volver" class="btn btn-info btn-lg btn-block" OnClick="btnVolver_Click" />

            </div>
        </div>

    </section>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
