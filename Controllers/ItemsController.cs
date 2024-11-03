using Microsoft.AspNetCore.Mvc;
using Trial_Core_App.Models;

namespace Trial_Core_App.Controllers
{
    public class ItemsController : Controller
    {
        public IActionResult Overview()
        {
            Item item = new Item { Name="Test Item"};
            return View(item);
        }
    }
}
