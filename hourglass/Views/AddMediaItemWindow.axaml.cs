using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace hourglass.Views;

public partial class AddMediaItemWindow : Window
{
    public AddMediaItemWindow()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}