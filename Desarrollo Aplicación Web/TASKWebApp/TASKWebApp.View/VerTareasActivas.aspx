<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="VerTareasActivas.aspx.cs" Inherits="TASKWebApp.View.VerTareasActivas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="tittle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" runat="server">
    <section class="section container">
        <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="upTablaTareas" runat="server">
            <ContentTemplate>
                <div class="container text-center">
                    <h2>
                        <asp:Label ID="lblMisTareasActivas" runat="server" Text="Mis tareas activas"></asp:Label></h2>
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
                                        <asp:Label ID="hdlblFinalizar" runat="server" Text="Finalizar"></asp:Label></th>
                                    <th scope="col">
                                        <asp:Label ID="hdlblInformarProblema" runat="server" Text="Informar problema"></asp:Label></th>
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
                                    <asp:Button ID="btnSubFinalizar" runat="server" Text="+" OnClick="btnSubFinalizar_Click" UseSubmitBehavior="false" /></td>
                                <td>
                                    <asp:Button ID="btnSubInformarProblema" runat="server" Text="¡!" OnClick="btnSubInformarProblema_Click" UseSubmitBehavior="false" /></td>
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
                    <div class="col-md-offset-3">
                        <div id="divInformarProblema" runat="server" visible="false" class="center-block">
                            <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red" Font-Size="Medium"></asp:Label>
                            <div id="InformacionProblema" runat="server">
                                <div class="row form-group">
                                    <div>
                                        <strong><asp:Label ID="Label3"  runat="server" Text="Describa el problema que le impide desarrollar la tarea: "></asp:Label></strong>
                                        <asp:Label ID="lblNombreProblema" runat="server" Text=""></asp:Label>
                                        <asp:Label ID="lblInternalId" runat="server" Text="" Visible="false"></asp:Label>
                                    </div>                                    
                                </div>
                                <div class="row">
                                    <div class="col-md-4 form-group">
                                        <asp:TextBox ID="txtDescription" TextMode="multiline" Columns="50" Rows="5" runat="server" MaxLength="500" Style="margin: 0px; width: 484px; height: 190px;" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-7 form-group">
                                        <asp:Button ID="btnInformarProblema" runat="server" Text="Informar Problema" class="btn btn-info btn-lg btn-block" OnClick="btnInformarProblema_Click" />
                                    </div>
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
