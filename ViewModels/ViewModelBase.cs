using CommunityToolkit.Mvvm.ComponentModel;

namespace PlanMyMeal_Domain.ViewModels
{
    public partial class ViewModelBase : ObservableObject
    {
        [ObservableProperty]
        private bool isRunning;
    }
}
