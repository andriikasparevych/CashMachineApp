using System;

namespace CashMachineApp.Exceptions
{
    public class NoteUnavailableException : Exception
    {
        public NoteUnavailableException(string message) : base(message)
        {
        }
    }
}