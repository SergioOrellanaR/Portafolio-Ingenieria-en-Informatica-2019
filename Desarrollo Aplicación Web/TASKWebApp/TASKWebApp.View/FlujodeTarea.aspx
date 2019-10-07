<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FlujodeTarea.aspx.cs" Inherits="TASKWebApp.View.FlujodeTarea" %>

<asp:Content ID="Content1" ContentPlaceHolderID="tittle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" runat="server">

    <section class="section">
        <div id="divTareaUnica" runat="server" class="container">
            <div class="container text-center">
                <asp:Label ID="Label7" runat="server"><h2>Crear Flujo de Tareas - Tareas Unicas</h2></asp:Label>
                <br />
            </div>

            <asp:GridView ID="gvDatosTareaUnica" CssClass="table table-hover" runat="server">
            </asp:GridView>

            <table class="table table-hover">
                <thead>
                    <tr>
                        <th scope="col">Nombre Tarea</th>
                        <th scope="col">Descripcion</th>
                        <th scope="col">Fecha Inicio</th>
                        <th scope="col">Fecha Fin</th>
                        <th scope="col">Dependendia de</th>
                        <th scope="col">Agregar</th>
                        <th scope="col">Eliminar</th>
                        <th scope="col">Editar</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <th scope="row">1</th>
                        <td>Mark</td>
                        <td>Otto</td>
                        <td>@mdo</td>
                        <td>@mdo</td>
                        <td>@mdo</td>
                        <td>@mdo</td>
                        <td>@mdo</td>
                    </tr>
                    <tr>
                        <th scope="row">2</th>
                        <td>Mark</td>
                        <td>Otto</td>
                        <td>@mdo</td>
                        <td>@mdo</td>
                        <td>@mdo</td>
                        <td>@mdo</td>
                        <td>@mdo</td>
                    </tr>
                    <tr>
                        <th scope="row">3</th>
                        <td>Mark</td>
                        <td>Otto</td>
                        <td>@mdo</td>
                        <td>@mdo</td>
                        <td>@mdo</td>
                        <td>@mdo</td>
                        <td>@mdo</td>
                    </tr>
                </tbody>
            </table>
            <div class="row">
                <div class="col-md-3 form-group">
                    <asp:Button ID="Button2" runat="server" Text="Crear Tarea" class="btn btn-info btn-lg btn-block" />
                </div>
                <div class="col-md-3 form-group">
                    <asp:Button ID="Button3" runat="server" Text="Crear Flujo de Tareas" class="btn btn-info btn-lg btn-block" />
                </div>
            </div>
            <div class="col-md-12 mb-5 element-animate">
                <div class="row">
                    <asp:Label ID="Label1" runat="server" CssClass="col-sm-2 " Text="Nombre Tarea"></asp:Label>
                    <div class="col-md-4 form-group">
                        <asp:TextBox class="form-control" ID="txtNombre" type="text" runat="server" placeholder="Nombre tarea"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <asp:Label ID="Label3" CssClass="col-sm-2 " runat="server" Text="Descripcion"></asp:Label>
                    <div class="col-md-4 form-group">
                        <asp:TextBox ID="txtDescription" TextMode="multiline" Columns="50" Rows="5" runat="server" MaxLength="500" Style="margin: 0px; width: 539px; height: 190px;" />
                    </div>
                </div>

                <div class="row">
                    <asp:Label ID="Label2" CssClass="col-sm-2 " runat="server" Text="Hora Inicio"></asp:Label>
                    <div class="col-md-2 form-group">
                        <asp:TextBox class="form-control" ID="TextBox1" TextMode="Time" runat="server" placeholder="Hora Inicio"></asp:TextBox>
                    </div>
                    <asp:Label ID="Label4" CssClass="col-sm-2 " runat="server" Text="Hora Fin"></asp:Label>
                    <div class="col-md-2 form-group">
                        <asp:TextBox class="form-control" ID="TextBox2" TextMode="Time" runat="server" placeholder="Hora Fin"></asp:TextBox>
                    </div>
                </div>

                <div class="row">
                    <asp:Label ID="Label5" CssClass="col-sm-2 " runat="server" Text="Fecha Inicio"></asp:Label>
                    <div class="col-md-2 form-group">
                        <asp:TextBox class="form-control" ID="TextBox3" TextMode="Date" runat="server" placeholder="Fecha Inicio"></asp:TextBox>
                    </div>
                    <asp:Label ID="Label6" CssClass="col-sm-2 " runat="server" Text="Fecha Fin"></asp:Label>
                    <div class="col-md-2 form-group">
                        <asp:TextBox class="form-control" ID="TextBox4" TextMode="Date" runat="server" placeholder="Fecha Fin"></asp:TextBox>
                    </div>
                </div>

                <div class="row">
                    <div class="col-sm-3">
                        <asp:Label ID="Label10" runat="server" Text="¿Esta tarea tiene dependencia?"></asp:Label>
                    </div>
                    <div class="col-sm-2">
                        <div class="form-check">
                            <asp:RadioButton ID="rbtSiDependencia" runat="server" Text="Si" GroupName="Dependencia" />
                            &nbsp&nbsp
                            <asp:RadioButton ID="rbtNoDependencia" runat="server" Text="No" GroupName="Dependencia" Checked="true" />
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-sm-3">
                        <asp:Label ID="Label11" runat="server" Text="Seleccionar tarea dependiente"></asp:Label>
                    </div>
                    <div class="col-sm-1">
                        <div class="form-check">
                            <asp:DropDownList CssClass="btn btn-info dropdown-toggle" ID="DropDownList2" runat="server">
                                <asp:ListItem Value="">¿Cual es el nombre de tu primera mascota?</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-5 form-group">
                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar al flujo de tareas" class="btn btn-info btn-lg btn-block" />
                    </div>
                </div>
            </div>
        </div>


        <div id="divTareaRepetitiva" runat="server" class="container">
            <div class="container text-center">
                <asp:Label ID="Label8" runat="server"><h2>Crear Flujo de Tareas - Predeterminadas Repetitivas</h2></asp:Label>
                <br />
            </div>

            <asp:GridView ID="GridView1" CssClass="table table-hover" runat="server">
            </asp:GridView>

            <table class="table table-hover">
                <thead>
                    <tr>
                        <th scope="col">Nombre Tarea</th>
                        <th scope="col">Descripcion</th>
                        <th scope="col">Fecha Inicio</th>
                        <th scope="col">Fecha Fin</th>
                        <th scope="col">Dependendia de</th>
                        <th scope="col">Agregar</th>
                        <th scope="col">Eliminar</th>
                        <th scope="col">Editar</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <th scope="row">1</th>
                        <td>Mark</td>
                        <td>Otto</td>
                        <td>@mdo</td>
                        <td>@mdo</td>
                        <td>@mdo</td>
                        <td>@mdo</td>
                        <td>@mdo</td>
                    </tr>
                    <tr>
                        <th scope="row">2</th>
                        <td>Mark</td>
                        <td>Otto</td>
                        <td>@mdo</td>
                        <td>@mdo</td>
                        <td>@mdo</td>
                        <td>@mdo</td>
                        <td>@mdo</td>
                    </tr>
                    <tr>
                        <th scope="row">3</th>
                        <td>Mark</td>
                        <td>Otto</td>
                        <td>@mdo</td>
                        <td>@mdo</td>
                        <td>@mdo</td>
                        <td>@mdo</td>
                        <td>@mdo</td>
                    </tr>
                </tbody>
            </table>

            <div class="row">
                <div class="col-md-3 form-group">
                    <asp:Button ID="Button4" runat="server" Text="Volver" class="btn btn-info btn-lg btn-block" />
                </div>
                <div class="col-md-3 form-group">
                    <asp:Button ID="Button5" runat="server" Text="Crear Flujo de Tareas" class="btn btn-info btn-lg btn-block" />
                </div>
            </div>
            <br />

            <div class="col-md-12 mb-5 element-animate">
                <div class="row">
                    <asp:Label ID="Label12" CssClass="col-sm-2 " runat="server" Text="Hora Inicio"></asp:Label>
                    <div class="col-md-2 form-group">
                        <asp:TextBox class="form-control" ID="TextBox5" TextMode="Time" runat="server" placeholder="Hora Inicio" Text="00:01"></asp:TextBox>
                    </div>
                    <asp:Label ID="Label13" CssClass="col-sm-2 " runat="server" Text="Hora Fin"></asp:Label>
                    <div class="col-md-2 form-group">
                        <asp:TextBox class="form-control" ID="TextBox6" TextMode="Time" runat="server" placeholder="Hora Fin" Text="23:59"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-2">
                        <asp:Label ID="Label20" runat="server" Text="Repetir por:"></asp:Label>
                    </div>
                    <div class="col-sm-3">
                        <asp:RadioButtonList ID="rbtlTipoRepeticion" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Dia de semana" Selected="True" Value="diaSemana">Dia de Semana &nbsp&nbsp</asp:ListItem>
                            <asp:ListItem Text="Dia de mes" Value="diaMes"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div id="divDiaSemana" runat="server">
                        <div class="col-sm-2">
                            <asp:Label ID="Label9" runat="server" Text="Repetir en días: "></asp:Label>
                        </div>
                        <div class="col-sm-10">
                            <asp:CheckBoxList ID="cbxDiaSemana" runat="server" RepeatDirection="Horizontal" AppendDataBoundItems="true">
                                <asp:ListItem Value="1" Text="Lunes">&nbsp Lunes &nbsp&nbsp</asp:ListItem>
                                <asp:ListItem Value="2" Text="Martes">&nbsp Martes &nbsp&nbsp</asp:ListItem>
                                <asp:ListItem Value="3" Text="Miercoles">&nbsp Miercoles &nbsp&nbsp</asp:ListItem>
                                <asp:ListItem Value="4" Text="Jueves">&nbsp Jueves &nbsp&nbsp</asp:ListItem>
                                <asp:ListItem Value="5" Text="Viernes">&nbsp Viernes &nbsp&nbsp</asp:ListItem>
                                <asp:ListItem Value="6" Text="Sábado">&nbsp Sábado &nbsp&nbsp</asp:ListItem>
                                <asp:ListItem Value="7" Text="Domingo">&nbsp Domingo &nbsp&nbsp</asp:ListItem>
                            </asp:CheckBoxList>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div id="divDiaMes" runat="server">
                        <div class="col-sm-2">
                            <asp:Label ID="Label21" runat="server" Text="Repetir los días: "></asp:Label>
                        </div>
                        <div class="col-sm-5">
                            <asp:DropDownList ID="ddlDiaDelMes" runat="server" CssClass="btn btn-info dropdown-toggle">
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
                    </div>
                </div>
                <br />
                <div class="row">
                    <div id="divNumeroSemana" runat="server" style="width: 100%;">
                        <div class="col-sm-2">
                            <asp:Label ID="Label22" runat="server" Text="Durante las semanas: "></asp:Label>
                        </div>
                        <div class="col-sm-10">
                            <asp:CheckBoxList ID="cbxNumeroSemana" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="1" Text="Semana 1">&nbsp Semana 1 &nbsp&nbsp</asp:ListItem>
                                <asp:ListItem Value="2" Text="Semana 2">&nbsp Semana 2 &nbsp&nbsp</asp:ListItem>
                                <asp:ListItem Value="3" Text="Semana 3">&nbsp Semana 3 &nbsp&nbsp</asp:ListItem>
                                <asp:ListItem Value="4" Text="Semana 4">&nbsp Semana 4 &nbsp&nbsp</asp:ListItem>
                                <asp:ListItem Value="5" Text="Semana 5">&nbsp Semana 5 &nbsp&nbsp</asp:ListItem>
                                <asp:ListItem Value="6" Text="Semana 6">&nbsp Semana 6 &nbsp&nbsp</asp:ListItem>
                            </asp:CheckBoxList>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div id="divMes" runat="server" style="width: 100%;">
                        <div class="col-sm-2">
                            <asp:Label ID="Label23" runat="server" Text="De: "></asp:Label>
                        </div>
                        <div class="col-sm-10">
                            <asp:DropDownList ID="ddlMeses" runat="server" CssClass="btn btn-info dropdown-toggle">
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
                <br />
                <div class="row">
                    <div class="col-sm-3">
                        <asp:Label ID="Label24" runat="server" Text="¿Esta tarea tiene dependencia?"></asp:Label>
                    </div>
                    <div class="col-sm-2">
                        <div class="form-check">
                            <asp:RadioButton ID="RadioButton3" runat="server" Text="Si" GroupName="Dependencia" />
                            &nbsp&nbsp
                            <asp:RadioButton ID="RadioButton4" runat="server" Text="No" GroupName="Dependencia" Checked="true" />
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-3">
                        <asp:Label ID="Label25" runat="server" Text="Seleccionar tarea dependiente"></asp:Label>
                    </div>
                    <div class="col-sm-1">
                        <div class="form-check">
                            <asp:DropDownList CssClass="btn btn-info dropdown-toggle" ID="DropDownList3" runat="server">
                                <asp:ListItem Value="">¿Cual es el nombre de tu primera mascota?</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <br />
            </div>

            <div class="row">
                <div class="col-md-5 form-group">
                    <asp:Button ID="Button1" runat="server" Text="Agregar Tareas" class="btn btn-info btn-lg btn-block" />
                </div>
            </div>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
