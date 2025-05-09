namespace RegexSimpleBuilder.Tests;

// ReSharper disable once InconsistentNaming
public static class RegexRepeater_Testing
{
    public class Render(ITestOutputHelper output)
    {
        [Fact]
        public void When_NotAtLeastOneNotLazy_Then_ReturnsCorrectString()
        {
            // Arrange
            var data = new
                       {
                           Expected = @"*"
                       };

            var explicitRepeater         = new RegexRepeater(atLeastOne: false, isLazy: false);
            var implicitRepeater         = new RegexRepeater();
            var interfaceRepeater        = IRegexRepeater.NoneOrMore;
            var interfaceAtLeastRepeater = IRegexRepeater.AtLeast(0);

            // Action
            var renderExplicit = explicitRepeater.Render()
                                                 .ToString();
            var renderImplicit = implicitRepeater.Render()
                                                 .ToString();
            var renderInterface = interfaceRepeater.Render()
                                                   .ToString();
            var renderInterfaceAtLeast = interfaceAtLeastRepeater.Render()
                                                                 .ToString();
            output.WriteFormated("Explicit render",          renderExplicit);
            output.WriteFormated("Implicit render",          renderImplicit);
            output.WriteFormated("Interface render",         renderInterface);
            output.WriteFormated("Interface.AtLeast render", renderInterfaceAtLeast);

            // Assert
            renderExplicit.Should()
                          .Be(data.Expected);
            renderImplicit.Should()
                          .Be(data.Expected);
            renderInterface.Should()
                           .Be(data.Expected);
            renderInterfaceAtLeast.Should()
                                  .Be(data.Expected);
        }

        [Fact]
        public void When_AtLeastOneNotLazy_Then_ReturnsCorrectString()
        {
            // Arrange
            var data = new
                       {
                           Expected = @"+"
                       };

            var explicitRepeater         = new RegexRepeater(atLeastOne: true, isLazy: false);
            var implicitRepeater         = new RegexRepeater(atLeastOne: true);
            var interfaceRepeater        = IRegexRepeater.AtLeastOne;
            var interfaceAtLeastRepeater = IRegexRepeater.AtLeast(1);


            // Action
            var renderExplicit = explicitRepeater.Render()
                                                 .ToString();
            var renderImplicit = implicitRepeater.Render()
                                                 .ToString();
            var renderInterface = interfaceRepeater.Render()
                                                   .ToString();
            var renderInterfaceAtLeast = interfaceAtLeastRepeater.Render()
                                                                 .ToString();
            output.WriteFormated("Explicit render",          renderExplicit);
            output.WriteFormated("Implicit render",          renderImplicit);
            output.WriteFormated("Interface render",         renderInterface);
            output.WriteFormated("Interface.AtLeast render", renderInterfaceAtLeast);

            // Assert
            renderExplicit.Should()
                          .Be(data.Expected);
            renderImplicit.Should()
                          .Be(data.Expected);
            renderInterface.Should()
                           .Be(data.Expected);
            renderInterfaceAtLeast.Should()
                                  .Be(data.Expected);
        }

        [Fact]
        public void When_NotAtLeastOneLazy_Then_ReturnsCorrectString()
        {
            // Arrange
            var data = new
                       {
                           Expected = @"*?"
                       };

            var explicitRepeater  = new RegexRepeater(atLeastOne: false, isLazy: true);
            var implicitRepeater  = new RegexRepeater(isLazy: true);
            var interfaceRepeater = IRegexRepeater.NoneOrMoreLazy;


            // Action
            var renderExplicit = explicitRepeater.Render()
                                                 .ToString();
            var renderImplicit = implicitRepeater.Render()
                                                 .ToString();
            var renderInterface = interfaceRepeater.Render()
                                                   .ToString();
            output.WriteFormated("Explicit render",  renderExplicit);
            output.WriteFormated("Implicit render",  renderImplicit);
            output.WriteFormated("Interface render", renderInterface);

            // Assert
            renderExplicit.Should()
                          .Be(data.Expected);
            renderImplicit.Should()
                          .Be(data.Expected);
            renderInterface.Should()
                           .Be(data.Expected);
        }

        [Fact]
        public void When_AtLeastOneLazy_Then_ReturnsCorrectString()
        {
            // Arrange
            var data = new
                       {
                           Expected = @"+?"
                       };

            var repeater          = new RegexRepeater(atLeastOne: true, isLazy: true);
            var interfaceRepeater = IRegexRepeater.AtLeastOneLazy;

            // Action
            var render = repeater.Render()
                                 .ToString();
            var renderInterface = interfaceRepeater.Render()
                                                   .ToString();
            output.WriteFormated("Render",           render);
            output.WriteFormated("Interface render", renderInterface);

            // Assert
            render.Should()
                  .Be(data.Expected);
            renderInterface.Should()
                           .Be(data.Expected);
        }
    }
}