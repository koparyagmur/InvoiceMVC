using InvoinceProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace InvoinceProject.Controllers
{
    public class HomeController : Controller
    {
        InvoicesDAL objInvoices = new InvoicesDAL();
        public IActionResult Index()
        {
            if (TempData["User"] != null)
            {
                List<Invoice> Invoices = new List<Invoice>();
                Invoices = objInvoices.GetAllInvoices().ToList();
                return View(Invoices);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Invoice invAdd)
        {
 
            if (ModelState.IsValid)
            {
                invAdd.Amount = invAdd.UnitPrice * invAdd.Quantity;
                objInvoices.AddInvoice(invAdd);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete_Invoices(int? id)
        {
            return View();

        }

        [HttpPost, ActionName("Delete_Invoices")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            objInvoices.DeleteInvoice(id);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Invoice inv = objInvoices.GetInvoice(id);

            if (inv == null)
            {
                return NotFound();
            }
            return View(inv);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, [Bind] Invoice cust)
        {
            if (ModelState.IsValid)
            {
                cust.Amount = cust.UnitPrice * cust.Quantity;
                objInvoices.UpdateInvoice(cust);
                return RedirectToAction("Index");
            }
            if (id != cust.Id)
            {
                return NotFound();
            }
            return View(objInvoices);
        }
    }
}
