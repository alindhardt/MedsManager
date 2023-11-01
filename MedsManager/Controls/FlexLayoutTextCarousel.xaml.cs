using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Graphics.Text;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace MedsManager.Controls;

public partial class FlexLayoutTextCarousel : FlexLayout
{
	public FlexLayoutTextCarousel()
	{
		InitializeComponent();
    }


    public static readonly BindableProperty NextCommandProperty = BindableProperty.Create(
        nameof(NextCommand),
        typeof(Command),
        typeof(FlexLayoutTextCarousel));

    public Command NextCommand
    {
        get => (Command)GetValue(NextCommandProperty);
        set
        {
            SetValue(NextCommandProperty, value);
        }
    }

    public static readonly BindableProperty PreviousCommandProperty = BindableProperty.Create(
        nameof(PreviousCommand),
        typeof(Command),
        typeof(FlexLayoutTextCarousel));

    public Command PreviousCommand
    {
        get => (Command)GetValue(PreviousCommandProperty);
        set
        {
            SetValue(PreviousCommandProperty, value);
        }
    }

    #region Bindable property TextColor
    public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
        propertyName: nameof(TextColor),
        returnType: typeof(Color),
        declaringType: typeof(FlexLayoutTextCarousel),
        defaultBindingMode: BindingMode.OneWay);

    public Color TextColor
    {
        get => (Color)GetValue(TextColorProperty);
        set
        {
            SetValue(TextColorProperty, value);
        }
    }

    #endregion

    public static readonly BindableProperty TextProperty = BindableProperty.Create(
        nameof(Text),
        typeof(string),
        typeof(FlexLayoutTextCarousel));

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set
        {
            SetValue(TextProperty, value);
        }
    }
}