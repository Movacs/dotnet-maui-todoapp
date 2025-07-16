using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TodoAppMaui.Models;
using TodoAppMaui.Services;
using TodoAppMaui.Views;

namespace TodoAppMaui.ViewModels
{
    public partial class TodoViewModel
    {
        public ObservableCollection<TodoItem> Todos { get; set; } = new ObservableCollection<TodoItem>();

        private readonly TodoApiService _todoApiService;

        public ICommand? DeleteTodoCommand { get; }

        public ICommand? NavigateAddTodoPageCommand { get; }

        public TodoViewModel(TodoApiService todoApiService)
        {
            DeleteTodoCommand = new AsyncRelayCommand<TodoItem>(DeleteTodoAsync);
            NavigateAddTodoPageCommand = new AsyncRelayCommand(NavigateAddTodoPage);
            _todoApiService = todoApiService;
        }
      
        public async Task LoadTodosAsync()
        {
            var todos = await _todoApiService.GetTodoItemsAsync();
            Todos.Clear();
            foreach (var todo in todos)
                Todos.Add(todo);
        }

        private async Task NavigateAddTodoPage()
        {

            await Shell.Current.GoToAsync(nameof(AddTodoPage));

        }
        private async Task DeleteTodoAsync(TodoItem todo)
        {
            if (todo == null)
                return;

            var success = await _todoApiService.DeleteTodoItemAsync(todo.Id);
            if (success)
                await LoadTodosAsync();
        }

    }
}
