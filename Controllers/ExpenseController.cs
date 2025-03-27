using ExpenseTrackerAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly ExpenseDbContext _context;

        public ExpenseController(ExpenseDbContext context)
        {
            _context = context; // dependancy injection done here
        }

        [HttpGet]
        [Route("api/expenses")]
        public IActionResult GetExpenses()
        {
            var expenses = _context.Expenses.ToList();

            if (expenses == null)
            {
                return NotFound();
            }

            return Ok(expenses);
        }

        [HttpGet("api/expenses/{id}")]
        public IActionResult GetExpense(int id)
        {
            var expenses = _context.Expenses.ToList();

            if (expenses == null)
            {
                return NotFound();
            }

            var expense = expenses.Find(x => x.Id == id);

            return Ok(expense);
        }

        [HttpPost]
        public IActionResult CreateExpense(Expense expense)
        {
            _context.Expenses.Add(expense);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetExpenses), new { id = expense.Id }, expense);
        }

        [HttpPut("api/expenses/{id}")]
        public IActionResult UpdateExpense(int id, Expense expense)
        {
            var existingExpense = _context.Expenses.FirstOrDefault(e => e.Id == id);

            if (existingExpense == null) 
            {
                return NotFound();
            }

            // Update properties of the existing expense
            existingExpense.Name = expense.Name;
            existingExpense.Description = expense.Description;
            existingExpense.Type = expense.Type;
            existingExpense.Price = expense.Price;

            // Save changes to the db
            _context.SaveChanges();

            return Ok(existingExpense);
        }

        [HttpDelete("api/expenses/{id}")]
        public IActionResult DeleteExpense(int id)
        {
            var expenses = _context.Expenses.ToList();

            if (expenses == null)
            {
                return NotFound();
            }

            var expense = expenses.Find(x => x.Id == id);

            if (expense == null)
            {
                return NotFound(expense);
            }

            _context.Expenses.Remove(expense);
            _context.SaveChanges();

            return Ok(expense);
        }
    }
}
