using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Weather.Classes;

namespace WeatherConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SolarSystem system;
            WeatherReport report;

            Console.WriteLine("Bienvenido a WeatherConsoleApp!");
            Console.WriteLine("Ingrese la accion a realizar:");
            Console.WriteLine("1-Carga de datos a la base de datos Mongo Atlas");
            Console.WriteLine("2-Eliminar datos");

            ConsoleKeyInfo opcion = Console.ReadKey(true);

            if (opcion.Key == ConsoleKey.NumPad1 || opcion.Key == ConsoleKey.D1)
            {
                Console.WriteLine("---Opcion elegida: 1---");

                Console.WriteLine("Creación del sistema solar...");

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
            else if (opcion.Key == ConsoleKey.NumPad2 || opcion.Key == ConsoleKey.D2)
            {
                Console.WriteLine("Opcion elegida: 2");
                try
                {
                    Console.WriteLine("Eliminando datos de MongoDb...");
                    var uploader = new ReportUploader();
                    uploader.Delete();
                    Console.WriteLine("Datos eliminados de MongoDb Atlas exitosamente.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Falla al eliminar datos de MongoDb Atlas. " + ex.Message);
                }
            }
            else 
            {
                Console.WriteLine("---Opcion no valida...Adios!---");
            }

            Thread.Sleep(2000); 
        }
    }
}
