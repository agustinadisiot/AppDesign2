using System;

namespace BusinessLogic
{
    public class NonexistentUserException : Exception
    {
        private string message;

        public override string Message
        {
            get { return message; }
        }

        public NonexistentUserException()
        {
            this.message = "The user does not exist or could not be found";
        }
    }
}