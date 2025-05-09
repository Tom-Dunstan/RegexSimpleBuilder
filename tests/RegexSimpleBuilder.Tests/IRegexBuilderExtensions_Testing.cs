using System.Text.RegularExpressions;

namespace RegexSimpleBuilder.Tests;

// ReSharper disable once InconsistentNaming
public static class IRegexBuilderExtensions_Testing
{
    public class Build(ITestOutputHelper output)
    {
        [Fact]
        public void When_CompiledOptionSet_Then_RenderedRegexShouldHaveOption()
        {
            // Arrange
            var data = new
                       {
                           Test     = @"This Is a Test.+*?^$()[]{}|\"
                         , Expected = @"This Is a Test\.\+\*\?\^\$\(\)\[\]\{\}\|\\"
                       };

            var builder = RegexBuilder.Create();

            // Action
            builder.AddElements(elements =>
                                {
                                    output.WriteFormated("Input Text", data.Test);
                                    elements.AddText(data.Test);
                                })
                   .SetCompiled();
            output.WriteLine($"Compiled option set");

            var result = builder.Build();
            output.WriteFormated("Compiled flag found", result.Options.HasFlag(RegexOptions.Compiled));

            // Assert
            result.Options.Should()
                  .HaveFlag(RegexOptions.Compiled);
        }
    }

    public class AddText(ITestOutputHelper output)
    {
        [Fact]
        public void When_MultipleElementsAreAdded_Then_RenderedAsExpected()
        {
            // Arrange
            var data = new
                       {
                           Text     = @"This Is a Test.+*?^$()[]{}|\"
                         , RawText  = @"This Is a Test.+*?^$()[]{}|\"
                         , Expected = @"This Is a Test\.\+\*\?\^\$\(\)\[\]\{\}\|\\This Is a Test.+*?^$()[]{}|\"
                       };

            var builder = RegexBuilder.Create();

            // Action
            builder.AddElements(elements =>
                                {
                                    output.WriteFormated("Adding Text", data.Text);
                                    elements.AddText(data.Text);

                                    output.WriteFormated("Adding Raw Text", data.RawText);
                                    elements.AddRawText(data.RawText);
                                });

            var result = builder.BuildString();

            output.WriteFormated("Rendered Text", result);

            // Assert
            result.Should()
                  .Be(data.Expected);
        }
    }

    public class AddGroup
    {
        [Fact]
        public void AddGroup_When_EmailRegex_Then_MatchesExpected()
        {
            // Arrange
            var data = new
                       {
                           Test = "person@domain.au"
                         , Expected = new
                                      {
                                          RegexString = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"
                                        , MatchResult = true
                                      }
                       };

            // Act
            var regexBuilder = RegexBuilder.Create()
                                           .AddElements(elements =>
                                                        {
                                                            elements.AddStartAnchor()
                                                                    .AddCharacterClass(@"\w-\.", IRegexRepeater.AtLeastOne)
                                                                    .AddText("@")
                                                                    .AddGroup(group =>
                                                                                  group.AddCharacterClass(@"\w-", repeater: IRegexRepeater.AtLeastOne)
                                                                                       .AddText(".")
                                                                            , repeater: IRegexRepeater.AtLeastOne)
                                                                    .AddCharacterClass(@"\w-", IRegexRepeater.Range(2, 4))
                                                                    .AddEndAnchor();

                                                        })
                                           .SetIgnoreCase()
                                           .SetCompiled();

            var regexString = regexBuilder.BuildString();
            var regex       = regexBuilder.Build();

            var match = regex.Match(data.Test);

            // Assert
            regexString.Should()
                       .Be(data.Expected.RegexString);

            match.Success
                 .Should()
                 .Be(data.Expected.MatchResult);

        }
    }
}
