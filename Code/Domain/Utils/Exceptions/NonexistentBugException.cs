using System;

namespace Domain.Utils
{
    public class NonexistentBugException : Exception
    {
        private string message;

        public override string Message
        {
            get { return message; }
        }

        public NonexistentBugException()
        {
            this.message = "The bug does not exist";
        }
    }
}