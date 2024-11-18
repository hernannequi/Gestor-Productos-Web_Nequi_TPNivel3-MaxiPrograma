<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="GestorDeProductos.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <h2>Detalle del Articulo</h2>

    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Label for="txtId" runat="server" CssClass="form-label">Id: </asp:Label>
                <asp:TextBox ID="txtId" runat="server" CssClass="form-control" ReadOnly="true" />
            </div>

            <div class="mb-3">
                <asp:Label for="txtCodigo" runat="server" CssClass="form-label">Codigo: </asp:Label>
                <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <asp:Label for="txtNombre" runat="server" CssClass="form-label">Nombre: </asp:Label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <asp:Label for="txtDescripcion" runat="server" CssClass="form-label">Descripcion: </asp:Label>
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" />
            </div>

            <div class="mb-3">
                <asp:Label for="ddlMarca" runat="server" CssClass="form-label">Marca: </asp:Label>
                <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-select" />
            </div>
        </div>

        <div class="col-6">
            <div class="mb-3">
                <asp:Label for="ddlCategoria" runat="server" CssClass="form-label">Categoria: </asp:Label>
                <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select" />
            </div>

            <div class="mb-3">
                <asp:Label for="txtPrecio" runat="server" CssClass="form-label">Precio: </asp:Label>
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <asp:Label for="txtImagenUrl" runat="server" CssClass="form-label">Enlace de la imagen: </asp:Label>
                <asp:TextBox ID="txtImagenUrl" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtImagenUrl_TextChanged"/>
            </div>
            <asp:Image runat="server" ID="imgArticulo" Width="50%"
                ImageUrl="https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/1200px-Placeholder_view_vector.svg.png" />
        </div>
    </div>
</asp:Content>
