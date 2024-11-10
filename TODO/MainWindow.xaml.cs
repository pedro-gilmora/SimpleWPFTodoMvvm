using System.Windows;

namespace TODO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetResourceReference(Window.StyleProperty, typeof(Window));
        }

        private void TodoViewModel_ItemAdded(object sender, TodoItem e) => desc.Focus();
    }
}