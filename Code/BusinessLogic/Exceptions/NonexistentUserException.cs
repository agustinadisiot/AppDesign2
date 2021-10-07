using System;
using System.Runtime.Serialization;

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
            this.message = "The bug does not exist";
        }
    }
}