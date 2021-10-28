using System;

namespace Domain
{
    public class Work
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Time { get; set; }
        public int Id { get; set; }

        public void Validate()
        {
            if(this.Name == null ||
                this.Time == 0 ||
                this.Cost == 0)
            {
                throw new ValidationException();
            }
        }
    }
}