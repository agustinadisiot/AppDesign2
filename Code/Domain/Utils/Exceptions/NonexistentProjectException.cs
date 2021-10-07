using System;

namespace Domain.Utils
{
    [Serializable]
    public class NonexistentProjectException : Exception
    {
        private string message;

        public override string Message
        {
            get { return message; }
        }

        public NonexistentProjectException()
        {
            this.message = "The project does not exist or could not be found";
        }
    }
}