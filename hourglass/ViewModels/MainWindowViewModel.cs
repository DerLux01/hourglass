using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using hourglass.Models;
using hourglass.Services;
using hourglass.Views;

namespace hourglass.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly IMediaService _mediaService;
    private List<MediaItem> _allItems;

    [ObservableProperty]
    private ObservableCollection<MediaItem> _items;

    [ObservableProperty]
    private MediaType? _selectedMediaType;

    public List<MediaType> MediaTypes { get; } = Enum.GetValues<MediaType>().Cast<MediaType>().ToList();

    public MainWindowViewModel(IMediaService mediaService)
    {
        _mediaService = mediaService;
        LoadData();
    }

    private async void LoadData()
    {
        _allItems = await _mediaService.GetAllMediaItemsAsync();
        FilterItems();
    }

    partial void OnSelectedMediaTypeChanged(MediaType? value)
    {
        FilterItems();
    }

    private void FilterItems()
    {
        if (_allItems == null) return;

        var filtered = _selectedMediaType.HasValue
            ? _allItems.Where(x => x.Type == _selectedMediaType.Value)
            : _allItems;

        Items = new ObservableCollection<MediaItem>(filtered);
    }

    [RelayCommand]
    private async Task AddNewItem()
    {
        if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var window = new AddMediaItemWindow();
            var vm = new AddMediaItemViewModel(_mediaService, () => window.Close());
            window.DataContext = vm;
            
            await window.ShowDialog(desktop.MainWindow);
            
            LoadData();
        }
    }
}
