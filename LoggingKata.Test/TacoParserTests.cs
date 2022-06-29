using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            var tacoParser = new TacoParser();

            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            Assert.NotNull(actual);
        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("34.035985, -84.683302, Taco Bell Acworth...", -84.683302)]
        [InlineData("30.903723, -84.556037, Taco Bell Bainbridg...", -84.556037)]
        [InlineData("30.731386, -86.566652, Taco Bell Crestvie...", -86.566652)]
        [InlineData("33.632727, -84.357866, Taco Bell Forest Par...", -84.357866)]
        [InlineData("34.342547, -86.307539, Taco Bell Guntersvill...", -86.307539)]
        public void ShouldParseLongitude(string line, double expected)
        {
            var tacoParser = new TacoParser();

            var actual = tacoParser.Parse(line);

            Assert.Equal(expected, actual.Location.Longitude);
        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        [InlineData("34.035985, -84.683302, Taco Bell Acworth...", 34.035985)]
        [InlineData("30.903723, -84.556037, Taco Bell Bainbridg...", 30.903723)]
        [InlineData("30.731386, -86.566652, Taco Bell Crestvie...", 30.731386)]
        [InlineData("33.632727, -84.357866, Taco Bell Forest Par...", 33.632727)]
        [InlineData("34.342547, -86.307539, Taco Bell Guntersvill...", 34.342547)]
        public void ShouldParseLatitude(string line, double expected)
        {
            var tacoParser = new TacoParser();

            var actual = tacoParser.Parse(line);

            Assert.Equal(expected, actual.Location.Latitude);
        }

    }
}
