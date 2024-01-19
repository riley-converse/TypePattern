namespace TypePattern;

public interface ICharGroup
{
    bool IsMatching(string str);
    bool IsWildcard { get; }
    bool ContainsChar(char ch);
    CharGroup Wildcard();
}

public class CharGroup : ICharGroup
{
    private readonly char[] _values;
    public bool IsWildcard { get; private init; }

    public CharGroup(params char[] args)
    {
        _values = args;
    }

    public bool IsMatching(string str)
    {
        foreach (char ch in str)
        {
            if (ContainsChar(ch)) return true;
        }
        return false;
    }

    public bool ContainsChar(char ch)
    {
        return _values.Any(value => ch == value);
    }

    public CharGroup Wildcard()
    {
        var wild = new CharGroup()
        {
            IsWildcard = true
        };
        return wild;
    }
}