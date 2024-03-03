using EmployeesManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesManagement.Controllers
{
	public class ContactController : Controller
	{
		private readonly ContactDb dbContact;

		public ContactController()
		{
			dbContact = new ContactDb();
		}

		[HttpGet]
		public IActionResult IndexContact()
		{
			return View();
		}

		[HttpPost]
		public IActionResult IndexContact(Contact contact)
		{
			if (ModelState.IsValid)
			{
				string result = dbContact.SaveRecord(contact);
				TempData["msg"] = result;
				return RedirectToAction("IndexContact");
			}
			return View(contact);
		}
	}
}