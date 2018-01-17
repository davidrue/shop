using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingtipToys.Models;
using WingtipToys.Logic;

namespace WingtipToys
{
  public partial class _Configurator : Page
  {

        private String last = "null";

    protected void Page_Load(object sender, EventArgs e)
    {
           // System.Diagnostics.Debug.WriteLine("SDHSJDHDSH");
        }

    private void Page_Error(object sender, EventArgs e)
    {
      // Get last error from the server.
      Exception exc = Server.GetLastError();

      // Handle specific exception.
      if (exc is InvalidOperationException)
      {
        // Pass the error on to the error page.
        Server.Transfer("ErrorPage.aspx?handler=Page_Error%20-%20Configurator.aspx",
            true);
      }
    }

        public IQueryable<Category> GetCategories()
        {
            var _db = new WingtipToys.Models.ProductContext();
            IQueryable<Category> query = _db.Categories;
            return query;
        }

        public Category GetNextCategory()
        {
            var _db = new WingtipToys.Models.ProductContext();
            Category query = _db.Categories.SingleOrDefault(Category => Category.CategoryName == "Mainboards");

           
            //  Category query = _db.Categories.OrderByDescending(Category => Category.CategoryID).First();
            return query;
        }

        public Category GetNextTestCategory()
        {
            var _db = new WingtipToys.Models.ProductContext();
            Category query = _db.Categories.SingleOrDefault(Category => Category.CategoryName == "Mainboards");

            ShoppingCartActions actions = new ShoppingCartActions();
            List <CartItem> items = actions.GetCartItems();

            List < Product > products = new List<Product>();
            foreach (CartItem item in items)
            {
                //System.Diagnostics.Debug.WriteLine("Add " + item.Product.ProductName + " " + item.Product.ProductID);
                //System.Diagnostics.Debug.WriteLine("Aus DB geholt: " + (_db.Products.SingleOrDefault(Product => Product.ProductID == item.Product.ProductID).ProductName));
               products.Add(_db.Products.SingleOrDefault(Product => Product.ProductID == item.Product.ProductID));
            }


            Boolean hasProcessor =false;
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
                            System.Diagnostics.Debug.WriteLine("has Mainboard = true");
                            hasMainboard = true;
                            break;
                        case 2:
                            System.Diagnostics.Debug.WriteLine("has Processor = true");
                            hasProcessor = true;
                            break;
                        case 3:
                            System.Diagnostics.Debug.WriteLine("has GraphicsCard = true");
                            hasGraphicsCards = true;
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

                
                    if (!hasMainboard)
                    {
                       // System.Diagnostics.Debug.WriteLine("Kein Prozessor!");
                        return query;
                    } else if (!hasProcessor)
                    {
                      //  System.Diagnostics.Debug.WriteLine("Keine Grafikkarte!");
                        query = _db.Categories.SingleOrDefault(Category => Category.CategoryName == "Processors");
                         return query;
                    } else if (!hasGraphicsCards)
                    {
                      //  System.Diagnostics.Debug.WriteLine("Kein Mainboard!");
                        query = _db.Categories.SingleOrDefault(Category => Category.CategoryName == "GraphicsCards");
                        return query;
                    } else if (!hasHardDrive)
                    {
                      //  System.Diagnostics.Debug.WriteLine("Keine HardDrives!");
                        query = _db.Categories.SingleOrDefault(Category => Category.CategoryName == "HardDrives");
                        return query;
                    }  else if (!hasCase)
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

        //public Category GetProcessorCategory()
        //{
        //    var _db = new WingtipToys.Models.ProductContext();
        //    Category query = _db.Categories.SingleOrDefault(Category => Category.CategoryName == "Mainboards");
          
        //    return query;
        //}
    }
}