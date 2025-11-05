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
            logger.LogInfo("Begin parsing");

            var cells = line.Split(',');

            // Provide a log error if cells array is less than 3 lines
            if (cells.Length < 3)
            {
                logger.LogError("Invalid Array Length, has less than three lines.");
                return null; 
            }
            
            var lat = double.Parse(cells[0]);
            
            var lon = double.Parse(cells[1]);
            
            var tacoName = cells[2];
            

            var point = new Point();
            point.Latitude = lat;
            point.Longitude = lon;
            
            var tacoPoint = new TacoBell();
            tacoPoint.Name = tacoName;
            tacoPoint.Location = point;
            
            return tacoPoint;

        }
    }
}
