using System;

namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            TacoBell tacoBell = new TacoBell();

            logger.LogInfo("Begin parsing");

            var cells = line.Split(',');

            if (cells.Length < 3)
            {
                return null; 
            }

            var latitude = Double.Parse(cells[0]);
            var longitude = Double.Parse(cells[1]);
            var locationName = cells[2];

            tacoBell.Name = locationName;
            tacoBell.Location = new Point()
            {
                Longitude = longitude,
                Latitude = latitude
            };

            return tacoBell;
        }

        
    }
}