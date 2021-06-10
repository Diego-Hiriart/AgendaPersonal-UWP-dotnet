using System;
using System.Collections.ObjectModel;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Hiriart_Corales_UWPApp_AgendaPersonal.Core.Models;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Hiriart_Corales_UWPApp_AgendaPersonal.ViewModels
{
    public class ContactosViewModel : ObservableObject
    {
        public ContactosViewModel()
        {
        }

        //El siguiente metodo es static para poder llamarlo sin instanciar, también se le prodía colocar en una librería de funciones para SQL
        public static ObservableCollection<Contacto> GetContactos(string connectionString)//Metodo para recuperar datos
        {
            const string GetAtistasQuery = "select ContactoID, Nombre, Apellido, Telefono, Email, Organizacion, " +//Definicion de lo que queremos de Contacto
                "FechaNacimiento, InformacionAdicional from Contactoes";

            var contactos = new ObservableCollection<Contacto>();//Coleccion de contactos para almacenar las entradas de la tabla
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = GetAtistasQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var contacto = new Contacto();//Una instancia de artistas para ir guardando y almacenando lo que se lea de la base
                                    contacto.ContactoID = reader.GetInt32(0);//El parametro dentro de estos gets indica la posicion del atributo dentro de la tabla
                                    //se usan castings con el reader[numeroColumna] para que los null se creen solos al leer
                                    contacto.Nombre = (string)reader[1];
                                    contacto.Apellido = (string)reader[2];
                                    contacto.Telefono = (string)reader[3];
                                    contacto.Email = (string)reader[4];
                                    contacto.Organizacion = (string)reader[5];
                                    contacto.FechaNacimiento = (DateTime)reader[6];
                                    contacto.InformacionAdicional = (string)reader[7];

                                    contactos.Add(contacto);//Aniade el contacto que se creo antes a la coleccion
                                }
                            }
                        }
                    }
                }
                return contactos;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
            }
            return null;
        }
    }
}
