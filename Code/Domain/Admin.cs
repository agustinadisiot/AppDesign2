using System;

namespace Domain
{
    public class Admin : User
    {
        public Admin()
        {
        }

        public void Validate()
        {
            if(this.Username == null || 
                this.Lastname == null || 
                this.Password == null || 
                this.Name == null ||
                this.Email == null)
            {
                throw new ValidationException();
            }
        }
    }
}