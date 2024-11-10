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
        }

        private void TodoViewModel_ItemAdded(object sender, TodoItem e)
        {
            desc.Focus();
        }
    }
}