using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace TP3ClassLibrary
{

    /// <summary>
    /// Clase principal para el control de base de datos de los productos. 
    /// Se puede modificar, la carga sencilla esta inaccesible al usuario se usa para actualizar cuando se modifique y la baja se realiza de forma logica por lo que no la usamos en el proyecto.
    /// </summary>
    public class ProductoDAO
    {
        static string cadenaConexion;
        static SqlCommand comando;
        static SqlConnection conexion;

        //Delegado Eventos Cuando falla la conexion al servidor la app entra en modo local y solo se pueden usar las funciones de archivos
        public delegate void FalloDB();       
        public static event FalloDB OnFalloConexionBaseDatos;



        static ProductoDAO()
        {
            cadenaConexion = @"Server=localhost;Database=TP4SosaDB;Trusted_Connection=True;";
            comando = new SqlCommand();
            conexion = new SqlConnection(cadenaConexion);
            comando.Connection = conexion;
            comando.CommandType = System.Data.CommandType.Text;           
        }

        public static void Guardar(Producto producto)
        {
            try
            {

                comando.Parameters.Clear();
                conexion.Open();
                comando.CommandText = "INSERT INTO PRODUCTOS (ID,PRECIO,NOMBRE,CANTIDAD,RAREZA) VALUES (@id,@precio,@nombre,@cantidad,@rareza)";
                comando.Parameters.AddWithValue("@id", producto.Id);
                comando.Parameters.AddWithValue("@precio", producto.Precio);
                comando.Parameters.AddWithValue("@nombre", producto.Nombre);
                comando.Parameters.AddWithValue("@cantidad", producto.Cantidad);
                comando.Parameters.AddWithValue("@rareza", producto.Rareza);

                comando.ExecuteNonQuery();

            }
            catch (Exception)
            {
                OnFalloConexionBaseDatos();
            }
            finally
            {
                conexion.Close();
            }

        }

        /// <summary>
        /// Usando el Id del producto determinamos si este esta en la base de datos
        /// </summary>
        /// <param name="producto"> Producto a determinar si esta en la base</param>
        /// <returns>true si el producto esta en la base false si no esta</returns>
        public static bool ProductoEnBaseDato(Producto producto)
        {
            bool retorno = true;
            producto = ProductoDAO.LeerPorId(producto.Id);
            if(producto is null)
            {
                retorno = false;
            }

            return retorno;
        }

        /// <summary>
        /// Actualizado inteligente de la base de datos añade al producto si no esta y reemplaza el existente si ya esta en la base de datos
        /// </summary>
        /// <param name="productos"></param>
        public static void ActualizarProductos(List<Producto> productos)
        {
            if (productos != null && productos.Count > 0)
            {
                foreach (Producto item in productos)
                {
                    if (!ProductoDAO.ProductoEnBaseDato(item))
                    {
                        ProductoDAO.Guardar(item);
                    }
                    else if (ProductoDAO.ProductoEnBaseDato(item))
                    {
                        ProductoDAO.Modificar(item);
                    }
                }
            }
        }

        /// <summary>
        /// Busca a un producto por id y retorna este como objeto
        /// </summary>
        /// <param name="idProducto"></param>
        /// <returns> Producto </returns>
        public static Producto LeerPorId(int idProducto)
        {

            Producto producto = null;

            try
            {
                conexion.Open();
                comando.CommandText = $"SELECT * FROM PRODUCTOS WHERE ID = {idProducto}";
                SqlDataReader dataReader = comando.ExecuteReader();

                while (dataReader.Read())
                {
                    producto = new Producto
                                    (
                                    Convert.ToDecimal(dataReader["PRECIO"]),
                                    Convert.ToInt32(dataReader["ID"]),
                                    (dataReader["NOMBRE"].ToString()),
                                    Convert.ToInt32(dataReader["CANTIDAD"]),
                                    Convert.ToInt32(dataReader[("RAREZA")])
                                    );
                }

                dataReader.Close();
            }
            catch (Exception)
            {
                OnFalloConexionBaseDatos();
            }
            finally
            {
                conexion.Close();
            }

            return producto;
        }

        /// <summary>
        /// Lee la bade de datos y retorna una lista con todos los productos que hay en esta
        /// </summary>
        /// <returns></returns>
        public static List<Producto> Leer()
        {
            List<Producto> productos = new List<Producto>();

            try
            {
                conexion.Open();
                comando.CommandText = $"SELECT * FROM PRODUCTOS";
                SqlDataReader dataReader = comando.ExecuteReader();

                while (dataReader.Read())
                {
                    productos.Add(new Producto
                                    (
                                    Convert.ToDecimal(dataReader["PRECIO"]),
                                    Convert.ToInt32(dataReader["ID"]),
                                    dataReader["NOMBRE"].ToString(),
                                    Convert.ToInt32(dataReader["CANTIDAD"]),
                                    Convert.ToInt32(dataReader[("RAREZA")])
                                    ));
                }

                dataReader.Close();
            }
            catch (Exception)
            {
               
                OnFalloConexionBaseDatos();
            }
            finally
            {
                conexion.Close();
            }
            productos.Sort( (p1, p2) => p2.Id.CompareTo(p1.Id));
            return productos;
        }

        /// <summary>
        /// Eliminacion dura de un producto usando el id, no se uso preferi hacer una baja logica 
        /// </summary>
        /// <param name="idProducto"></param>
        public static void Eliminar(int idProducto)
        {

            try
            {
                conexion.Open();
                comando.CommandText = $"DELETE FROM PRODUCTOS WHERE ID = {idProducto}";
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                OnFalloConexionBaseDatos();
            }
            finally
            {
                conexion.Close();
            }
        }

        /// <summary>
        /// Modifica el producto que recibe por parametro obteniendolo por id
        /// </summary>
        /// <param name="producto"></param>
        public static void Modificar(Producto producto)
        {
            try
            {

                comando.Parameters.Clear();
                conexion.Open();
                comando.CommandText = $"UPDATE PRODUCTOS SET PRECIO = @precio, ID = @id, NOMBRE=@nombre, CANTIDAD=@cantidad, RAREZA = @rareza WHERE ID = {producto.Id}";
                comando.Parameters.AddWithValue("@precio", producto.Precio);
                comando.Parameters.AddWithValue("@id", producto.Id);
                comando.Parameters.AddWithValue("@nombre", producto.Nombre);
                comando.Parameters.AddWithValue("@cantidad", producto.Cantidad);
                comando.Parameters.AddWithValue("@rareza", producto.Rareza);

                comando.ExecuteNonQuery();

            }               
            catch (Exception)
            {
                OnFalloConexionBaseDatos();
            }
            finally
            {
                conexion.Close();
            }

        }
    }
}
