using CommunityToolkit.Mvvm.ComponentModel;
using IdeaManager.Core.Interfaces;
using System.Collections.ObjectModel;
using IdeaManager.Core.Entities;
using System.Threading.Tasks;

namespace IdeaManager.UI.ViewModels
{
    public partial class IdeaListViewModel : ObservableObject
    {
        private readonly IIdeaService _ideaService;

        public ObservableCollection<Idea> Ideas { get; } = new();

        public IdeaListViewModel(IIdeaService ideaService)
        {
            _ideaService = ideaService;
            LoadIdeas();
        }

        private async void LoadIdeas()
        {
            var ideas = await _ideaService.GetAllAsync();
            Ideas.Clear();
            foreach (var idea in ideas)
                Ideas.Add(idea);
        }
    }
}
