
using TodoAppMaui.ViewModels;

namespace TodoAppMaui.Views;

public partial class TodoPage : ContentPage
{
    private TodoViewModel _todoViewModel;
	public TodoPage(TodoViewModel todoViewModel)
	{
		InitializeComponent();
        BindingContext = todoViewModel;
        _todoViewModel = todoViewModel;
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _todoViewModel.LoadTodosAsync();
    }
    private async void OnGoToAddTodoPageClicked(object sender, EventArgs e)
	{
        try
        {
            await Shell.Current.GoToAsync("//AddTodoPage");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Hiba", ex.Message, "OK");
        }
    }
}