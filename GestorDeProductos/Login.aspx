<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GestorDeProductos.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <div class="row">
        <div class="col-2">
            
            <div class="form-group">
                <asp:Label CssClass="form-control-" runat="server" ID="lblEmail" Text="Email:"></asp:Label>
                <asp:TextBox CssClass="form-control" runat="server" ID="txtEmail"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label runat="server" ID="lblContrasenia" CssClass="form-control" Text="Contraseña:"></asp:Label>
                <asp:TextBox runat="server" ID="txtContrasenia" CssClass="form-control"></asp:TextBox>
            </div>
            <asp:Button runat="server" ID="btnIngresar" Text="Ingresar" CssClass="btn btn-primary" OnClick="btnIngresar_Click" />
        </div>
    </div>
</asp:Content>
