using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TodoAppMaui.Models;
using TodoAppMaui.Services;

namespace TodoAppMaui.ViewModels
{
    public class TodoViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<TodoItem> Todos { get; set; } = new ObservableCollection<TodoItem>();

        public ICommand DeleteCommand { get; }

        private readonly TodoApiService _todoApiService = new TodoApiService();

        public async Task LoadTodosAsync()
        {
            var todos = await _todoApiService.GetTodoItemsAsync();
            Todos.Clear();
            foreach (var todo in todos)
                Todos.Add(todo);
            //Todos.Add(new TodoItem { Id = 1, IsComplete = false, Title = "teszt"});
            //Todos.Add(new TodoItem { Id = 2, IsComplete = true, Title = "teszt2" });
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
