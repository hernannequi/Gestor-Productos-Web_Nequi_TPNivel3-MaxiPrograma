<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="GestorDeProductos.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">

    <div class="card" style="width: 18rem;">
        <img class="card-img-top" src="..." alt="Card image cap">
        <div class="card-body">
            <h5 class="card-title">Hubo un Error</h5>
            <h5>Comunicalo al desarrollador, adjuntando el codigo de error.</h5>
            <asp:Label Text="" runat="server" ID="lblError" CssClass="card-text"></asp:Label>
            <div>
                <a href="Default.aspx" class="btn btn-secondary">Home</a>
            </div>
        </div>
    </div>
</asp:Content>
