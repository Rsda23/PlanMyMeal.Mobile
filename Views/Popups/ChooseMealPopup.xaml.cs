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
            selectedCategories.Add("Entr�e");
        if (PlatCheckbox.IsChecked)
            selectedCategories.Add("Plat principal");
        if (DessertCheckbox.IsChecked)
            selectedCategories.Add("Dessert");

        Console.WriteLine($"Cat�gories s�lectionn�es : {string.Join(", ", selectedCategories)}");
    }

    private void Cancel(object sender, EventArgs e)
    {
        Close(null);
    }
}