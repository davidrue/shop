<%@ Page Title="PC Configurator" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Configurator.aspx.cs" Inherits="WingtipToys._Configurator" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <h1><%: Title %>.</h1>
        <h2>Configure your individual Device.</h2>
        <p class="lead">To build a functional computer, it is required to buy a Processor, a Graphic Card, a Mainboard, a Hard Drive and a suitable Case. Buying a Keyboard or a Mouse is not mandatory.</p>


    <div id="CategoryMenu" style="text-align: center">       
            <asp:ListView ID="ListView1"  
                ItemType="WingtipToys.Models.Category" 
                runat="server"
                SelectMethod="GetFirstCategory" >
                <ItemTemplate>
                    <b style="font-size: large; font-style: normal">
                    <a href="<%#: GetRouteUrl("ProductsByCategoryConfiguratorRoute", new {categoryName = Item.CategoryName}) %>">
                        <%#: Item.CategoryName %>
                    </a>
                    </b>
                </ItemTemplate>
                <ItemSeparatorTemplate>  |  </ItemSeparatorTemplate>
            </asp:ListView>
        </div>
</asp:Content>
