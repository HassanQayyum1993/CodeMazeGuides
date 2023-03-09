﻿
namespace ActionAndFuncDelegatesInCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Delegates for print and sum functions examples
            var example = new Example();
            Action<string> printAction = new Action<string>(example.Print);
            printAction("Action and Func Delegates");

            Func<int, int, int> sumFunc = new Func<int, int, int>(example.Sum);
            Console.WriteLine(sumFunc(1, 2));

            //Delegates for weather application example
            string city = "New York";
            var weatherService = new WeatherService();

            Action<string> displayWeatherAction = (weatherData) =>
            {
                Console.WriteLine("Current weather in " + city + ": " + weatherData);
            };

            Func<string, string> formatWeatherFunc = (rawWeatherData) =>
            {
                string[] weatherParts = rawWeatherData.Split(new char[] { ',', ':' }, StringSplitOptions.RemoveEmptyEntries);
                var temperature = Convert.ToInt32(weatherParts[1].Trim());
                var humidity = Convert.ToInt32(weatherParts[3].Trim());

                return "Temperature: " + (temperature - 273) + "C, Humidity: " + humidity + "%";
            };

            weatherService.GetWeather(city, displayWeatherAction, formatWeatherFunc);
        }
    }
}