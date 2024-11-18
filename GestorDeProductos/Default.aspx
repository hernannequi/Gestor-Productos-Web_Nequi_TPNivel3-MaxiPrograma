<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GestorDeProductos.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <div class="row row-cols-1 row-cols-md-3 g-4">
        
        <asp:Repeater runat="server" ID="repetidorDefault">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <h5 class="card-title"><%#Eval("Nombre") %></h5>
                        <a href="Favoritos.aspx?id=<%#Eval("Id") %>">🌟</a>
                        <img class="card-img-top" src="<%#Eval("ImagenUrl") %>" alt="Imagen del articulo" onerror="this.src='https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/1200px-Placeholder_view_vector.svg.png'" Style="max-width:350px;max-height:500px;">
                        <div class="card-body">
                            <a href="Detalle.aspx?id=<%#Eval("Id") %>">Ver Detalle</a>
                            <asp:Button runat="server" Text="Agregar" ID="btnAgregar" CssClass="btn btn-secondary" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" OnClick="btnAgregar_Click"/>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>
</asp:Content>
