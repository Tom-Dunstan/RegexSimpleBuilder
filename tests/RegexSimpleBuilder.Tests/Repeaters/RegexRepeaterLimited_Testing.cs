namespace RegexSimpleBuilder.Tests;

// ReSharper disable once InconsistentNaming
public static class RegexRepeaterLimited_Testing
{
    public class Render(ITestOutputHelper output)
    {
        [Fact]
        public void When_Exactly2_Then_ReturnsCorrectly()
        {
            // Arrange
            var data = new
                       {
                           Minimum  = (uint)2
                         , Maximum  = (uint)2
                         , Expected = "{2}"
                       };

            var limitedRepeater   = new RegexRepeaterLimited(data.Minimum);
            var sameRepeater      = new RegexRepeaterLimited(data.Minimum, data.Maximum);
            var exactRepeater     = new RegexRepeaterExact(data.Minimum);
            var interfaceRepeater = IRegexRepeater.Exact(data.Minimum);
            var rangeRepeater     = IRegexRepeater.Range(data.Minimum, data.Minimum);

            // Action
            var renderLimited = limitedRepeater.Render()
                                               .ToString();
            var renderSame = sameRepeater.Render()
                                         .ToString();
            var renderExact = exactRepeater.Render()
                                           .ToString();
            var renderInterface = interfaceRepeater.Render()
                                                   .ToString();
            var renderRange = rangeRepeater.Render()
                                           .ToString();
            output.WriteFormated("Limited render",     renderLimited);
            output.WriteFormated("Same Values render", renderSame);
            output.WriteFormated("Exact render",       renderExact);
            output.WriteFormated("Interface render",   renderInterface);
            output.WriteFormated("Range render",       renderRange);

            // Assert
            renderLimited.Should()
                         .Be(data.Expected);
            renderSame.Should()
                      .Be(data.Expected);
            renderExact.Should()
                       .Be(data.Expected);
            renderInterface.Should()
                           .Be(data.Expected);
            renderRange.Should()
                       .Be(data.Expected);
        }

        [Fact]
        public void When_Optional_Then_ReturnsCorrectly()
        {
            // Arrange
            var data = new
                       {
                           Minimum  = (uint)0
                         , Maximum  = (uint)1
                         , Expected = "?"
                       };

            var limitedRepeater  = new RegexRepeaterLimited(data.Minimum, data.Maximum);
            var optionalRepeater = new RegexOptional();
            var rangeRepeater    = IRegexRepeater.Range(data.Minimum, data.Maximum);

            // Action
            var renderLimited = limitedRepeater.Render()
                                               .ToString();
            var renderOptional = optionalRepeater.Render()
                                                 .ToString();
            var renderRange = rangeRepeater.Render()
                                           .ToString();
            output.WriteFormated("Limited render",  renderLimited);
            output.WriteFormated("Optional render", renderOptional);
            output.WriteFormated("Range render",    renderRange);

            // Assert
            renderLimited.Should()
                         .Be(data.Expected);
            renderOptional.Should()
                          .Be(data.Expected);
            renderRange.Should()
                       .Be(data.Expected);
        }

        [Fact]
        public void When_Range_Then_ReturnsCorrectly()
        {
            // Arrange
            var data = new
                       {
                           Minimum  = (uint)3
                         , Maximum  = (uint)7
                         , Expected = "{3,7}"
                       };

            var limitedRepeater = new RegexRepeaterLimited(data.Minimum, data.Maximum);
            var rangeRepeater   = IRegexRepeater.Range(data.Minimum, data.Maximum);

            // Action
            var renderLimited = limitedRepeater.Render()
                                               .ToString();
            var renderRange = rangeRepeater.Render()
                                           .ToString();
            output.WriteFormated("Limited render", renderLimited);
            output.WriteFormated("Range render",   renderRange);

            // Assert
            renderLimited.Should()
                         .Be(data.Expected);
            renderRange.Should()
                       .Be(data.Expected);
        }

        [Fact]
        public void When_RangeIsInvalid_Then_ExceptionIsThrown()
        {
            // Arrange
            var data = new
                       {
                           Minimum = (uint)7
                         , Maximum = (uint)3
                       };


            // Action
            // Assert
            try
            {
                _ = new RegexRepeaterLimited(data.Minimum, data.Maximum);
                Assert.Fail("No exception was thrown for call to RegexRepeaterLimited ctor");
            }
            catch (InvalidMinMaxValueException e)
            {
                output.WriteFormated("Exception thrown for", "RegexRepeaterLimited ctor");
                output.WriteFormated("Exception Message",    e.Message);
            }
            catch
            {
                Assert.Fail("Incorrect exception thrown for RegexRepeaterLimited ctor");
                throw;
            }

            try
            {
                _ = IRegexRepeater.Range(data.Minimum, data.Maximum);
                Assert.Fail("No exception was thrown for call to IRegexRepeater.Range");
            }
            catch (InvalidMinMaxValueException e)
            {
                output.WriteFormated("Exception thrown for", "IRegexRepeater.Range");
                output.WriteFormated("Exception Message",    e.Message);
            }
            catch
            {
                Assert.Fail("Incorrect exception thrown for IRegexRepeater.Range");
                throw;
            }

        }

        [Fact]
        public void When_RangeNoMax_Then_ReturnsCorrectly()
        {
            // Arrange
            var data = new
                       {
                           Minimum      = (uint)3
                         , UnlimitedMax = true
                         , Expected     = "{3,}"
                       };

            var limitedRepeater = new RegexRepeaterLimited(data.Minimum, data.UnlimitedMax);
            var rangeRepeater   = IRegexRepeater.AtLeast(data.Minimum);

            // Action
            var renderLimited = limitedRepeater.Render()
                                               .ToString();
            var renderRange = rangeRepeater.Render()
                                           .ToString();
            output.WriteFormated("Limited render", renderLimited);
            output.WriteFormated("Range render",   renderRange);

            // Assert
            renderLimited.Should()
                         .Be(data.Expected);
            renderRange.Should()
                       .Be(data.Expected);
        }
    }
}