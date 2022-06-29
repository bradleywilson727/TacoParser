using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();

            var locations = lines.Select(parser.Parse).ToArray();

            ITrackable tacoBellA = null;
            ITrackable tacoBellB = null;

            double distance = 0;

            for (int i = 0; i < locations.Length; i++)
            {
                var locationA = locations[i];
                var corA = new GeoCoordinate(locationA.Location.Latitude, locationA.Location.Longitude);

                for (int j = 0; j < locations.Length; j++)
                {
                    var locationB = locations[j];
                    var corB = new GeoCoordinate(locationB.Location.Latitude, locationB.Location.Longitude);

                    double newDistance = corA.GetDistanceTo(corB);
                    if(newDistance > distance)
                    {
                        distance = newDistance;
                        tacoBellA = locationA;
                        tacoBellB = locationB;
                    }
                }
            }

            Console.WriteLine($"\n{tacoBellA.Name} is {Math.Round(distance * .00062, 2)} miles away from {tacoBellB.Name}.");
            //.GetDistance presents the distance in meters so the Math.Round formula converts the answer
            //to miles and rounds it to the second decimal point.
        }
    }
}
