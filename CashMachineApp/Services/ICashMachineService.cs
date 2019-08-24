using CashMachineApp.Models;

namespace CashMachineApp.Services
{
    public interface ICashMachineService
    {
        BanknotesWithdrawal Withdraw(int amount);
    }
}