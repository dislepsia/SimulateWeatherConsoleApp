using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Weather.Classes
{
    public class ReportUploader
    {
        WeatherReport report;

        public ReportUploader(WeatherReport report)
        {
            this.report = report;
            
        }

        public void Upload()
        {
            var client = new MongoClient("mongodb+srv://Angkor:Casares7735@cluster0-weh6k.gcp.mongodb.net/TestMeLi?retryWrites=true&w=majority");
            var db = client.GetDatabase("TestMeLi");

            //Subo el reporte
            var pronosticoLargoPlazo = db.GetCollection<WeatherReport>("Pronostico");
            var pronosticoDelDia = db.GetCollection<DayReport>("Days");

            //Delete all the register created
            pronosticoLargoPlazo.DeleteMany(doc => true);
            pronosticoDelDia.DeleteMany(doc => true);

            //Mapping fields
            InitMappings();

            pronosticoLargoPlazo.InsertOne(report);

            //Subo los dias
            //var pronosticoDelDia = db.GetCollection<DayReport>("Days");
            //pronosticoDelDia.DeleteMany(doc => true);
            //pronosticoDelDia.InsertMany(report.WeatherPerDay);
        }

        private void InitMappings()
        {
            BsonClassMap.RegisterClassMap<DayReport>(cm =>
            {
                cm.MapMember(c => c.Day);
                cm.MapMember(c => c.Weather);
            });

            BsonClassMap.RegisterClassMap<WeatherReport>(cm =>
            {
                cm.MapMember(c => c.DraughtDays);
                cm.MapMember(c => c.MaxIntensityDay);
                cm.MapMember(c => c.MaxRainIntensity);
                cm.MapMember(c => c.RainDays);
                cm.MapMember(c => c.OptimumDays);
                //cm.MapMember(c => c.WeatherPerDay);
            });

            BsonClassMap.RegisterClassMap<Weather>(cm =>
            {
                cm.MapMember(c => c.Type).SetSerializer(new EnumSerializer<Weather.WeatherType>(BsonType.Int32));
                cm.MapMember(c => c.RainIntensity);
            });
        }
    }
}
