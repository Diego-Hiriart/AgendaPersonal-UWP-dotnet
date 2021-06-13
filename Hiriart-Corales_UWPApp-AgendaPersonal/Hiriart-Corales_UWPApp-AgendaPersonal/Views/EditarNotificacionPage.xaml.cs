﻿using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Hiriart_Corales_UWPApp_AgendaPersonal.Core.Models;
using Hiriart_Corales_UWPApp_AgendaPersonal.ViewModels;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using static Hiriart_Corales_UWPApp_AgendaPersonal.ViewModels.NotificacionesViewModel;

namespace Hiriart_Corales_UWPApp_AgendaPersonal.Views
{
    public sealed partial class EditarNotificacionPage : Page
    {

        ObservableCollection<Evento> Eventos = new ObservableCollection<Evento>();
        Notificacion seleccionadoNotificacionPage;//variable global para sacar datos del seleccionado originalmente, sobre todo para el ID para poder editar

        protected override void OnNavigatedTo(NavigationEventArgs e)//Metodo a usar en caso de pasar parametros durante la navegacion
        {
            if (!e.Parameter.Equals(null))//No continuar si es null, habrian errores
            {
                this.seleccionadoNotificacionPage = (Notificacion)e.Parameter;

                //Llenar los campos con los datos ya conocidos de la entrada seleccionada
                this.fechaCalendarDatePicker.Date = seleccionadoNotificacionPage.Hora.Date;
                this.eventosListBox.ItemsSource = EventosRelacionados((App.Current as App).ConnectionString, (DateTimeOffset)this.fechaCalendarDatePicker.Date);
                this.horaTimePicker.SelectedTime = seleccionadoNotificacionPage.Hora.TimeOfDay;
                this.tituloTextBox.Text = seleccionadoNotificacionPage.Titulo;
            }
            else//Volver a la pantalla principal si es null, quiere decir que no se selecciono nada
            {
                this.Frame.Navigate(typeof(NotificacionesPage));
            }
        }

        public EditarNotificacionPage()
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
            //Llama a la vista NotificionesPage
            this.Frame.Navigate(typeof(NotificacionesPage));
        }

        private async void GuardarBoton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (Validar())
            {
                Evento evento = (Evento)this.eventosListBox.SelectedItem;
                if (this.eventosListBox.SelectedItem == null)
                    evento = new Evento();

                bool exito = UpdateNotificacion((App.Current as App).ConnectionString, this.seleccionadoNotificacionPage.NotificacionID,
                    this.tituloTextBox.Text, this.horaTimePicker.Time, (DateTimeOffset)this.fechaCalendarDatePicker.Date, evento.EventoID);
                if (exito)
                {
                    var ingresoExito = new MessageDialog("Se ha editado la entrada, puede seguir editandola \n" +
                         "o volver a la pantalla principal de Notificaciones");
                    ingresoExito.Title = "Entrada editada correctamente";
                    await ingresoExito.ShowAsync();
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
