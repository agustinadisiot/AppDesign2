using System;

namespace BusinessLogicInterfaces
{
    public class ResponseMessage{
        public string responseMessage { get; set; }
        public ResponseMessage(string message)
        {
            responseMessage = message;
        }
    }
}