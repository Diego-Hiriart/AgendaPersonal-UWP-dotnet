using System;

using Hiriart_Corales_UWPApp_AgendaPersonal.ViewModels;

using Windows.UI.Xaml.Controls;

namespace Hiriart_Corales_UWPApp_AgendaPersonal.Views
{
    public sealed partial class MemosPage : Page
    {
        public MemosViewModel ViewModel { get; } = new MemosViewModel();

        public MemosPage()
        {
            InitializeComponent();
        }
    }
}
