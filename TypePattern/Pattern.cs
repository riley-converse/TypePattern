using System.Reflection.Metadata.Ecma335;

namespace TypePattern;

public class Pattern
{
    private CharGroupLogic[]? _groupValues;

    public Pattern WaitFor(ICharGroup? cg = null)
    {
        if (_groupValues != null)
        {
            throw new InvalidOperationException("Method can only be called on first chain.");
        }
        var clone = GetCloneOfThis();
        cg ??= new CharGroup().Wildcard();
        clone._groupValues = [new CharGroupLogic(cg)];
        return clone;
    }

    public Pattern Then(ICharGroup cg)
    {
        var clone = GetCloneOfThis();
        clone.PushValue(cg);
        return clone;
    }

    public Pattern ThenTry(ICharGroup cg)
    {
        var clone = GetCloneOfThis();
        clone.PushValue(cg, false);
        return clone;
    }

    private Pattern GetCloneOfThis()
    {
        var clone = new Pattern
        {
            _groupValues = _groupValues,
        };
        return clone;
    }

    private void PushValue(ICharGroup cg, bool isRequired = true)
    {
        var cgl = new CharGroupLogic(cg, isRequired);
        if (_groupValues == null)
        {
            var wildcardLogic = new CharGroupLogic(new CharGroup().Wildcard());
            _groupValues = new[] { wildcardLogic, cgl };
            return;
        }
        
        var size = _groupValues.Length + 1;
        var temp = _groupValues;
        temp[size - 1] = cgl;
        _groupValues = temp;
    }

    public CharGroupLogic[] ExtractAll()
    {
        if (_groupValues != null)
        {
            return _groupValues;
        }
        throw new NullReferenceException("Pattern contains no logic to extract.");
    }
    public record CharGroupLogic(ICharGroup CharGroup, bool RequiredForMatch=true,  
                                    bool IsTextExcluded=false);
}