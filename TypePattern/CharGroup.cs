namespace TypePattern;

public class CharGroup
{           
    private readonly char[] _values;
    
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
}