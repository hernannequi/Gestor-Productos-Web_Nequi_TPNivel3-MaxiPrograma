<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioArticulo.aspx.cs" Inherits="GestorDeProductos.FormularioArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <h2>Articulo</h2>

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
                <asp:Button runat="server" Text="Aceptar" ID="btnAceptar" CssClass="btn btn-secondary" OnClick="btnAceptar_Click" />
                <a href="CatalogoLista.aspx">Cancelar</a>
            </div>
            <div class="mb-3">
                <asp:ScriptManager runat="server" />
                <asp:UpdatePanel ID="UpEliminar" runat="server">
                    <ContentTemplate>
                        <asp:Button runat="server" Text="Eliminar" ID="btnEliminar" CssClass="btn btn-warning" OnClick="btnEliminar_Click" />
                        <%if (ConfirmarEliminacion)
                            {%>
                        <asp:CheckBox runat="server" ID="chkBxConfirmarEliminacion" Text="Confirmar Eliminar" />
                        <asp:Button runat="server" ID="btnConfirmarEliminacion" Text="Confirmar Eliminar" CssClass="btn btn-danger" OnClick="btnConfirmarEliminacion_Click" />
                        <%}%>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>

        <div class="col-6">
            <div class="mb-3">
                <asp:Label for="ddlMarca" runat="server" CssClass="form-label">Marca: </asp:Label>
                <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-select" />
            </div>

            <div class="mb-3">
                <asp:Label for="ddlCategoria" runat="server" CssClass="form-label">Categoria: </asp:Label>
                <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select" />
            </div>

            <div class="mb-3">
                <asp:Label for="txtPrecio" runat="server" CssClass="form-label">Precio: </asp:Label>
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" />
            </div>
            <asp:UpdatePanel ID="UpImg" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <asp:Label for="txtImagenUrl" runat="server" CssClass="form-label">Enlace de la imagen: </asp:Label>
                        <asp:TextBox ID="txtImagenUrl" runat="server" CssClass="form-control" AutoPosback="true" OnTextChanged="txtImagenUrl_TextChanged" />
                    </div>
                    <asp:Image runat="server" ID="imgArticulo" Width="70%"
                        ImageUrl="https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/1200px-Placeholder_view_vector.svg.png" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
