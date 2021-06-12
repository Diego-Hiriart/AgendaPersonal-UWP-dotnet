using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using Hiriart_Corales_UWPApp_AgendaPersonal.Core.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace Hiriart_Corales_UWPApp_AgendaPersonal.ViewModels
{
    public class EventosViewModel : ObservableObject
    {
        public EventosViewModel()
        {
        }

        public static ObservableCollection<Evento> ReadEventos(string connectionString)//Metodo para recuperar datos
        {
            const string GetEventosQuery = "select Eventoes.EventoID, Eventoes.Fecha, Eventoes.Inicio, Eventoes.Fin, " +//Definicion de lo que queremos de Evento
                "Eventoes.Titulo, Eventoes.Descripcion, Eventoes.Ubicacion, Eventoes.EsSerie, Eventoes.Dias, ListaContactoes.NombreApellido from Eventoes " +
                "left join ListaContactoes on ListaContactoes.IDEvento=Eventoes.EventoID";

            var eventos = new ObservableCollection<Evento>();//Coleccion de evento para almacenar las entradas de la tabla
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            
                            cmd.CommandText = GetEventosQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var evento = new Evento();//Una instancia de evento para ir guardando y almacenando lo que se lea de la base
                                    evento.EventoID = reader.GetInt32(0);//El parametro dentro de estos gets indica la posicion del atributo dentro de la tabla                                  
                                    evento.Fecha = reader.GetDateTime(1);
                                    evento.Inicio = reader.GetDateTime(2);
                                    evento.Fin = reader.GetDateTime(3);
                                    //se usa "reader[numeroColumna] as tipoDato" para evitar errores por null
                                    evento.Titulo = reader[4] as string;
                                    evento.Descripcion = reader[5] as string;
                                    evento.Ubicacion = reader[6] as string;
                                    evento.EsSerie = reader.GetBoolean(7);
                                    evento.Dias = reader[8] as string;

                                    // Ahora se obtienen los contactos asociados
                                    string nombres = "";
                                    //Lista para guardar los nombres de los contactos, instanciado para no tener problemas de null al asignar
                                                                                          
                                    if (nombres.Equals(""))//Si no hay nada pone el primero sin ningun formato
                                    {
                                        nombres = reader[9] as string;
                                    }
                                    else//Si ya habia algo, pone una coma y luego el otro
                                    {
                                        nombres += ", " + reader[9] as string;
                                    }
                                    //Se hace lo mismo que antes en este reader, para problemas de null
                                        
                                    evento.Contactos = nombres;

                                    eventos.Add(evento);//Aniade el evento que se creo antes a la coleccion
                                }
                            }                         
                        }
                    }
                }
                return eventos;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
            }
            return null;
        }
    }
}
