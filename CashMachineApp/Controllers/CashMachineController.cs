using Microsoft.AspNetCore.Mvc;

namespace CashMachineApp.Controllers
{
    [Route("/api/[controller]/[action]")]
    public class CashMachineController : ControllerBase
    {
        private readonly ICashMachineService _cashMachineService;

        public CashMachineController(ICashMachineService cashMachineService)
        {
            _cashMachineService = cashMachineService;
        }

        [HttpPost]
        public int[] Withdraw(int amount)
        {
            return _cashMachineService.Withdraw(amount);
        }
    }
}