using PlanMyMeal_Domain.ViewModels;

namespace PlanMyMeal_Domain;

public partial class SubscribePage : ContentPage
{
    private readonly SubscribreViewModel _subscribreViewModel;
    public SubscribePage(SubscribreViewModel model)
	{
		InitializeComponent();
        _subscribreViewModel = model;
        BindingContext = _subscribreViewModel;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _subscribreViewModel.ResetVisibility();
    }
}