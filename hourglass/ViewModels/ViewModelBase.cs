using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using hourglass.Models;
using hourglass.Models.Enums;
using hourglass.Models.InfoModels;

namespace hourglass.ViewModels;

public abstract partial class ViewModelBase : ObservableObject
{
    [ObservableProperty] private ObservableCollection<MediaItem>? _filteredItems;

    [ObservableProperty] private MediaStatus _selectedFilter = MediaStatus.InProgress;
    
}