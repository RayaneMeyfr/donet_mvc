using Exercice1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exercice1.Controllers
{
    public class ContactController : Controller
    {
        private static List<Contact> contacts = new List<Contact>
        {
            new Contact{Id = 1,Name = "Dupont",FirstName = "Jean",MobileNumber = "0601020304"},
            new Contact{Id = 2, Name = "Martin", FirstName = "Sophie", MobileNumber = "0611223344"},
            new Contact{Id = 3, Name = "Bernard", FirstName = "Lucas", MobileNumber = "0699887766"}
        };

        public IActionResult ListContacts()
        {
            return View(contacts);
        }

        public IActionResult Details(int id)
        {
            Contact contact = contacts.FirstOrDefault(c => c.Id == id);

            if (contact == null)
            {
                return NotFound();
            }

            ViewData["contact"] = contact;

            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View(contact);
            }

            contacts.Add(contact);
            return RedirectToAction("ListContacts");
        }
    }
}
