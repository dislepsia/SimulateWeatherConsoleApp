using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Weather.Classes
{
    public class WeatherReport
    {
        public int DroughtDays { get; }
        public int RainDays { get; }
        public double MaxRainIntensity { get; }
        public int MaxIntensityDay { get; }
        public int OptimumDays { get; }
        public List<DayReport> WeatherPerDay { get; }

        private WeatherReport(int droughtDays, int rainDays, double maxRainIntensity, int maxIntensityDay, int optimumDays, List<DayReport> weatherPerDay)
        {
            DroughtDays = droughtDays;
            RainDays = rainDays;
            MaxRainIntensity = Math.Round(maxRainIntensity, 2);
            MaxIntensityDay = maxIntensityDay;
            OptimumDays = optimumDays;
            WeatherPerDay = weatherPerDay;
        }

        public static WeatherReport GenerateWeatherReport(SolarSystem system, int daysToSimulate)
        {
            var weatherList = new List<DayReport>();
            int droughtCount = 0;
            int rainCount = 0;
            int optimumCount = 0;
            for (int day = 1; day <= daysToSimulate; day++)
            {
                system.SimulateDay();

                var weatherToday = system.CalculateWeather();
                switch (weatherToday.Type)
                {
                    case Weather.WeatherType.DROUGHT:
                        droughtCount++;
                        break;
                    case Weather.WeatherType.RAINY:
                        rainCount++;
                        break;
                    case Weather.WeatherType.OPTIMUM:
                        optimumCount++;
                        break;
                }

                weatherList.Add(new DayReport(weatherToday, day));
            }


            var maxRainIntensity = weatherList.Max(r => r.Weather.RainIntensity);
            var maxIntensityDay = weatherList.Where(r => r.Weather.RainIntensity == maxRainIntensity).First().Day;

            return new WeatherReport(droughtCount, rainCount, maxRainIntensity, maxIntensityDay, optimumCount, weatherList);
        }
    }
}