using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingtipToys.Models;
using System.Web.ModelBinding;
using System.Web.Routing;
using WingtipToys.Logic;

namespace WingtipToys
{
  public partial class Processors : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Test()
        {

        }

    public IQueryable<Product> GetProducts(
                        [QueryString("id")] int? categoryId,
                        [RouteData] string categoryName)
    {
      var _db = new WingtipToys.Models.ProductContext();

            bool isIntel = false;
            bool isAmd = false;
           
            ShoppingCartActions actions = new ShoppingCartActions();
            List<CartItem> items = actions.GetCartItems();

            List<Product> products = new List<Product>();
            foreach (CartItem item in items)
            {
               products.Add(_db.Products.SingleOrDefault(Product => Product.ProductID == item.Product.ProductID));
            }

            //Filtere nach Mainboards
            List<Product> mainboards = new List<Product>();
            foreach (Product product in products)
            {
                if (product.CategoryID == 1)
                {
                    mainboards.Add(product);
                }
            }
            IQueryable<Product> query = _db.Products;
            query = query.Where(p => p.CategoryID == 2);
            if (mainboards.Any())
            {
                foreach(Product mainboard in mainboards)
                {
                    if (mainboard.isIntel)
                    {
                        isIntel = true;
                    }
                    if (mainboard.isAmd)
                    {
                        isAmd = true;
                    }
                }

                if (isIntel == false && isAmd ==true)
                {
                    query = query.Where(p => p.isAmd == true);
                }
                else if (isIntel == true && isAmd == false)
                {
                    query = query.Where(p => p.isIntel == true);
                }
                else if (isIntel == false && isAmd == false)
                {
                    query = query.Where(p => p.isIntel == false);
                    query = query.Where(p => p.isAmd == false);
                } //Falls beide true, dann einfach alles zurueckgeben

            }
            
           
            //if (categoryId.HasValue && categoryId > 0)
            //{
            //  query = query.Where(p => p.CategoryID == categoryId);
            //}

            //if (!String.IsNullOrEmpty(categoryName))
            //{
            //  query = query.Where(p =>
            //                      String.Compare(p.Category.CategoryName,
            //                      categoryName) == 0);
            //}
            return query;
    }
  }
}