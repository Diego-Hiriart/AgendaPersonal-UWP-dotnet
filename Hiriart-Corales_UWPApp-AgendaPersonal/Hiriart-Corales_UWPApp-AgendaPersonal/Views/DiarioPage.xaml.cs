using System;

using Hiriart_Corales_UWPApp_AgendaPersonal.ViewModels;

using Windows.UI.Xaml.Controls;

namespace Hiriart_Corales_UWPApp_AgendaPersonal.Views
{
    public sealed partial class DiarioPage : Page
    {
        public DiarioViewModel ViewModel { get; } = new DiarioViewModel();

        public DiarioPage()
        {
            InitializeComponent();
        }
    }
}
