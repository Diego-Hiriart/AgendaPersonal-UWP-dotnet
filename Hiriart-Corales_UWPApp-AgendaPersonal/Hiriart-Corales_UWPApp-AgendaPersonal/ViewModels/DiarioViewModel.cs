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
            const string GetDiariosQuery = "select DiarioID, Fecha, Contenido " +//Definicion de lo que queremos de Diario
                "from Diarios";

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
                            var diario = new Diario();//Una instancia de artistas para ir guardando y almacenando lo que se lea de la base
                            cmd.CommandText = GetDiariosQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {                     
                                while (reader.Read())
                                {
                                    diario.DiarioID = reader.GetInt32(0);//El parametro dentro de estos gets indica la posicion del atributo dentro de la tabla                                  
                                    diario.Fecha = reader.GetDateTime(1);
                                    //se usa "reader[numeroColumna] as tipoDato" para evitar errores por null
                                    diario.Contenido = (string)reader[2];                                  
                                }                          
                            }
                            /* Ahora se transforman los IDs de eventos en títulos de evento,
                             * se hace luego de que acabe el anterior ExecuteReader de cmd pues
                             * debe acabar el comando antes de ejecutar otro
                            */

                            string titulos = "";
                            //Lista para guardar los titulos de los eventos, instanciado para no tener problemas de null al asignar

                            const string EventoIDAEventoTiulo = "select Titulo from ListaEventoes where IDDiario = @id";
                            //Hay maneras mas simples de hacer la cadena para el comando, pero esta evita inyeccion SQL, mejor acostumbrarse a usar, Atte. Diego                            
                            cmd.CommandText = EventoIDAEventoTiulo;
                            cmd.Parameters.AddWithValue("@id", diario.DiarioID);
                            //Donde en la cadena tenga @id, reemplazar por el id de este diario                       
                            using (SqlDataReader reader = cmd.ExecuteReader())                           
                            {                             
                                while (reader.Read())
                                {
                                    if (titulos.Equals(""))//Si no hay nada pone el primero sin ningun formato
                                    {
                                        titulos = reader[0] as string;
                                    }
                                    else//Si ya habia algo, pone una coma y luego el otro
                                    {
                                        titulos += ", " + reader[0] as string;
                                    }
                                    //Se hace lo mismo que antes en este reader, para problemas de null
                                }                              
                            }                    
                            diario.Eventos = titulos;

                            diarios.Add(diario);//Aniade el diario que se creo antes a la coleccion
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
                                    const string editarAsociacion = "update ListaEventoes set IDDiario=@ID where ListaEventoID=@evento";
                                    cmd.CommandText = editarAsociacion;
                                    cmd.Parameters.AddWithValue("@IDDiario", ultimaEntrada);
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
    }
}
