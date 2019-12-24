using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Classes;

namespace WeatherConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creación del sistema solar...");
            SolarSystem system;
            WeatherReport report;

            system = new SolarSystem(new List<Planet>()
            {
                new Planet(5000, Weather.Classes.Enum.CLOCKWISE, 1),
                new Planet(2000, Weather.Classes.Enum.CLOCKWISE, 3),
                new Planet(1000, Weather.Classes.Enum.COUNTER_CLOCKWISE, 5)
            });

            Console.WriteLine("Generar Pronostico...");

            report = WeatherReport.GenerateWeatherReport(system, 3650);

            Console.WriteLine("Pronostico generado con éxito...");

            try
            {
                Console.WriteLine("Subiendo datos a MongoDb...");

                var uploader = new ReportUploader(report);
                uploader.Upload();
                Console.WriteLine("Datos subidos a MongoDb Atlas exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Falla al subir datos a MongoDb Atlas. " + ex.Message);
            }
        }
    }
}
