using CommunityToolkit.Mvvm.Input;
using StorySuite.Models;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;

namespace StorySuite.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private StoryProject? project;

        public MainWindowViewModel()
        {
            NewCommand = new RelayCommand(new System.Action(CreateNewProject));
        }

        public ViewModelBase CurrentPage { get; } = new TestViewModel();
        public string Greeting => "Welcome to Avalonia!";
        public bool IsDirty { get; set; } = false;
        public bool IsProjectLoaded => Project != null;
        public RelayCommand NewCommand { get; }
        public ObservableCollection<ViewModelBase> Pages { get; } = new ObservableCollection<ViewModelBase>();

        public StoryProject? Project
        {
            get => project; private set
            {
                project = value;
                OnPropertyChanged(nameof(Project));
                OnPropertyChanged(nameof(ProjectName));
                OnPropertyChanged(nameof(IsProjectLoaded));
            }
        }

        public string? ProjectName => "StorySuite" + (Project == null ? null : " - " + Project?.Name);
        public int ToolbarButtonSize => 100;

        public void CreateNewProject()
        {
            if (IsDirty)
            {
            }

            this.Project = StoryProject.TryCreate("New Project");
            IsDirty = true;
        }
    }
}