﻿using System.Collections.Generic;
using CashMachineApp.Controllers;
using CashMachineApp.Utils;

namespace CashMachineApp.Services
{
    public class CashMachineService : ICashMachineService
    {
        private int[] _availableNotes;

        public CashMachineService()
        {
            _availableNotes = new[] { 10,20,50,100 };

            // Make sure the available notes array is sorted desc 
            // to pick up the largest note possible first
            ArrayUtils.SortDesc(_availableNotes);
        }

        public int[] Withdraw(int amount)
        {
            var notes = this.FindBestNotesCombination(amount);
            return notes;
        }

        private int[] FindBestNotesCombination(int amount)
        {
            var result = new List<int>();
            var i = 0;
            
            while (amount != 0)
            {
                var currentNote = _availableNotes[i];
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
    }
}