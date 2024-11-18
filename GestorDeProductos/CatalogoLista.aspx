<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CatalogoLista.aspx.cs" Inherits="GestorDeProductos.CatalogoLista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">

    <h4>Bienvenido/a, esta es la lista de Articulos!</h4>
    <h5>Podes:</h5>
    <ul>
        <li>Tener una vista rapida</li>
        <li>Buscar articulos y filtrar avanzado segun criterios</li>
        <li>Agregar articulos nuevos</li>
        <li>Modificar los articulos ya existentes</li>
        <li>Eliminar articulos</li>
    </ul>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Label runat="server" Text="Buscar"></asp:Label>
                <asp:TextBox ID="txtFiltrar" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltrar_TextChanged" />
                <asp:CheckBox runat="server" ID="chkBxFiltroAvanzado" Text="Filtro Avanzado"
                    AutoPostBack="true" OnCheckedChanged="chkBxFiltro_CheckedChanged" />
            </div>
        </div>
    </div>


    <% if (chkBxFiltroAvanzado.Checked)
        { %>
    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Campo" runat="server" />
                <asp:DropDownList runat="server" ID="ddlCampo" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                    <asp:ListItem Text="Nombre" />
                    <asp:ListItem Text="Precio" />
                    <asp:ListItem Text="Marca" />
                    <asp:ListItem Text="Categoria" />
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Criterio" runat="server" />
                <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Filtro" runat="server" />
                <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" />
            </div>
        </div>

        <div class="row">
            <div class="col-3">
                <div class="mb-3">
                    <asp:Button Text="Buscar" runat="server" ID="btnBuscar" CssClass="btn btn-secondary" OnClick="btnBuscar_Click"></asp:Button>
                </div>
            </div>
        </div>
        <%}%>
    </div>

    <asp:GridView ID="dgvArticulos" runat="server" CssClass="table"
        AutoGenerateColumns="false" DataKeyNames="Id" AllowPaging="true" PageSize="10"
        OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged"
        OnPageIndexChanging="dgvArticulos_PageIndexChanging">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
            <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
            <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="✏️" />
        </Columns>
    </asp:GridView>
    <asp:Button runat="server" ID="btnAgregar" Text="Agregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click" />
</asp:Content>
