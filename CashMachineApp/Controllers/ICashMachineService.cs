namespace CashMachineApp.Controllers
{
    public interface ICashMachineService
    {
        int[] Withdraw(int amount);
    }
}