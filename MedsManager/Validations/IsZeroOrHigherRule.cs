using System.Numerics;

namespace MedsManager.Validations;

public class IsZeroOrHigherRule<T> : IValidationRule<T> where T : INumber<T>
{
    public string ValidationMessage { get; set; }

    public bool Check(T value)
        => T.IsPositive(value);
}
