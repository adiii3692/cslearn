using Microsoft.AspNetCore.Mvc;
using Trial_Core_App.Models;
using Trial_Core_App.Data;
using Microsoft.EntityFrameworkCore;

namespace Trial_Core_App.Controllers
{
    public class ItemsController : Controller
    {
        //Store the context
        private readonly Trial_Core_AppContext _context;

        //A constructor for the controller to load the context
        public ItemsController(Trial_Core_AppContext context)
        {
            _context = context;
        }

        //Index method to print the index view
        public async Task<IActionResult> Index()
        {
            var items = await _context.Items.ToListAsync();
            return View(items);
        }

        //Method to create an item
        public IActionResult Create()
        {
            return View();
        }

        //The method which gets the post request and creates an item
        [HttpPost]
        //Bind the Id, Name and Price of the Input Item to their respective .Net types
        public async Task<IActionResult> Create([Bind("Id","Name","Price")]Item item)
        {
            //Check if the model is valid before creating
            if (ModelState.IsValid)
            {
                //Add the item to the database
                _context.Items.Add(item);
                //Save the changes
                await _context.SaveChangesAsync();
                //Redirect the user to the index page
                return RedirectToAction("Index");
            }
            //If not valid, just display the view
            return View(item);
        }

        //Method to get the item to edit
        public async Task<IActionResult> Edit(int id)
        {
            //Get the specific item to display
            var item = await _context.Items.FirstOrDefaultAsync(item => item.Id == id);
            return View(item);
        }

        //Method to edit an item
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price")]Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Items.Update(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(item);  
        }

        //Method to get the item to delete
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(item => item.Id == id);
            return View(item);
        }

        //Method which deletes the item
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            //Get the item to delete
            var item = await _context.Items.FirstOrDefaultAsync(item=>item.Id==id);

            if (item != null)
            {
                _context.Remove(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            //
            return View(item);
        }
    }
}
