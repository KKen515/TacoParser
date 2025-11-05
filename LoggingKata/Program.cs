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
            // Objective: Find the two Taco Bells that are the farthest apart from one another.

            logger.LogInfo("Log initialized");

            //Log an error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);

            if (lines.Length == 0)
            {
                logger.LogError("No lines found");
            }
            if (lines.Length == 1)
            {
                logger.LogWarning("There is only one line in the file");
            }

            // This will display the first item in lines array
            logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();
  
            // Objective: Complete the Parse method in TacoParser class first and then finalize nested loops to determine distance ----------
            
            ITrackable tacoBell1 = null;
            ITrackable tacoBell2 = null;
            
            double finalDistance = 0;
            var metersToMiles = 0.00062137;

            var tacoLocations = lines.Select(parser.Parse).ToArray();
            
            // NESTED LOOPS SECTION----------------------------

            for (int i = 0; i < tacoLocations.Length; i++)
            {
                var locA = tacoLocations[i];

                var corA = new GeoCoordinate();
                corA.Latitude = locA.Location.Latitude;
                corA.Longitude = locA.Location.Longitude;


                for (int tacoBell = 1; tacoBell < tacoLocations.Length; tacoBell++)
                {
                    var locB = tacoLocations[tacoBell];
                    var corB = new GeoCoordinate();
                    corB.Latitude = locB.Location.Latitude;
                    corB.Longitude = locB.Location.Longitude;

                    if (corA.GetDistanceTo(corB) > finalDistance)
                    {
                        finalDistance = corA.GetDistanceTo(corB);
                        tacoBell1 = locA;
                        tacoBell2 = locB;
                    }
                    
                }
                
            }

           
            //The two farthest Taco Bell locations and their distance in miles.

            Console.WriteLine($"The two farthest {tacoBell1.GetType().Name}'s are {tacoBell1.Name} and {tacoBell2.Name}");
            Console.WriteLine($"The total distance is {Math.Round((finalDistance * metersToMiles), 2)} miles.");



        }
        
    }
}
