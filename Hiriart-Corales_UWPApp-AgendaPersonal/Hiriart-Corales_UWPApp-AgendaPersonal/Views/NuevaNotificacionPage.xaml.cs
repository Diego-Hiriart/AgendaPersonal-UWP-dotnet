using System;
using System.Collections.ObjectModel;
using Hiriart_Corales_UWPApp_AgendaPersonal.Core.Models;
using Hiriart_Corales_UWPApp_AgendaPersonal.ViewModels;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using static Hiriart_Corales_UWPApp_AgendaPersonal.ViewModels.NotificacionesViewModel;

namespace Hiriart_Corales_UWPApp_AgendaPersonal.Views
{
    public sealed partial class NuevaNotificacionPage : Page
    {
        ObservableCollection<Evento> Eventos = new ObservableCollection<Evento>();
        public NuevaNotificacionPage()
        {
            InitializeComponent();
        }

        private async void AyudaBoton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var ayuda = new MessageDialog("Utilice el simbolo de guardado para añadir una entrada \n" +
                "de dario, la flecha hacia la izquirda le permite volver a la pantalla principal de Notificaciones");
            ayuda.Title = "Información";
            await ayuda.ShowAsync();
        }

        private void VolverBoton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            //Llama a la vista DiarioPage
            this.Frame.Navigate(typeof(NotificacionesPage));
        }

        private async void GuardarBoton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (Validar())
            {
                Evento evento = (Evento)this.eventosListBox.SelectedItem;
                if (this.eventosListBox.SelectedItem == null)
                    evento = new Evento();

                bool exito = CreateNotificacion((App.Current as App).ConnectionString, this.tituloTextBox.Text, this.horaTimePicker.Time,
                    (DateTimeOffset)this.fechaCalendarDatePicker.Date, evento.EventoID);
                if (exito)
                {
                    //Resetear interfaz
                    this.fechaCalendarDatePicker.Date = null;
                    Eventos.Clear();
                    this.tituloTextBox.Text = "";
                    this.horaTimePicker.SelectedTime = null;
                }
                else
                {
                    var errorBase = new MessageDialog("Ha ocurrido un error con la base de datos, \nno se puede ingresar la notificación");
                    errorBase.Title = "Error";
                    await errorBase.ShowAsync();
                }
            }
            else
            {
                var faltanDatos = new MessageDialog("No se han ingresado todos los datos, intente \nde nuevo");
                faltanDatos.Title = "Error";
                await faltanDatos.ShowAsync();
            }
        }

        private bool Validar()
        {
            if (this.fechaCalendarDatePicker.Date!=null && !this.horaTimePicker.Time.Equals(null) && !String.IsNullOrEmpty(this.tituloTextBox.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void LeerEventos(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            if (this.fechaCalendarDatePicker.Date!=null)
            {
                this.eventosListBox.ItemsSource = EventosRelacionados((App.Current as App).ConnectionString, (DateTimeOffset)this.fechaCalendarDatePicker.Date);
            }
            
        }
    }
}
