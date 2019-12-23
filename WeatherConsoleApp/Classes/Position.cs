using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherService.Classes;

namespace Weather.Classes
{
    public class Position
    {
        public PolarCoordinates polarPosition;

        public Position()
        {
            polarPosition = new PolarCoordinates();
            polarPosition.Angle = 0;
            polarPosition.Length = 0;
        }
    }
}