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
    public class DiarioViewModel : ObservableObject
    {
        public DiarioViewModel()
        {
        }

        //El siguiente metodo es static para poder llamarlo sin instanciar, también se le prodía colocar en una librería de funciones para SQL
        public static ObservableCollection<Diario> ReadDiarios(string connectionString)//Metodo para recuperar datos
        {
            const string GetDiariosQuery = "select Diarios.DiarioID, Diarios.Fecha, Diarios.Contenido, ListaEventoes.Titulo " +//Definicion de lo que queremos de Diario
                "from Diarios left join ListaEventoes on ListaEventoes.IDDiario=Diarios.DiarioID";
            /* left join permite sacar de dos tablas al mismo tiempo, siempre y cuando haya clave foranea que les relacione, 
             * se debe poner tabla.Atributo para sacar porque hay dos tablas involucradas, left join coge todos, tengan o no relacion con la otra tabla
            */

            var diarios = new ObservableCollection<Diario>();//Coleccion de diario para almacenar las entradas de la tabla
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = GetDiariosQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var diario = new Diario();//Una instancia de diario para ir guardando y almacenando lo que se lea de la base
                                    diario.DiarioID = reader.GetInt32(0);//El parametro dentro de estos gets indica la posicion del atributo dentro de la tabla                                  
                                    diario.Fecha = reader.GetDateTime(1);
                                    //se usa "reader[numeroColumna] as tipoDato" para evitar errores por null
                                    diario.Contenido = (string)reader[2];
                                    /* Ahora se transforman los IDs de eventos en títulos de evento,
                                     * se hace luego de que acabe el anterior ExecuteReader de cmd pues
                                     * debe acabar el comando antes de ejecutar otro
                                    */

                                    string titulos = "";
                                    //Lista para guardar los titulos de los eventos, instanciado para no tener problemas de null al asignar                                 

                                    if (titulos.Equals(""))//Si no hay nada pone el primero sin ningun formato
                                    {
                                        titulos = reader[3] as string;

                                    }
                                    else//Si ya habia algo, pone una coma y luego el otro
                                    {
                                        titulos += ", " + reader[3] as string;
                                    }
                                    //Se hace lo mismo que antes en este reader, para problemas de null


                                    diario.Eventos = titulos;
                                    
                                    diarios.Add(diario);//Aniade el diario que se creo antes a la coleccion
                                }
                            }
                        }
                    }
                }     
                return diarios;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
            }
            return null;
        }

        public static bool CreateDiario(string connectionString, DateTimeOffset fecha, string contenido, List<int?> eventos)
        {
            DateTime fechaEntrada = fecha.Date;//transformar de DateTiemOffset a DateTime

            //Primero insertar una nueva entrada de Diarios
            const string insertarDiario = "insert into Diarios(Fecha, Contenido) " +
                "values(@Fecha, @Contenido)";
            //Este tipo de sentencia con @Valor, permite llenar esos parametros luego, es más seguro porque evita inyección SQL, mejor acostumbarse a usar, Atte. Diego

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = insertarDiario;
                            cmd.Parameters.AddWithValue("@Fecha", fechaEntrada);
                            cmd.Parameters.AddWithValue("@Contenido", contenido);
                            cmd.ExecuteNonQuery();

                            //Ahora, asociar los eventos al Diario, en caso de ser necesario
                            if (eventos.Count != 0)
                            {
                                //Primero, obtener el ID del ultimo diario, es decir el que se ingreso ahora, para poder asociar
                                List<int?> idDiarios = new List<int?>();//Lista para guardar los ids leidos
                                const string ids = "select DiarioID from Diarios";
                                cmd.CommandText = ids;
                                using(SqlDataReader lector = cmd.ExecuteReader())
                                {
                                    while (lector.Read())
                                    {
                                        idDiarios.Add(lector[0] as int?);
                                    }
                                }
                                int ultimaEntrada=0;
                                foreach (int id in idDiarios)//Obtener ultima entrada, debe ser el id mas alto
                                {
                                    if (id>ultimaEntrada)
                                    {
                                        ultimaEntrada = id;
                                    }
                                }

                                //Asociar cada evento de la lista con la entrada de diario
                                foreach (int id in eventos)
                                {
                                    const string editarAsociacion = "update ListaEventoes set IDDiario=@ultima where ListaEventoID=@evento";
                                    cmd.CommandText = editarAsociacion;
                                    cmd.Parameters.AddWithValue("@ultima", ultimaEntrada);
                                    cmd.Parameters.AddWithValue("@evento", id);
                                    cmd.ExecuteNonQuery();
                                }                               
                            }
                        }                      
                    }

                }
                return true;//Retorna true si es que se pudo ingesar el dato
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
                return false;//Retorna false si algo paso, asi no se borra nada en los TextBox
            }
        }

        public static bool DeleteDiario(string connectionString, int id)
        {
            const string borrar = "delete from Diarios where DiarioID=@ID";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = borrar;
                            cmd.Parameters.AddWithValue("@ID", id);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                return true;//Retornar true para notificar borrado exitoso
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
                return false;//Retorna false si no se borro para notificar
            }
        }

        public static bool UpdateDiario(string connectionString, int DiarioID, DateTimeOffset fecha, string contenido, List<int?> eventos)
        {
            DateTime fechaNueva = fecha.Date;//transformar de DateTiemOffset a DateTime

            const string editarDiario = "update Diarios set Fecha=@fecha, Contenido=@contenido where DiarioID=@id";

            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    if(conexion.State == ConnectionState.Open)
                    {
                        using (SqlCommand consola = conexion.CreateCommand())
                        {
                            consola.CommandText = editarDiario;
                            consola.Parameters.AddWithValue("@fecha", fecha);
                            consola.Parameters.AddWithValue("@contenido", contenido);
                            consola.Parameters.AddWithValue("@id", DiarioID);
                            consola.ExecuteNonQuery();

                            foreach (int id in eventos)
                            {
                                const string editarAsociacion = "update ListaEventoes set IDDiario=@ID where ListaEventoID=@evento";
                                consola.CommandText = editarAsociacion;
                                consola.Parameters.AddWithValue("@IDDiario", DiarioID);
                                consola.Parameters.AddWithValue("@evento", id);
                                consola.ExecuteNonQuery();
                            }
                        }
                    }
                }
                return true;//Notficar edicion exitosa
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
                return false;//Avisar que no se pudo actualizar
            }           
        }

        public static ObservableCollection<Evento> EventosVinculados(string connectionString, int DiarioID)
        {
            const string GetDiariosQuery = "select Eventoes.EventoID, Eventoes.Fecha, Eventoes.Inicio, Eventoes.Fin, " +//Definicion de lo que queremos de Evento
                "Eventoes.Titulo, Eventoes.Descripcion, Eventoes.Ubicacion, Eventoes.EsSerie, Eventoes.Dias, ListaContactoes.NombreApellido from Eventoes " +
                "inner join ListaEventoes on ListaEventoes.IDDiario=Diarios.DiarioID";
            //inner join es parecido a left join, pero coge solo los que tienen relacion con la otra tabla

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

                            cmd.Parameters.AddWithValue("@ID", DiarioID);
                            cmd.CommandText = GetDiariosQuery;
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
