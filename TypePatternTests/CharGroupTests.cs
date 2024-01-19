using TypePattern;
namespace TypePatternTests;

[TestFixture]
public class CharGroupTests
{
    private CharGroup? _letter;
    private CharGroup _number;
    
    [SetUp]
    public void Setup()
    {
        _letter = new CharGroup('a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n');
        _number = new CharGroup('1', '2', '3', '4', '5', '6', '7', '8', '9');
    }

    [Test]
    public void IsMatching_IfContainsMatchingChar_ReturnTrue()
    {
        var onlyLetterResults = _letter.IsMatching("cabdefim");
        var lettersAndNumberResults = _letter.IsMatching("3ab47");
        var letterAndSymbols = _letter.IsMatching("#7a");
        
        Assert.That(onlyLetterResults, Is.EqualTo(true));
        Assert.That(lettersAndNumberResults, Is.EqualTo(true));
        Assert.That(letterAndSymbols, Is.EqualTo(true));
    }
}