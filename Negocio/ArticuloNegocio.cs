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
                datos.setearConsulta("Select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.ImagenUrl,M.Descripcion AS Marca,C.Descripcion AS Categoria, A.Precio From ARTICULOS A, MARCAS M, CATEGORIAS C Where M.Id=A.IdMarca And C.Id=A.IdCategoria");
                datos.ejecutarLectura();

                while(datos.Lector.Read())
                {
                    Articulo art=new Articulo();
                    art.Id = (int)datos.Lector["Id"];
                    art.Codigo = (string)datos.Lector["Codigo"];
                    art.Nombre = (string)datos.Lector["Nombre"];
                    art.Descripcion = (string)datos.Lector["Descripcion"];
                    art.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    art.marca=new Marca();
                    art.marca.Descripcion = (string)datos.Lector["Marca"];
                    art.categoria = new Categoria();
                    art.categoria.Descripcion = (string)datos.Lector["Categoria"];
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
