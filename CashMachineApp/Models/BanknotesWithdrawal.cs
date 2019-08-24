using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashMachineApp.Models
{
    public class BanknotesWithdrawal
    {
        public int[] Banknotes { get; set; }
        public string DisplayText { get; set; }

        public BanknotesWithdrawal(int[] banknotes, string displayText)
        {
            Banknotes = banknotes;
            DisplayText = displayText;
        }
    }
}
