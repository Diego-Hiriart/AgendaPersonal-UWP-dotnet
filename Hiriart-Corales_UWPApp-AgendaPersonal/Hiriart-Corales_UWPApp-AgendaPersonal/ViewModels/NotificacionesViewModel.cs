using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using Hiriart_Corales_UWPApp_AgendaPersonal.Core.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace Hiriart_Corales_UWPApp_AgendaPersonal.ViewModels
{
    public class NotificacionesViewModel : ObservableObject
    {
        public NotificacionesViewModel()
        {
        }

        public static ObservableCollection<Notificacion> ReadNotificaciones(string connectionString)//Metodo para recuperar datos
        {
            const string getNotifacionesQuery = "select Notifacions.NotificacionID, Notificacions.Titulo, Notificacions.Hora, Eventoes.Titulo from Notificacions " +
                "left join Eventoes on Eventoes.NotificacionID=Notificacions.NotificacionID";//Definicion de lo que queremos de Notificacion

            var notificaciones = new ObservableCollection<Notificacion>();//Coleccion de notificacion para almacenar las entradas de la tabla
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = getNotifacionesQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var notif = new Notificacion();//Una instancia de artistas para ir guardando y almacenando lo que se lea de la base
                                    notif.NotificacionID = reader.GetInt32(0);//El parametro dentro de estos gets indica la posicion del atributo dentro de la tabla
                                    //se usan castings con el reader[numeroColumna] para que los null se creen solos al leer
                                    notif.Titulo = reader[1] as string;
                                    notif.Hora = reader.GetDateTime(2);
                                    notif.Evento = reader[3] as string;
                                    notificaciones.Add(notif);//Aniade el memo que se creo antes a la coleccion
                                }
                            }
                        }
                    }
                }
                return notificaciones;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
            }
            return null;
        }

        public static bool CreateNotificacion(string connectionString, string titulo, DateTimeOffset tiempo, int evento)
        {
            DateTime horaNotif = tiempo.Date;
            try
            {
                const string crearNotificacion = "insert into Notificacions(Titulo, Hora) values(@titulo, @hora)";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = crearNotificacion;
                            cmd.Parameters.AddWithValue("@titulo", titulo);
                            cmd.Parameters.AddWithValue("@hora", horaNotif);
                            cmd.ExecuteNonQuery();

                            //Id de ultimo memo
                            List<int> notifIDs = new List<int>();//Para guardar memos leidos
                            const string memos = "select NotificacionID from Notificacions";
                            cmd.CommandText = memos;
                            using (SqlDataReader lector = cmd.ExecuteReader())
                            {
                                while (lector.Read())
                                {
                                    notifIDs.Add(lector.GetInt32(0));
                                }
                            }
                            int ultimaNotif = 0;
                            foreach (int id in notifIDs)
                            {
                                if (id > ultimaNotif)
                                {
                                    ultimaNotif = id;
                                }
                            }

                            //Cambiar Memo ID en Evento correcto
                            const string asociaNotif = "update Eventoes set NotificacionID=@idNotif where EventoID=@idEvento";
                            cmd.CommandText = asociaNotif;
                            cmd.Parameters.AddWithValue("@idNotif", ultimaNotif);
                            cmd.Parameters.AddWithValue("@idEvento", evento);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                return true;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
                return false;
            }
        }

        public static bool DeleteNotificacion(string connectionString, int notif)
        {
            const string borrarNotif = "delete from Notificacions where NotificacionID=@notif";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {
                        using (SqlCommand consola = conn.CreateCommand())
                        {
                            consola.CommandText = borrarNotif;
                            consola.Parameters.AddWithValue("@notif", notif);
                            consola.ExecuteNonQuery();

                            const string actualizaEvento = "update Eventoes set NotificacionID=NULL where NotificacionID=@id";
                            consola.CommandText = actualizaEvento;
                            consola.Parameters.AddWithValue("@id", notif);
                            consola.ExecuteNonQuery();
                        }
                    }
                }
                return true;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
                return false;
            }
        }

        public static bool UpdateNotificacion(string connectionString, int notif, string titulo, DateTimeOffset tiempo, int evento)
        {
            const string actualizar = "update Notificacions set Titulo=@titulo, Hora=@hora where NotificacionID=@id";
            DateTime horaNotif = tiempo.Date;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {
                        using (SqlCommand consola = conn.CreateCommand())
                        {
                            consola.CommandText = actualizar;
                            consola.Parameters.AddWithValue("@titulo", titulo);
                            consola.Parameters.AddWithValue("@hora", horaNotif);
                            consola.Parameters.AddWithValue("@id", notif);
                            consola.ExecuteNonQuery();

                            //Cambiar Memo ID en Evento correcto
                            const string asociaNotif = "update Eventoes set NotificacionID=@idNotif where EventoID=@idEvento";
                            consola.CommandText = asociaNotif;
                            consola.Parameters.AddWithValue("@idNotif", notif);
                            consola.Parameters.AddWithValue("@idEvento", evento);
                            consola.ExecuteNonQuery();
                        }
                    }
                }
                return true;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
                return false;
            }
        }
    }
}
