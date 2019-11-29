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
                    <h2>
                        <asp:Label ID="lblInicialMessage" runat="server" Text="Tareas Repetitivas"></asp:Label></h2>
                    <br />
                </div>

                <div class="container">
                    <table class="table table-hover">
                        <asp:Repeater ID="repTabla" runat="server">
                            <HeaderTemplate>
                                <thead>
                                    <tr>
                                        <th scope="col">Nombre Tarea</th>
                                        <th scope="col">Descripcion</th>
                                        <th scope="col">
                                            <asp:Label ID="hdlblFechaRepeticion" runat="server" Text="Fecha Repetición"></asp:Label></th>
                                        <th scope="col">Hora</th>
                                        <th scope="col">Responsable</th>
                                        <%--                                    <th scope="col">Dependencia de</th>--%>
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
                                        <asp:Label ID="lblNombreTarea" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblSubDescripcion" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblSubFechaRepetición" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblSubHora" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblResponsable" runat="server" Text=""></asp:Label></td>
                                    <td>
                                        <asp:LinkButton ID="btnSubEdit" runat="server" CssClass="btn btn-primary" OnClick="btnSubEditarRepetitivo_Click" UseSubmitBehavior="false">
                                     <span aria-hidden="true" class="glyphicon glyphicon-edit"></span>
                                        </asp:LinkButton>
                                    <td>
                                        <asp:LinkButton ID="btnSubDelete" runat="server" CssClass="btn btn-danger" OnClick="btnSubEliminarRepetitivo_Click" UseSubmitBehavior="false">
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
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdatePanel ID="upEdicion" runat="server">
            <ContentTemplate>
                <div id="divEditarInfo" runat="server" visible="false">
                    <strong>
                        <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red" Font-Size="Medium"></asp:Label></strong>
                    <div class="row col-md-offset-3" id="InformacionRechazo" runat="server">

                        <div class="col-sm-4">
                            <asp:Label ID="lblInternalId" runat="server" Text="" Visible="false"></asp:Label>
                            <asp:Label ID="Label16" runat="server" Text="Responsable:"></asp:Label>
                            <asp:DropDownList CssClass="form-control" ID="ddlResponsable" runat="server" AppendDataBoundItems="true"></asp:DropDownList><br />
                            <asp:Label ID="Label8" runat="server" Text="Nombre Tarea:"></asp:Label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="txtNombreTarea" runat="server" Font-Size="Smaller"></asp:TextBox>
                            </div>
                            <asp:Label ID="Label13" runat="server" Text="Descripcion"></asp:Label>
                            <asp:TextBox CssClass="form-control" ID="txtDescripcion" TextMode="multiline" Columns="50" Rows="5" runat="server" MaxLength="500" />
                            <br />
                        </div>

                        <div class="col-sm-4">
                            <div id="divTareaRepetitiva" runat="server">
                                <h4>Opciones de repetición</h4>
                                <div class="col-md-5 form-group">
                                    <asp:Label ID="Label9" runat="server" Text="Hora inicio"></asp:Label>
                                    <asp:TextBox CssClass="form-control" ID="txtHoraInicio" runat="server" TextMode="Time" Text="00:01"></asp:TextBox>
                                </div>
                                <div class="col-md-5 form-group">
                                    <asp:Label ID="Label12" runat="server" Text="Hora fin"></asp:Label>
                                    <asp:TextBox CssClass="form-control" ID="txtHoraFin" runat="server" TextMode="Time" Text="23:59"></asp:TextBox>
                                </div>

                                <div id="divDiaSemana" runat="server" style="width: 100%;">
                                    <div class="col-md-5 form-group">
                                        <asp:Label ID="Label1" runat="server" Text="Repetir en días: "></asp:Label>
                                    </div>
                                    <div class="form-group">
                                        <asp:CheckBoxList ID="cbxDiaSemana" runat="server" RepeatDirection="Horizontal" AppendDataBoundItems="true">
                                            <asp:ListItem Value="1" Text="Lunes"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Martes"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Miercoles"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="Jueves"></asp:ListItem>
                                            <asp:ListItem Value="5" Text="Viernes"></asp:ListItem>
                                            <asp:ListItem Value="6" Text="Sábado"></asp:ListItem>
                                            <asp:ListItem Value="7" Text="Domingo"></asp:ListItem>
                                        </asp:CheckBoxList>
                                    </div>
                                </div>

                                <div id="divDiaMes" runat="server" style="width: 100%;">
                                    <div class="col-md-5 form-group">
                                        <asp:Label ID="Label5" runat="server" Text="Repetir los días: "></asp:Label>
                                    </div>
                                    <asp:DropDownList ID="ddlDiaDelMes" runat="server">
                                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                        <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                        <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                        <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                        <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                        <asp:ListItem Text="13" Value="13"></asp:ListItem>
                                        <asp:ListItem Text="14" Value="14"></asp:ListItem>
                                        <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                        <asp:ListItem Text="16" Value="16"></asp:ListItem>
                                        <asp:ListItem Text="17" Value="17"></asp:ListItem>
                                        <asp:ListItem Text="18" Value="18"></asp:ListItem>
                                        <asp:ListItem Text="19" Value="19"></asp:ListItem>
                                        <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                        <asp:ListItem Text="21" Value="21"></asp:ListItem>
                                        <asp:ListItem Text="22" Value="22"></asp:ListItem>
                                        <asp:ListItem Text="23" Value="23"></asp:ListItem>
                                        <asp:ListItem Text="24" Value="24"></asp:ListItem>
                                        <asp:ListItem Text="25" Value="25"></asp:ListItem>
                                        <asp:ListItem Text="26" Value="26"></asp:ListItem>
                                        <asp:ListItem Text="27" Value="27"></asp:ListItem>
                                        <asp:ListItem Text="28" Value="28"></asp:ListItem>
                                        <asp:ListItem Text="29" Value="29"></asp:ListItem>
                                        <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                        <asp:ListItem Text="31" Value="31"></asp:ListItem>
                                        <asp:ListItem Text="Último día de cada mes" Value="32"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                <div id="divNumeroSemana" runat="server" style="width: 100%;">
                                    <div class="col-md-5 form-group">
                                        <asp:Label ID="Label2" runat="server" Text="Durante las semanas: "></asp:Label>
                                    </div>
                                    <div class="form-group">
                                        <asp:CheckBoxList ID="cbxNumeroSemana" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="1" Text="Semana 1"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Semana 2"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Semana 3"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="Semana 4"></asp:ListItem>
                                            <asp:ListItem Value="5" Text="Semana 5"></asp:ListItem>
                                            <asp:ListItem Value="6" Text="Semana 6"></asp:ListItem>
                                        </asp:CheckBoxList>
                                    </div>
                                </div>

                                <div id="divMes" runat="server" style="width: 100%;">
                                    <div class="col-md-5 form-group">
                                        <asp:Label ID="Label4" runat="server" Text="De: "></asp:Label>
                                    </div>
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
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="container col-md-offset-3">
                        <div class="col-md-4 form-group">
                            <asp:Button ID="btnEditar" runat="server" Text="Editar tarea" class="btn btn-info btn-lg btn-block" OnClick="btnEditar_Click" />
                        </div>
                    </div>
                    <br />
                </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </section>

    <asp:Label ID="lblMeme" runat="server" Text=""></asp:Label>
</asp:Content>

