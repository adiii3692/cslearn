using Microsoft.AspNetCore.Mvc;
using Trial_Core_App.Models;

namespace Trial_Core_App.Controllers
{
    public class ItemsController : Controller
    {
        //To learn how the basic action methods work that return a view
        public IActionResult Overview()
        {
            Item item = new Item { Name="Test Item"};
            return View(item);
        }

        //Learn the various Action Parameters below: 

        //Learn how to use URL Segments as action parameters
        public IActionResult Edit(int itemId)
        {
            return Content("Id = " + itemId);
        }

        //String query parameters are of the form: /items/edit?itemId=2
    }
}
