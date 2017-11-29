using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingtipToys.Models;

namespace WingtipToys
{
  public partial class _Configurator : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
            
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

        public Category GetFirstCategory()
        {
            var _db = new WingtipToys.Models.ProductContext();
            Category query = _db.Categories.OrderByDescending(Category => Category.CategoryID).First();
            return query;
        }
    }
}