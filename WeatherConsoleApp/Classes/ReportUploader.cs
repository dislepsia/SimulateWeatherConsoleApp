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
            InitMappings();
        }

        public ReportUploader()
        {

        }

        private void InitMappings()
        {
            BsonClassMap.RegisterClassMap<WeatherReport>(cm =>
            {
                cm.MapMember(c => c.DraughtDays);
                cm.MapMember(c => c.MaxIntensityDay);
                cm.MapMember(c => c.MaxRainIntensity);
                cm.MapMember(c => c.RainDays);
                cm.MapMember(c => c.OptimumDays);
                cm.MapMember(c => c.WeatherPerDay);
            });

            BsonClassMap.RegisterClassMap<DayReport>(cm =>
            {
                cm.MapMember(c => c.Day);
                cm.MapMember(c => c.Weather);
            });

            BsonClassMap.RegisterClassMap<Weather>(cm =>
            {
                cm.MapMember(c => c.Type).SetSerializer(new EnumSerializer<Weather.WeatherType>(BsonType.Int32));
                cm.MapMember(c => c.RainIntensity);
            });
        }

        public void Upload()
        {
            var client = new MongoClient("mongodb+srv://Angkor:Casares7735@cluster0-weh6k.gcp.mongodb.net/TestMeLi?retryWrites=true&w=majority");
            var db = client.GetDatabase("TestMeLi");

            var pronostico = db.GetCollection<WeatherReport>("Pronostico");
            pronostico.DeleteMany(doc => true);
            pronostico.InsertOne(report);
        }

        public void Delete()
        {
            var client = new MongoClient("mongodb+srv://Angkor:Casares7735@cluster0-weh6k.gcp.mongodb.net/TestMeLi?retryWrites=true&w=majority");
            var db = client.GetDatabase("TestMeLi");

            var pronostico = db.GetCollection<WeatherReport>("Pronostico");
            pronostico.DeleteMany(doc => true);
            //pronostico.InsertOne(report);
        }
    }
}
