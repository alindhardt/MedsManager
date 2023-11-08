using CommunityToolkit.Mvvm.ComponentModel;

namespace MedsManager.Validations;

public partial class ValidatableObject<T> : ObservableObject
{
    [ObservableProperty, NotifyPropertyChangedFor(nameof(FirstErrorMessage))]
    IEnumerable<string> errors = Enumerable.Empty<string>();

    [ObservableProperty]
    bool isValid = true;

    [ObservableProperty]
    T value;

    public string FirstErrorMessage => Errors.FirstOrDefault() ?? "";

    public List<IValidationRule<T>> Validations { get; } = new();

    public ValidatableObject()
    {
    }
    public bool Validate()
    {
        Errors = Validations
            ?.Where(v => !v.Check(Value))
            ?.Select(v => v.ValidationMessage)
            ?.ToArray()
            ?? Enumerable.Empty<string>();
        IsValid = !Errors.Any();
        return IsValid;
    }
}