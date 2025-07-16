using TodoAppMaui.ViewModels;

namespace TodoAppMaui.Views;

public partial class AddTodoPage : ContentPage
{
	private AddTodoViewModel _viewModel;
	public AddTodoPage(AddTodoViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		_viewModel = viewModel;
	}

}