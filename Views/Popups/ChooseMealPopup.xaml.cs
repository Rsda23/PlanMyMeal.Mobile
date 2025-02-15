using CommunityToolkit.Maui.Views;

namespace PlanMyMeal.Mobile;

public partial class ChooseMealPopup : Popup
{
	public ChooseMealPopup()
	{
		InitializeComponent();
	}
    private void Apply(object sender, EventArgs e)
    {
        var selectedCategories = new List<string>();

        if (EntreeCheckbox.IsChecked)
            selectedCategories.Add("Entrée");
        if (PlatCheckbox.IsChecked)
            selectedCategories.Add("Plat principal");
        if (DessertCheckbox.IsChecked)
            selectedCategories.Add("Dessert");

        Console.WriteLine($"Catégories sélectionnées : {string.Join(", ", selectedCategories)}");
    }

    private void Cancel(object sender, EventArgs e)
    {
        Close(null);
    }
}