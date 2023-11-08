using MedsManager.Models;
using System.Windows.Input;

namespace MedsManager.Controls;

public partial class GridWithEntryAndFontAwesomeIcon : Grid
{
	public GridWithEntryAndFontAwesomeIcon()
	{
		InitializeComponent();
	}

    public static readonly BindableProperty ErrorLabelTextProperty = BindableProperty.Create(
nameof(ErrorLabelText),
typeof(string),
typeof(GridWithEntryAndFontAwesomeIcon));

    public string ErrorLabelText
    {
        get => (string)GetValue(ErrorLabelTextProperty);
        set
        {
            SetValue(ErrorLabelTextProperty, value);
        }
    }

    public static readonly BindableProperty EntryFontSizeProperty = BindableProperty.Create(
nameof(EntryFontSize),
typeof(double),
typeof(GridWithEntryAndFontAwesomeIcon));

    [System.ComponentModel.TypeConverter(typeof(FontSizeConverter))]
    public double EntryFontSize
    {
        get => (double)GetValue(EntryFontSizeProperty);
        set
        {
            SetValue(EntryFontSizeProperty, value);
        }
    }

    public static readonly BindableProperty EntryKeyboardProperty = BindableProperty.Create(
nameof(EntryKeyboard),
typeof(Keyboard),
typeof(GridWithEntryAndFontAwesomeIcon));

    [System.ComponentModel.TypeConverter(typeof(Microsoft.Maui.Converters.KeyboardTypeConverter))]
    public Keyboard EntryKeyboard
    {
        get => (Keyboard)GetValue(EntryKeyboardProperty);
        set => SetValue(EntryKeyboardProperty, value);
    }

    public static readonly BindableProperty EntryPlaceholderProperty = BindableProperty.Create(
        nameof(EntryPlaceholder),
        typeof(string),
        typeof(GridWithEntryAndFontAwesomeIcon));

    public string EntryPlaceholder
    {
        get => (string)GetValue(EntryPlaceholderProperty);
        set
        {
            SetValue(EntryPlaceholderProperty, value);
        }
    }

    public static readonly BindableProperty EntryTextColorProperty = BindableProperty.Create(
nameof(EntryTextColor),
typeof(Color),
typeof(GridWithEntryAndFontAwesomeIcon));

    public Color EntryTextColor
    {
        get => (Color)GetValue(EntryTextColorProperty);
        set
        {
            SetValue(EntryTextColorProperty, value);
        }
    }

    public static readonly BindableProperty EntryTextChangedCommandProperty = BindableProperty.Create(
    nameof(EntryTextChangedCommand),
    typeof(ICommand),
    typeof(GridWithEntryAndFontAwesomeIcon));

    public ICommand EntryTextChangedCommand
    {
        get => (ICommand)GetValue(EntryTextChangedCommandProperty);
        set
        {
            SetValue(EntryTextChangedCommandProperty, value);
        }
    }

    public static readonly BindableProperty EntryTextProperty = BindableProperty.Create(
    nameof(EntryText),
    typeof(string),
    typeof(GridWithEntryAndFontAwesomeIcon),
    string.Empty,
    BindingMode.TwoWay);

    public string EntryText
    {
        get => (string)GetValue(EntryTextProperty);
        set
        {
            SetValue(EntryTextProperty, value);
        }
    }



    public static readonly BindableProperty FontAwesomeStyleProperty = BindableProperty.Create(
    nameof(FontAwesomeStyle),
    typeof(FontAwesomeStyle),
    typeof(GridWithEntryAndFontAwesomeIcon));

    public FontAwesomeStyle FontAwesomeStyle
    {
        get => (FontAwesomeStyle)GetValue(FontAwesomeStyleProperty);
        set
        {
            SetValue(FontAwesomeStyleProperty, value);
        }
    }

    public static readonly BindableProperty FontAwesomeIconProperty = BindableProperty.Create(
nameof(FontAwesomeIcon),
typeof(string),
typeof(GridWithEntryAndFontAwesomeIcon));

    public string FontAwesomeIcon
    {
        get => (string)GetValue(FontAwesomeIconProperty);
        set
        {
            SetValue(FontAwesomeIconProperty, value);
        }
    }
}