using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using hourglass.Models;
using hourglass.Services;

namespace hourglass.ViewModels;

public partial class AddMediaItemViewModel(IMediaService mediaService, Action onClose) : ViewModelBase
{
    [ObservableProperty] private string _title = string.Empty;
    [ObservableProperty] private MediaType _selectedType = MediaType.Movie;
    [ObservableProperty] private MediaStatus _selectedStatus = MediaStatus.Planned;
    [ObservableProperty] private int _totalDurationOrPages;

    public List<MediaType> MediaTypes { get; } = Enum.GetValues<MediaType>().ToList();
    public List<MediaStatus> MediaStatuses { get; } = Enum.GetValues<MediaStatus>().ToList();

    [RelayCommand]
    private async Task Save()
    {
        if (string.IsNullOrWhiteSpace(Title)) return;

        var newItem = new MediaItem
        {
            Title = Title,
            Type = SelectedType,
            Status = SelectedStatus,
            TotalDurationOrPages = TotalDurationOrPages,
            CreatedAt = DateTime.Now,
        };

        await mediaService.AddItemAsync(newItem);
        onClose?.Invoke();
    }

    [RelayCommand]
    private void Cancel()
    {
        onClose?.Invoke();
    }
}