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
                                    <th scope="col"><asp:Label ID="hdlblAceptar" runat="server" Text="Agregar"></asp:Label></th>
                                    <th scope="col"><asp:Label ID="hdlblRechazar" runat="server" Text="Eliminar"></asp:Label></th>

                                </tr>
                            </thead>
                        <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        
                            <tr>
                                <td><asp:Label ID="lblSubSeparator" runat="server" Text=""></asp:Label><asp:Label ID="lblSubNombre" runat="server" Text=""></asp:Label></td>
                                <td><asp:Label ID="lblAsignada por runat="server" Text=""></asp:Label></td>
                                <td><asp:Label ID="lblSubDescripcion" runat="server" Text=""></asp:Label></td>
                                <td><asp:Label ID="lblSubFechaInicio" runat="server" Text=""></asp:Label></td>
                                <td><asp:Label ID="lblSubFechaFin" runat="server" Text=""></asp:Label></td>
                                <td><asp:Label ID="lblSubDependencia" runat="server" Text=""></asp:Label></td>
                                <td><asp:Button ID="btnSubAceptar" runat="server" Text="+" OnClick="btnSubAceptar_Click" UseSubmitBehavior="false" /></td>
                                <td><asp:Button ID="btnSubRechazar" runat="server" Text="-" OnClick="btnSubRechazar_Click" UseSubmitBehavior="false"/></td>
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
           
        <br />
        <br />
        <br />
    </SeparatorTemplate>
</asp:Repeater>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="row">
            <div class="col-md-3 form-group">
                <asp:Button ID="btnVolver" runat="server" Text="Volver" class="btn btn-info btn-lg btn-block" OnClick="btnVolver_Click" />
    
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
