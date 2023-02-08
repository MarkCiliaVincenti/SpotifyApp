using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SpotifyApp.Shared.Models;
using SpotifyApp.Shared.Services;

namespace SpotifyApp.Shared.ViewModels.Base;

public abstract partial class ImagePreviewViewModel<T> : ObservableRecipient where T: IItemWithImages
{
    private const int MaxImageWidth = 400;
    private readonly IImageCache _imageCache;
    
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(LoadPreviewCommand))]
    private T? _item;

    [ObservableProperty]
    private Bitmap? _preview;

    protected ImagePreviewViewModel(IImageCache imageCache)
    {
        _imageCache = imageCache;
    }
    
    partial void OnItemChanged(T? value)
    {
        if (value != null)
        {
            LoadPreviewCommand.ExecuteAsync(null);
        }
    }
    
    [RelayCommand(IncludeCancelCommand = true, CanExecute = nameof(LoadPreviewCanExecute))]
    private async Task LoadPreviewAsync(CancellationToken token)
    {
        var previewImage = Item?.Images.FirstOrDefault();
        if (previewImage != null)
        {
            var imagePath = await _imageCache.GetImage(previewImage.Url, token);

            await using (var fileStream = File.OpenRead(imagePath))
            {
                var width = previewImage.Width is null or >= MaxImageWidth ? MaxImageWidth : previewImage.Width.Value;
                Preview = await Task.Run(() => Bitmap.DecodeToWidth(fileStream, width), token);
            }
        }
    }

    private bool LoadPreviewCanExecute()
    {
        return Item != null;
    }
}