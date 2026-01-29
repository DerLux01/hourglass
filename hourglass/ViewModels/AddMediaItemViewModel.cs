using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using hourglass.Models;
using hourglass.Models.Enums;
using hourglass.Models.InfoModels;
using hourglass.Models.ItemModels;
using hourglass.Services;

namespace hourglass.ViewModels;

public partial class AddMediaItemViewModel : ViewModelBase
{
    private readonly IMediaService _mediaService;
    private readonly Action _onClose;

    [ObservableProperty] private string _title = string.Empty;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsBookType))]
    private MediaType _selectedType = MediaType.Movie;

    [ObservableProperty] private MediaStatus _selectedStatus = MediaStatus.Planned;
    [ObservableProperty] private int _totalDurationOrPages;
    
    // Book specific properties
    [ObservableProperty] private int? _wordCount;
    [ObservableProperty] private int? _pageCount;

    public bool IsBookType => SelectedType is MediaType.Book or MediaType.LightNovel;

    public List<MediaType> MediaTypes { get; } = Enum.GetValues(typeof(MediaType)).Cast<MediaType>().ToList();
    public List<MediaStatus> MediaStatuses { get; } = Enum.GetValues(typeof(MediaStatus)).Cast<MediaStatus>().ToList();

    public AddMediaItemViewModel(IMediaService mediaService, Action onClose)
    {
        _mediaService = mediaService;
        _onClose = onClose;
    }

    [RelayCommand]
    private async Task Save()
    {
        if (string.IsNullOrWhiteSpace(Title)) return;

        MediaItem newItem;

        if (IsBookType)
        {
            newItem = new Book
            {
                WordCount = WordCount,
                PageCount = PageCount
            };
        }
        else
        {
            newItem = new Video();
        }

        // Set common properties
        newItem.Title = Title;
        newItem.Type = SelectedType;
        newItem.Status = SelectedStatus;
        newItem.TotalDurationOrPages = TotalDurationOrPages;
        newItem.CreatedAt = DateTime.Now;

        await _mediaService.AddItemAsync(newItem);
        _onClose?.Invoke();
    }

    [RelayCommand]
    private void Cancel()
    {
        _onClose?.Invoke();
    }
}