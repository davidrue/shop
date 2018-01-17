using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingtipToys.Models;
using WingtipToys.Logic;
using System.Web.ModelBinding;
using System.Web.Routing;

namespace WingtipToys
{
  public partial class ConfSwitcher : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Test()
        {

        }

        public Category GetActualProduct()
        {
            var _db = new WingtipToys.Models.ProductContext();
            Category query = _db.Categories.SingleOrDefault(Category => Category.CategoryName == "Processors");

            ShoppingCartActions actions = new ShoppingCartActions();
            List<CartItem> items = actions.GetCartItems();

            List<Product> products = new List<Product>();
            foreach (CartItem item in items)
            {
                //System.Diagnostics.Debug.WriteLine("Add " + item.Product.ProductName + " " + item.Product.ProductID);
                //System.Diagnostics.Debug.WriteLine("Aus DB geholt: " + (_db.Products.SingleOrDefault(Product => Product.ProductID == item.Product.ProductID).ProductName));
                products.Add(_db.Products.SingleOrDefault(Product => Product.ProductID == item.Product.ProductID));
            }


            Boolean hasProcessor = false;
            Boolean hasMainboard = false;
            Boolean hasGraphicsCards = false;
            Boolean hasHardDrive = false;
            Boolean hasCase = false;

            Boolean isFinished = true;

            if (!items.Any())
            {
                return query;
            }
            else
            {
                foreach (Product product in products)
                {
                    //System.Diagnostics.Debug.WriteLine(product.ProductName + " " + product.CategoryID);

                    switch (product.CategoryID)
                    {
                        case 1:
                            System.Diagnostics.Debug.WriteLine("has Processor = true");
                            hasProcessor = true;
                            break;
                        case 2:
                            System.Diagnostics.Debug.WriteLine("has GraphicsCard = true");
                            hasGraphicsCards = true;
                            break;
                        case 3:
                            System.Diagnostics.Debug.WriteLine("has Mainboard = true");
                            hasMainboard = true;
                            break;
                        case 4:
                            System.Diagnostics.Debug.WriteLine("has HardDrive = true");
                            hasHardDrive = true;
                            break;
                        case 5:
                            System.Diagnostics.Debug.WriteLine("has Case = true");
                            hasCase = true;
                            break;
                        default:
                            Response.Redirect("Configurator.aspx");
                            break;
                    }
                }


                if (!hasProcessor)
                {
                    // System.Diagnostics.Debug.WriteLine("Kein Prozessor!");
                    return query;
                }
                else if (!hasGraphicsCards)
                {
                    //  System.Diagnostics.Debug.WriteLine("Keine Grafikkarte!");
                    query = _db.Categories.SingleOrDefault(Category => Category.CategoryName == "GraphicsCards");
                    return query;
                }
                else if (!hasMainboard)
                {
                    //  System.Diagnostics.Debug.WriteLine("Kein Mainboard!");
                    query = _db.Categories.SingleOrDefault(Category => Category.CategoryName == "Mainboards");
                    return query;
                }
                else if (!hasHardDrive)
                {
                    //  System.Diagnostics.Debug.WriteLine("Keine HardDrives!");
                    query = _db.Categories.SingleOrDefault(Category => Category.CategoryName == "HardDrives");
                    return query;
                }
                else if (!hasCase)
                {
                    //  System.Diagnostics.Debug.WriteLine("Keine Cases!");
                    query = _db.Categories.SingleOrDefault(Category => Category.CategoryName == "Cases");
                    return query;
                }
                else
                {
                    query = _db.Categories.SingleOrDefault(Category => Category.CategoryName == "KeyboardsAndMouses");
                    return query;
                }
            }
        }
            public IQueryable<Product> GetProducts(
                        [QueryString("id")] int? categoryId,
                        [RouteData] string categoryName)
    {
      var _db = new WingtipToys.Models.ProductContext();
      IQueryable<Product> query = _db.Products;

      query = query.Where(p => p.CategoryID == 1);

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