using TodoAppMaui.Views;

namespace TodoAppMaui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AddTodoPage), typeof(AddTodoPage));
            Routing.RegisterRoute(nameof(TodoPage), typeof(TodoPage));
        }
    }
}
