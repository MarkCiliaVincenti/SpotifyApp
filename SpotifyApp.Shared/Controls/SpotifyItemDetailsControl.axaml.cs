using Avalonia;
using Avalonia.Controls;
using SpotifyApp.Shared.ViewModels.Base;

namespace SpotifyApp.Shared.Controls;

public class SpotifyItemDetailsControl : ContentControl
{
    /// <summary>
    /// Defines the <see cref="Header"/> property.
    /// </summary>
    public static readonly StyledProperty<ISpotifyItemViewModel?> HeaderProperty =
        AvaloniaProperty.Register<SpotifyItemDetailsControl, ISpotifyItemViewModel?>(nameof(Header));
    
    /// <summary>
    /// Gets or sets the content of header to display.
    /// </summary>
    public ISpotifyItemViewModel? Header
    {
        get { return GetValue(HeaderProperty); }
        set { SetValue(HeaderProperty, value); }
    }
    
    /// <summary>
    /// Defines the <see cref="IsFullHeaderImageProperty"/> property.
    /// </summary>
    public static readonly StyledProperty<bool> IsFullHeaderImageProperty =
        AvaloniaProperty.Register<SpotifyItemDetailsControl, bool>(nameof(IsFullHeaderImage));
    
    /// <summary>
    /// Show image to full screen
    /// </summary>
    public bool IsFullHeaderImage
    {
        get { return GetValue(IsFullHeaderImageProperty); }
        set { SetValue(IsFullHeaderImageProperty, value); }
    }
}