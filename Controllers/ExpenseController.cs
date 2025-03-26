using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        [HttpGet]
        [Route("api/expenses")]
        public IActionResult GetExpenses()
        {
            
        }

        [HttpGet("api/expenses/{id}")]
        public IActionResult GetExpense(int id)
        {

        }

        [HttpPost]
        public IActionResult CreateExpense()
        {
            return CreatedAtAction(nameof(GetExpenses()), new object());
        }

        [HttpPut("api/expenses/{id}")]
        public IActionResult UpdateExpense(int id)
        {

        }

        [HttpDelete("api/expenses/{id}")]
        public IActionResult DeleteExpense(int id)
        {

        }
    }
}
