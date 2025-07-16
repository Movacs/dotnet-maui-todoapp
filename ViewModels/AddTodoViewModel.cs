using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TodoAppMaui.Models;
using TodoAppMaui.Services;
using TodoAppMaui.Views;

namespace TodoAppMaui.ViewModels
{
    public partial class AddTodoViewModel : ObservableObject
    {
        [ObservableProperty]
        private string title = string.Empty;

        private readonly TodoApiService _todoApiService;
        public ICommand? AddAsyncCommand { get; }

        public AddTodoViewModel(TodoApiService todoApiService)
        {
            _todoApiService = todoApiService;
            AddAsyncCommand = new AsyncRelayCommand(AddAsync);
        }

        public async Task AddAsync()
        {
            await _todoApiService.CreateTodoItemAsync(new TodoItem { Title = title });
            await Shell.Current.GoToAsync(nameof(TodoPage));
        }
    }
}
