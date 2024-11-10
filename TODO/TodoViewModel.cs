using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace TODO;

public class TodoViewModel : INotifyPropertyChanged
{
    private string _newTodoDescription = "";

    public ObservableCollection<TodoItem> TodoItems { get; set; } = [];

    public bool CanAddItem => _newTodoDescription.Trim() is not "";

    public string NewTodoDescription
    {
        get => _newTodoDescription;
        set
        {
            _newTodoDescription = value;
            OnPropertyChanged(nameof(CanAddItem));
            OnPropertyChanged(nameof(NewTodoDescription));
        }
    }

    public ICommand AddTodoCommand { get; }
    public ICommand RemoveTodoCommand { get; }

    public TodoViewModel()
    {
        AddTodoCommand = new RelayCommand(AddTodo);
        RemoveTodoCommand = new RelayCommand<TodoItem>(RemoveTodo);
    }

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
