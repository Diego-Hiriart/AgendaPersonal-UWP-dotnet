using System;

using Hiriart_Corales_UWPApp_AgendaPersonal.ViewModels;

using Windows.UI.Xaml.Controls;
using static Hiriart_Corales_UWPApp_AgendaPersonal.ViewModels.MemosViewModel;

namespace Hiriart_Corales_UWPApp_AgendaPersonal.Views
{
    public sealed partial class MemosPage : Page
    {
        public MemosViewModel ViewModel { get; } = new MemosViewModel();

        public MemosPage()
        {
            InitializeComponent();
            MemosList.ItemsSource = ReadMemos((App.Current as App).ConnectionString);
        }

        private void NuevoBoton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }

        private void EditarBoton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }

        private void EliminarBoton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }

        private void ActualizarBoton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }

        private void AyudaBoton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }
    }
}
