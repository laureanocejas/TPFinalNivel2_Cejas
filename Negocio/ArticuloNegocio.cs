using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> Listar()
        {
            //segundo commit representa todo el trabajo realizado actualmente 
            List<Articulo>lista= new List<Articulo>();

            AccesoDatos datos= new AccesoDatos();

            try
            {
                datos.setearConsulta("Select Id, Codigo, Nombre, Descripcion, Precio From ARTICULOS");
                datos.ejecutarLectura();

                while(datos.Lector.Read())
                {
                    Articulo art=new Articulo();
                    art.Id = (int)datos.Lector["Id"];
                    art.Codigo = (string)datos.Lector["Codigo"];
                    art.Nombre = (string)datos.Lector["Nombre"];
                    art.Descripcion = (string)datos.Lector["Descripcion"];
                    art.Precio = (float)(decimal)datos.Lector["Precio"];

                    lista.Add(art);
                    
                }
                datos.cerrarConexion();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

    }
}
