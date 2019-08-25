using System.Collections.Generic;

namespace CashMachineApp.Services
{
    public interface ICashMachineStatusService
    {
        int[] GetAvailableBanknotes();
    }
}