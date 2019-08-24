using CashMachineApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CashMachineApp.Controllers
{
    [Route("/api/[controller]/[action]")]
    public class CashMachineController : Controller
    {
        private readonly ICashMachineService _cashMachineService;

        public CashMachineController(ICashMachineService cashMachineService)
        {
            _cashMachineService = cashMachineService;
        }

        // The requirement says the input values shoul be 30.00, 80.00 etc which suggests decimal type
        // But it doesn't make sense since we are working with banknotes only, hence using int for simplicity
        [HttpPost]
        public IActionResult Withdraw(int amount)
        {
            var notes = _cashMachineService.Withdraw(amount);
            return Ok(notes);
        }
    }
}