<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CreacionTareaExitosa.aspx.cs" Inherits="TASKWebApp.View.CreacionTareaExitosa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="tittle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" runat="server">
    <div class="container col-md-offset-5">
        <h2>
            <asp:Label ID="lblTareasRechazadas" runat="server" Text="Tarea Creada Exitosamente"></asp:Label></h2>
        <br />
        
    </div>
    <div class="container col-md-offset-5">
            <div class="col-md-4 form-group form-group">                
                <a href="Home.aspx" class="btn btn-info btn-lg btn-block" role="button" aria-pressed="true">Volver al Inicio</a>
            </div>
        </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
