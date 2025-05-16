using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace IdeaManager.UI.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly IdeaListViewModel _ideaListViewModel;
        private readonly IdeaFormViewModel _ideaFormViewModel;

        [ObservableProperty]
        private ObservableObject currentViewModel;

        public ICommand ShowIdeaListCommand { get; }
        public ICommand ShowIdeaFormCommand { get; }

        public MainViewModel(IdeaListViewModel ideaListVM, IdeaFormViewModel ideaFormVM)
        {
            _ideaListViewModel = ideaListVM;
            _ideaFormViewModel = ideaFormVM;

            ShowIdeaListCommand = new RelayCommand(() => CurrentViewModel = _ideaListViewModel);
            ShowIdeaFormCommand = new RelayCommand(() => CurrentViewModel = _ideaFormViewModel);

            // Démarrage sur la liste des idées
            CurrentViewModel = _ideaListViewModel;
        }
    }
}
