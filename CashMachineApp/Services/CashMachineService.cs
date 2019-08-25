using System.Collections.Generic;
using CashMachineApp.Exceptions;
using CashMachineApp.Models;
using CashMachineApp.Utils;

namespace CashMachineApp.Services
{
    public class CashMachineService : ICashMachineService
    {
        private readonly ICashMachineStatusService _statusService;

        public CashMachineService(ICashMachineStatusService statusService)
        {
            _statusService = statusService;
        }

        public BanknotesWithdrawal Withdraw(int amount)
        {
            var availableNotes = _statusService.GetAvailableBanknotes();
            availableNotes.SortDesc();

            this.ValidateAmount(amount, availableNotes);
            var notes = this.FindBestNotesCombination(amount, availableNotes);

            return new BanknotesWithdrawal(notes, notes.ToDisplayString());
        }

        private int[] FindBestNotesCombination(int amount, int[] availableNotes)
        {
            var result = new List<int>();
            var i = 0;
            
            while (amount != 0)
            {
                var currentNote = availableNotes[i];
                if (currentNote <= amount)
                {
                    result.Add(currentNote);
                    amount -= currentNote;
                }
                else
                {
                    i++;
                }
            }

            return result.ToArray();
        }

        private void ValidateAmount(int amount, int[] availableNotes)
        {
            if (amount < 0)
            {
                throw new InvalidArgumentException("Please provide a valid amount");
            }

            var lowestValueNote = availableNotes[availableNotes.Length - 1];
            if (amount % lowestValueNote != 0)
            {
                throw new NoteUnavailableException($"Cannot withdraw this amount. Available notes are: {availableNotes.ToDisplayString()}");
            }
            
        }
    }
}