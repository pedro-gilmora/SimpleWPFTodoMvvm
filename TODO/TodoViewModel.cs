using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace TODO;

public class TodoViewModel : INotifyPropertyChanged
{
    private string _newTodoDescription = "";

    public ObservableCollection<TodoItem> TodoItems { get; set; } = [];

    public string NewTodoDescription
    {
        get => _newTodoDescription;
        set
        {
            _newTodoDescription = value;
            OnPropertyChanged(nameof(NewTodoDescription));
            
        }
    }

    public ICommand AddTodoCommand { get; }
    public ICommand RemoveTodoCommand { get; }

    public TodoViewModel()
    {
        AddTodoCommand = new RelayCommand(AddTodo, CanAdd);
        RemoveTodoCommand = new RelayCommand<TodoItem>(RemoveTodo);
    }

    private bool CanAdd() => _newTodoDescription is not "";

    private void AddTodo()
    {
        TodoItem item = new() { Description = NewTodoDescription };
        TodoItems.Add(item);
        NewTodoDescription = string.Empty;
        ItemAdded?.Invoke(this, item);
    }

    private void RemoveTodo(TodoItem todo)
    {
        TodoItems.Remove(todo);
    }

    public event EventHandler<TodoItem>? ItemAdded;

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
