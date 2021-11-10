using System;

namespace Domain.Utils
{
    public class NonexistentWorkException : Exception
    {
        private string message;

        public override string Message
        {
            get { return message; }
        }

        public NonexistentWorkException()
        {
            this.message = "The work does not exist or could not be found";
        }
    }
}