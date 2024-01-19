using Castle.Components.DictionaryAdapter;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using Moq;
using TypePattern;
namespace TypePatternTests;

[TestFixture]
public class PatternTests
{
    [Test]
    public void WaitFor_PatternIsNotEmpty_ThrowInvalidOperation()
    {
        var pattern = new Pattern()
            .Then(new CharGroup('a'));
        
        Assert.That(() => pattern.WaitFor(), Throws.InvalidOperationException);
    }
    
    [Test]
    public void WaitFor_CalledWithNullArgument_ReturnPatternThatStartsWithWildcard()
    {
        var pattern = new Pattern()
            .WaitFor();
        var results = pattern.ExtractAll();
        Assert.That(results[0].CharGroup.IsWildcard, Is.EqualTo(true));
    }

    [Test]
    [TestCase('a')]
    [TestCase('Z')]
    [TestCase('3')]
    public void Then_CallWithCharGroup_ReturnPatternWithCharGroup(char ch)
    {
        ICharGroup group = new CharGroup(ch);
        var pattern = new Pattern()
            .Then(group);
        var results = pattern.ExtractAll()[1].CharGroup;
        Assert.That(results.ContainsChar(ch));
        Assert.That(results, Is.EqualTo(group));
    }
}