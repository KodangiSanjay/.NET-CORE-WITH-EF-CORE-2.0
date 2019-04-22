using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesManager.Models
{
    public class ExpensesDataAccessLayer
    {
        ExpenseDBContext expenseDb = new ExpenseDBContext();

        public IEnumerable<ExpenseReport> GetAllExpenses()
        {
            try
            {
                return expenseDb.ExpenseReport.ToList();

            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<ExpenseReport> SearchExpenses(string searchString)
        {
            List<ExpenseReport> exp = new List<ExpenseReport>();
                try
            {
                exp = GetAllExpenses().ToList();
                return exp.Where(x => x.ItemName.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) != -1);
            }
            catch
            {
                throw;
            }
        }

        public void AddExpense(ExpenseReport expense)
        {
            try
            {
                expenseDb.ExpenseReport.Add(expense);
                expenseDb.SaveChanges();

                                        
            }
            catch
            {

            }
        }

        public void UpdateExpense(ExpenseReport expense)
        {
            try
            {
                expenseDb.ExpenseReport.Update(expense);
                expenseDb.SaveChanges();

            }
            catch
            {
                throw;
            }
        }

        public ExpenseReport GetExpenses(int id)
        {
            try
            {
                ExpenseReport expense = expenseDb.ExpenseReport.Find(id);
                return expense;

            }
            catch
            {
                throw;
            }
        }

        public void DeleteExpense(int id)
        {
            try
            {
                ExpenseReport expense = expenseDb.ExpenseReport.Find(id);
                expenseDb.ExpenseReport.Remove(expense);
                expenseDb.SaveChanges();
            }
            catch
            {

            }
        }

        public Dictionary<string,decimal> CalculateWeeklyExpenses()
        {
            ExpensesDataAccessLayer objExpenses = new ExpensesDataAccessLayer();
            List<ExpenseReport> lstEmployee = new List<ExpenseReport>();

            Dictionary<string, decimal> dictMonthlySum = new Dictionary<string, decimal>();
            decimal FoodSum = expenseDb.ExpenseReport.Where(e => e.Category == "Food" && (e.ExpenseDate > DateTime.Now.AddDays(-7))).Select(e => e.Amount).Sum();
            decimal ShoppingSum = expenseDb.ExpenseReport.Where(e => e.Category == "Shopping" && (e.ExpenseDate > DateTime.Now.AddDays(-7))).Select(e => e.Amount).Sum();
            decimal TravelSum = expenseDb.ExpenseReport.Where(e => e.Category == "Travel" && (e.ExpenseDate > DateTime.Now.AddDays(-7))).Select(e => e.Amount).Sum();
            decimal HealthSum = expenseDb.ExpenseReport.Where(e => e.Category == "Health" && (e.ExpenseDate > DateTime.Now.AddDays(-7))).Select(e => e.Amount).Sum();
            dictMonthlySum.Add("Food", FoodSum);
            dictMonthlySum.Add("Shopping", ShoppingSum);
            dictMonthlySum.Add("Travel", TravelSum);
            dictMonthlySum.Add("HealthSum", HealthSum);
            return dictMonthlySum;      
        }

        public Dictionary<string, decimal> CalculateMonthlyExpenses()
        {
            ExpensesDataAccessLayer objExpenses = new ExpensesDataAccessLayer();
            List<ExpenseReport> lstEmployee = new List<ExpenseReport>();

            Dictionary<string, decimal> dictMonthlySum = new Dictionary<string, decimal>();
            decimal FoodSum = expenseDb.ExpenseReport.Where(e => e.Category == "Food" && (e.ExpenseDate > DateTime.Now.AddDays(-30))).Select(e => e.Amount).Sum();
            decimal ShoppingSum = expenseDb.ExpenseReport.Where(e => e.Category == "Shopping" && (e.ExpenseDate > DateTime.Now.AddDays(-30))).Select(e => e.Amount).Sum();
            decimal TravelSum = expenseDb.ExpenseReport.Where(e => e.Category == "Travel" && (e.ExpenseDate > DateTime.Now.AddDays(-30))).Select(e => e.Amount).Sum();
            decimal HealthSum = expenseDb.ExpenseReport.Where(e => e.Category == "Health" && (e.ExpenseDate > DateTime.Now.AddDays(-30))).Select(e => e.Amount).Sum();
            dictMonthlySum.Add("Food", FoodSum);
            dictMonthlySum.Add("Shopping", ShoppingSum);
            dictMonthlySum.Add("Travel", TravelSum);
            dictMonthlySum.Add("HealthSum", HealthSum);
            return dictMonthlySum;
        }
    }
}
