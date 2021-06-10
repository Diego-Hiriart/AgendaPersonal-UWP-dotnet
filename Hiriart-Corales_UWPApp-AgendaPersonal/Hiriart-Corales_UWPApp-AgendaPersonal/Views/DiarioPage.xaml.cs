using System;

using Hiriart_Corales_UWPApp_AgendaPersonal.ViewModels;

using Windows.UI.Xaml.Controls;
using static Hiriart_Corales_UWPApp_AgendaPersonal.ViewModels.DiarioViewModel;

namespace Hiriart_Corales_UWPApp_AgendaPersonal.Views
{
    public sealed partial class DiarioPage : Page
    {
        public DiarioViewModel ViewModel { get; } = new DiarioViewModel();

        public DiarioPage()
        {
            InitializeComponent();
            DiariosList.ItemsSource = GetDiarios((App.Current as App).ConnectionString);
        }
    }
}
