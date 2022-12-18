#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcWebUI.Areas.Accounts.Controllers
{
    [Area("Accounts")]
    public class UsersController : Controller
    {
        // Add service injections here
        private readonly IAccountService _accountService;

        public UsersController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // GET: Accounts/Users
        public IActionResult Index()
        {
            List<UserModel> userList = null; // TODO: Add get list service logic here
            return View(userList);
        }

        // GET: Accounts/Users/Details/5
        public IActionResult Details(int id)
        {
            UserModel user = null; // TODO: Add get item service logic here
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // GET: Accounts/Users/Create
        public IActionResult Create()
        {
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            ViewData["RoleId"] = new SelectList(null, "Id", "Name");
            return View();
        }

        // POST: Accounts/Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UserModel user)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add insert service logic here
                return RedirectToAction(nameof(Index));
            }
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            ViewData["RoleId"] = new SelectList(null, "Id", "Name", user.RoleId);
            return View(user);
        }

        // GET: Accounts/Users/Edit/5
        public IActionResult Edit(int id)
        {
            UserModel user = null; // TODO: Add get item service logic here
            if (user == null)
            {
                return NotFound();
            }
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            ViewData["RoleId"] = new SelectList(null, "Id", "Name", user.RoleId);
            return View(user);
        }

        // POST: Accounts/Users/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UserModel user)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add update service logic here
                return RedirectToAction(nameof(Index));
            }
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            ViewData["RoleId"] = new SelectList(null, "Id", "Name", user.RoleId);
            return View(user);
        }

        // GET: Accounts/Users/Delete/5
        public IActionResult Delete(int id)
        {
            UserModel user = null; // TODO: Add get item service logic here
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Accounts/Users/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // TODO: Add delete service logic here
            return RedirectToAction(nameof(Index));
        }
	}
}
