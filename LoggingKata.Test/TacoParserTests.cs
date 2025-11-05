using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldReturnNonNullObject()
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("34.996237,-85.291147,Taco Bell Chattanooga...", -85.291147)]
        [InlineData("33.958057,-84.133918,Taco Bell Duluth..." , -84.133918)]
        [InlineData("33.448592,-84.325086,Taco Bell Hampton...", -84.325086)]
        [InlineData("33.785605,-85.770014,Taco Bell Jacksonville...", -85.770014)]
        [InlineData("34.244093,-85.161119,Taco Bell Rome...", -85.161119)]
        [InlineData("32.609135,-85.479907,Taco Bell Auburn...", -85.479907)]
        [InlineData("34.8831,-84.293899,Taco Bell Blue Ridg...", -84.293899)]
        [InlineData("34.196869,-84.135598,Taco Bell Cumming...", -84.135598)]
        [InlineData("34.571839,-87.014351,Taco Bell Decatur...", -87.014351)]


        
        //Add additional inline data. Refer to your CSV file.
        public void ShouldParseLongitude(string line, double expected)
        {
            // TODO: Complete the test with Arrange, Act, Assert steps below.

            //Arrange
            
            var tacoParser = new TacoParser();

            //Act
            
            var actual = tacoParser.Parse(line).Location.Longitude;

            //Assert
            
            Assert.Equal(expected, actual);
        }

        
        [Theory]
        [InlineData("31.570771,-84.10353,Taco Bell Albany...",  31.570771)]
        [InlineData("32.072974,-84.222921,Taco Bell Americu...",  32.072974)]
        [InlineData("34.795116,-86.97191,Taco Bell Athens...",  34.795116)]
        [InlineData("33.470013,-86.816966,Taco Bell Birmingham...", 33.470013)]
        [InlineData("33.652223,-86.819279,Taco Bell Gardendal...",  33.652223)]
        [InlineData("33.24722,-84.273798,Taco Bell Griffi...", 33.24722)]
        [InlineData("33.692266,-84.091365,Taco Bell Lithonia...", 33.692266)]
        [InlineData("33.606589,-85.826812,Taco Bell Oxfor...",  33.606589)]
        [InlineData("33.569202,-84.540661,Taco Bell Union Cit...",  33.569202)]
        [InlineData("34.272015,-85.229599,Taco Bell Rome...", 34.272015)]


        public void ShouldParseLatitude(string line, double expected)
        {
            //Arrange
            
            var tacoParser = new TacoParser();
            
            //Act
            
            var actual = tacoParser.Parse(line).Location.Latitude;
            
            //Actual
            
            Assert.Equal(expected, actual);

        }
        

    }
}
