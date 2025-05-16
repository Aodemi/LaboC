using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Controls;

namespace IdeaManager.UI.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly UserControl _ideaListView;
        private readonly UserControl _ideaFormView;

        public MainViewModel(UserControl ideaListView, UserControl ideaFormView)
        {
            _ideaListView = ideaListView;
            _ideaFormView = ideaFormView;
            CurrentView = _ideaListView; // Vue par défaut
        }

        [ObservableProperty]
        private UserControl currentView;

        [RelayCommand]
        private void ShowIdeaList()
        {
            CurrentView = _ideaListView;
        }

        [RelayCommand]
        private void ShowIdeaForm()
        {
            CurrentView = _ideaFormView;
        }
    }
}
