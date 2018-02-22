using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using WingtipToys.Logic;
using WingtipToys.Models;


/*
 * This class is quite similar to the default class 'AddToCart'. It is accessed when you add an item in the configurator. It redirects you to the next product category.
 */
namespace WingtipToys
{
    public partial class AddToConfiguratorCart : System.Web.UI.Page
    {
        private ProductContext _db = new ProductContext();
        int categoryId = 99;
        protected void Page_Load(object sender, EventArgs e)
        {


            string rawId = Request.QueryString["ProductID"];
            int productId;
            if (!String.IsNullOrEmpty(rawId) && int.TryParse(rawId, out productId))
            {




                using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
                {

                    int tempId = Convert.ToInt16(rawId);
                    var productItem = _db.Products.SingleOrDefault(
                          c => c.ProductID == tempId);
                    categoryId = (int) productItem.CategoryID;
                    usersShoppingCart.AddToCart(Convert.ToInt16(rawId));


                }

            }
            else
            {
                Debug.Fail("ERROR : We should never get to AddToCart.aspx without a ProductId.");
                throw new Exception("ERROR : It is illegal to load AddToCart.aspx without setting a ProductId.");
            }

            //TODO if Category = x then Redirect to
            //Response.Redirect("ConfiguratorProcessors.aspx");

            switch (categoryId)
            {
                case 1:
                    Response.Redirect("Processors.aspx");
                    break;
                case 2:
                    Response.Redirect("GraphicsCards.aspx");
                    break;
                case 3:
                    Response.Redirect("HardDrives.aspx");
                    break;
                case 4:
                    Response.Redirect("Cases.aspx");
                    break;
                case 5:
                    Response.Redirect("KeyboardsandMouses.aspx");
                    break;
                case 6:
                    Response.Redirect("KeyboardsandMouses.aspx");
                    break;
                default:
                    Response.Redirect("Configurator.aspx");
                    break;
            }
        }
    }
}