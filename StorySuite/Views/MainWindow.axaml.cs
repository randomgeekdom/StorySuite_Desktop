using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Primitives;
using Avalonia.Threading;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
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
            if (e.CloseReason == WindowCloseReason.WindowClosing && (this.DataContext as MainWindowViewModel).IsDirty)
            {
                e.Cancel = true;

                var result = MessageBoxManager.GetMessageBoxStandard("Save", "Would you like to save your project?", ButtonEnum.YesNoCancel);
                var task = result.ShowAsPopupAsync(this);

                task.ContinueWith(x =>
                {
                    switch (task.Result)
                    {
                        case ButtonResult.Yes:
                            break;

                        case ButtonResult.No:
                            break;

                        case ButtonResult.Cancel:
                            return;
                    }

                    Dispatcher.UIThread.Invoke(() =>
                    ((IClassicDesktopStyleApplicationLifetime)Application.Current.ApplicationLifetime).Shutdown());
                });
            }
        }
    }
}