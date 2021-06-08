using System;

using Hiriart_Corales_UWPApp_AgendaPersonal.ViewModels;

using Windows.UI.Xaml.Controls;

namespace Hiriart_Corales_UWPApp_AgendaPersonal.Views
{
    public sealed partial class EventosPage : Page
    {
        public EventosViewModel ViewModel { get; } = new EventosViewModel();

        public EventosPage()
        {
            InitializeComponent();
        }
    }
}
