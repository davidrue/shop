	<%@ Page Title="Products" Language="C#" MasterPageFile="~/SiteConfig.Master" AutoEventWireup="true" 
         CodeBehind="Processors.aspx.cs" Inherits="WingtipToys.Processors" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div>
            <hgroup>
                <h2>Choose your Processor</h2>
            </hgroup>

            
                 <p class="lead">Be careful of which Processor you choose. Some Mainboards fit only with Intel, some with AMD. For your safety, the configurator is filtering for fitting components. If you have already chosen a mainboard, the processors are filtered.</p>
         

            <asp:ListView ID="productList" runat="server" 
                DataKeyNames="ProductID" GroupItemCount="4"
                ItemType="WingtipToys.Models.Product" SelectMethod="GetProducts">
                <EmptyDataTemplate>
                    <table >                        
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
                    <td/>
                </EmptyItemTemplate>
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                    <td runat="server">
                        <table>
                            <tr>
                                <td>
                                  <a href="<%#: GetRouteUrl("ProductByNameRoute", new {productName = Item.ProductName}) %>">
                                    <image src='/Catalog/Images/Thumbs/<%#:Item.ImagePath%>'
                                      width="100" height="75" border="1" />
                                  </a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="<%#: GetRouteUrl("ProductByNameRoute", new {productName = Item.ProductName}) %>">
                                      <%#:Item.ProductName%>
                                    </a>
                                    <br />
                                    <span>
                                        <b>Price: </b><%#:String.Format("{0:c}", Item.UnitPrice)%>
                                    </span>
                                    <br />
                                                  <a href="/Configurator/AddToConfiguratorCart.aspx?productID=<%#:Item.ProductID %>"> 
                                                  <span class="ProductListItem">
                                            <b>Add To Cart<b>
                                        </span>           
                                    </a>
                                </td>                               
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                        </p>
                    </td>
                </ItemTemplate>

                <LayoutTemplate>
                    <table style="width:100%;">
                        <tbody>
                            <tr>
                                <td>
                                    <table id="groupPlaceholderContainer" runat="server" style="width:100%">
                                        <tr id="groupPlaceholder"></tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr></tr>
                        </tbody>
                    </table>
                </LayoutTemplate>

            </asp:ListView>
                           
                  <ul class="nav navbar-nav navbar-left">
                           
                      <li><a runat="server" href="Mainboards">Zurück</a></li>
                        <li><a runat="server" href="GraphicsCards">Vorwärts</a></li>
                      
                                     
                   </ul>
             
                         <p>  <br/ > <br/ ></p>
                      
                  
        </div>

    </section>
   

</asp:Content>