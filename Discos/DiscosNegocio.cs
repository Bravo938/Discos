using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Libreria para conectar
using System.Data.SqlClient;

namespace Discos
{
    internal class DiscosNegocio
    {
        public List<Discos> listasDiscos()
        {
            List<Discos>lista = new List<Discos>();
            //creo las instancias de los objetos que van a conctar y ejecutar comandos

            //Para conctar DB
            SqlConnection conexion = new SqlConnection();
            //para realizar accion o los comandos
            SqlCommand comando = new SqlCommand();
            //lector de la peticiones
            SqlDataReader lector;

            //Manejo de Exceptions, para capaturar los errores que puedan tener al conectar al db
            try
            {
                //Conexion a DB
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database= DISCOS_DB; integrated security= true" ;
                //configuracion para los comandos
                //primero defino que el comando sera tipo text
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select D.Titulo, D.FechaLanzamiento, D.CantidadCanciones, D.UrlImagenTapa,E.Descripcion Estilo, T.Descripcion Edicion From DISCOS D, ESTILOS E, TIPOSEDICION T\r\nwhere E.Id=IdEstilo And T.Id = IdTipoEdicion";
                //ejecuto el comando con la conexion
                comando.Connection = conexion;
                //abrir coneccion
                conexion.Open();
                //realizo lectura
                lector = comando.ExecuteReader();

                //muestro el lector

                while (lector.Read())
                {
                    Discos aux = new Discos();
                    aux.Titulo = (string)lector["Titulo"];
                    
                    aux.Fecha = lector.GetDateTime(1);
                    aux.CantidadDeCanciones = lector.GetInt32(2);
                    aux.UrlImagenTapa = (string)lector["UrlImagenTapa"];
                    aux.Edicion = new Estilo();
                    aux.Edicion.Descripcion = (string)lector["Edicion"];
                    aux.EstiloMusical = new Estilo();
                    aux.EstiloMusical.Descripcion = (string)lector["Estilo"];

                    lista.Add(aux);
                }
                conexion.Close();
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            

            
        }
    }
}
