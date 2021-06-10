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
        public static ObservableCollection<Diario> GetDiarios(string connectionString)//Metodo para recuperar datos
        {
            const string GetDiariosQuery = "select DiarioID, Fecha, Contenido " +//Definicion de lo que queremos de Diario
                "from Diarios";

            var diarios = new ObservableCollection<Diario>();//Coleccion de diario para almacenar las entradas de la tabla
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
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
    }
}
