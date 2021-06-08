using System;

using Hiriart_Corales_UWPApp_AgendaPersonal.ViewModels;

using Windows.UI.Xaml.Controls;

namespace Hiriart_Corales_UWPApp_AgendaPersonal.Views
{
    public sealed partial class ContactosPage : Page
    {
        public ContactosViewModel ViewModel { get; } = new ContactosViewModel();

        public ContactosPage()
        {
            InitializeComponent();
        }
    }
}
