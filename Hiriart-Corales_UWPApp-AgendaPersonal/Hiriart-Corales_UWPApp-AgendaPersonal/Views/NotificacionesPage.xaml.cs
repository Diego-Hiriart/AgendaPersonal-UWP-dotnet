using System;

using Hiriart_Corales_UWPApp_AgendaPersonal.ViewModels;

using Windows.UI.Xaml.Controls;

namespace Hiriart_Corales_UWPApp_AgendaPersonal.Views
{
    public sealed partial class NotificacionesPage : Page
    {
        public NotificacionesViewModel ViewModel { get; } = new NotificacionesViewModel();

        public NotificacionesPage()
        {
            InitializeComponent();
        }
    }
}
