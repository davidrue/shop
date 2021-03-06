﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingtipToys.Models;
using System.Web.ModelBinding;
using System.Web.Routing;


/*
 * This is the controller for the Product Category 'KeyboardsAndMouses', when you are in the Configurator 
 */
namespace WingtipToys
{
  public partial class KeyboardsAndMouses : System.Web.UI.Page
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
      IQueryable<Product> query = _db.Products;

      query = query.Where(p => p.CategoryID == 6);

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