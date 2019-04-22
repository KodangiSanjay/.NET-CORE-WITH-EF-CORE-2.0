using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpensesManager.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExpensesManager.Controllers
{
    public class ExpenseController : Controller
    {
        // GET: /<controller>/
        ExpensesDataAccessLayer expensesDataAccessLayer = new ExpensesDataAccessLayer();
        public IActionResult Index(string searchstring)
        {
            List<ExpenseReport> lstEmployee = new List<ExpenseReport>();
            lstEmployee = expensesDataAccessLayer.GetAllExpenses().ToList();

            if (!String.IsNullOrEmpty(searchstring))
            {
                lstEmployee = expensesDataAccessLayer.SearchExpenses(searchstring).ToList();
            }
            return View(lstEmployee);
        }

        [HttpPost]
        public ActionResult Create(ExpenseReport newExpense)
        {
            if (ModelState.IsValid)
            {
                if (newExpense.ItemId > 0)
                {
                    expensesDataAccessLayer.UpdateExpense(newExpense);
                }
                else
                {
                    expensesDataAccessLayer.AddExpense(newExpense);
                }
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public ActionResult Delete(int ItemId)
        {
            expensesDataAccessLayer.DeleteExpense(ItemId);
            return RedirectToAction("Index");
        }

        public ActionResult AddEditExpenses(int ItemId)
        {
            ExpenseReport objexpensereport = new ExpenseReport();
            if(ItemId>0)
            {
                objexpensereport = expensesDataAccessLayer.GetExpenses(ItemId);

            }
            return PartialView("_expenseForm", objexpensereport);
        }

        public ActionResult ExpenseSummary()
        {
            return PartialView("_expenseReport");
        }

        public JsonResult GetMonthlyExpense()
        {
            Dictionary<string, decimal> monthlyExpense = expensesDataAccessLayer.CalculateMonthlyExpenses();
            return new JsonResult(monthlyExpense);
        }

        public JsonResult GetWeeklyExpense()
        {
            Dictionary<string, decimal> monthlyExpense = expensesDataAccessLayer.CalculateWeeklyExpenses();
            return new JsonResult(monthlyExpense);
        }
    }
}
