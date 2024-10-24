using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using StorySuite.ViewModels;

namespace StorySuite.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnClosing(WindowClosingEventArgs e)
        {
            if (e.CloseReason == WindowCloseReason.WindowClosing)
            {
                //var context = DataContext as MainWindowViewModel;
                //if (context != null)
                //{
                //    var result = MessageBox
                //}
            }
            base.OnClosing(e);
        }

        private void Binding(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
        }
    }
}