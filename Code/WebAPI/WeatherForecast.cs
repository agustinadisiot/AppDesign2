using System;

<<<<<<< HEAD
namespace WebApi
=======
namespace WebAPI
>>>>>>> 5d59545... Adds web api first tests. Stage red
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
