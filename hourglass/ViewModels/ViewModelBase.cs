using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using hourglass.Models;

namespace hourglass.ViewModels;

public abstract partial class ViewModelBase : ObservableObject
{
    [ObservableProperty] private ObservableCollection<MediaItem>? _filteredItems;

    [ObservableProperty] private MediaStatus _selectedFilter = MediaStatus.InProgress;
    
}