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

namespace TodoAppMaui.ViewModels
{
    public partial class TodoViewModel
    {
        public ObservableCollection<TodoItem> Todos { get; set; } = new ObservableCollection<TodoItem>();

        private readonly TodoApiService _todoApiService = new TodoApiService();

        public ICommand? DeleteTodoCommand { get; }

        public TodoViewModel()
        {
            DeleteTodoCommand = new RelayCommand<TodoItem>(DeleteTodoAsync);
        }
      
        public async Task LoadTodosAsync()
        {
            var todos = await _todoApiService.GetTodoItemsAsync();
            Todos.Clear();
            foreach (var todo in todos)
                Todos.Add(todo);
            //Todos.Add(new TodoItem { Id = 1, IsComplete = false, Title = "teszt"});
            //Todos.Add(new TodoItem { Id = 2, IsComplete = true, Title = "teszt2" });
        }

        
        private async void DeleteTodoAsync(TodoItem todo)
        {
            if (todo == null)
                return;

            var success = await _todoApiService.DeleteTodoItemAsync(todo.Id);
            if (success)
                await LoadTodosAsync();
        }

    }
}
