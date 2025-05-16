using System.Windows;
using IdeaManager.UI.Views;

namespace IdeaManager.UI
{
    public partial class MainWindow : Window
    {
        private readonly IdeaListView _ideaListView = new();
        private readonly IdeaFormView _ideaFormView = new();

        public MainWindow()
        {
            InitializeComponent();
            ContentArea.Content = _ideaListView; // Afficher IdeaListView par défaut
        }

        private void ShowIdeaList_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = _ideaListView;
        }

        private void ShowIdeaForm_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = _ideaFormView;
        }
    }
}
