<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="GestorDeProductos.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <div>
        <h3>Mis Favoritos</h3>
    </div>
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater runat="server" ID="repetidorFavoritos">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <h5 class="card-title"><%#Eval("Nombre") %></h5>
                        <asp:Button runat="server" ID="btnEliminarFav" Text="X" CssClass="btn btn-secondary" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" OnClick="btnEliminarFav_Click" />
                        <img class="card-img-top" src="<%#Eval("ImagenUrl") %>" alt="Imagen del articulo" onerror="this.src='https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/1200px-Placeholder_view_vector.svg.png'" style="max-width: 350px; max-height: 500px;">
                        <div class="card-body">
                            <a href="Detalle.aspx?id=<%#Eval("Id") %>">Ver Detalle</a>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
