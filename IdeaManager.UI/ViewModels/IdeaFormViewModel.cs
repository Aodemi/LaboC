using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IdeaManager.Core.Entities;
using IdeaManager.Core.Interfaces;
using System;
using System.Threading.Tasks;

namespace IdeaManager.UI.ViewModels
{
    public partial class IdeaFormViewModel : ObservableObject
    {
        private readonly IIdeaService _ideaService;
        private readonly Action _onIdeaSubmitted;

        public IdeaFormViewModel(IIdeaService ideaService, Action onIdeaSubmitted)
        {
            _ideaService = ideaService;
            _onIdeaSubmitted = onIdeaSubmitted;
        }

        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private string description;

        [ObservableProperty]
        private string errorMessage;

        [RelayCommand]
        private async Task SubmitAsync()
        {
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(Title))
            {
                ErrorMessage = "Le titre est obligatoire.";
                return;
            }

            try
            {
                var idea = new Idea
                {
                    Title = Title,
                    Description = Description
                };

                await _ideaService.SubmitIdeaAsync(idea);

                // Reset formulaire
                Title = string.Empty;
                Description = string.Empty;

                _onIdeaSubmitted?.Invoke();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
