using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TP3ClassLibrary
{
    public class ProductoDAO
    {
        static string cadenaConexion;
        static SqlCommand comando;
        static SqlConnection conexion;

        //Delegado Eventos
        public delegate void FalloDB();       
        public static FalloDB OnFalloConexionDataBase;



        static ProductoDAO()
        {
            cadenaConexion = @"Server=localhost;Database=TP4SosaDB;Trusted_Connection=True;";
            //cadenaConexion = "";
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
                comando.Parameters.AddWithValue("@id", producto.IdProducto);
                comando.Parameters.AddWithValue("@precio", producto.Price);
                comando.Parameters.AddWithValue("@nombre", producto.Nombre);
                comando.Parameters.AddWithValue("@cantidad", producto.Cantidad);
                comando.Parameters.AddWithValue("@rareza", producto.Rareza);

                comando.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }

        }


        public static bool ProductoEnBaseDato(Producto producto)
        {
            bool retorno = true;
            producto = ProductoDAO.LeerPorId(producto.IdProducto);
            if(producto is null)
            {
                retorno = false;
            }

            return retorno;
        }

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
                                    Convert.ToDouble(dataReader["PRECIO"]),
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
                throw;
            }
            finally
            {
                conexion.Close();
            }

            return producto;
        }


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
                                    Convert.ToDouble(dataReader["PRECIO"]),
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
               
                OnFalloConexionDataBase();
            }
            finally
            {
                conexion.Close();
            }

            return productos;
        }

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
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }

        public static void Modificar(Producto producto)
        {
            try
            {

                comando.Parameters.Clear();
                conexion.Open();
                comando.CommandText = $"UPDATE PRODUCTOS SET PRECIO = @precio, ID = @id, NOMBRE=@nombre, CANTIDAD=@cantidad, RAREZA = @rareza WHERE ID = {producto.IdProducto}";
                comando.Parameters.AddWithValue("@precio", producto.Price);
                comando.Parameters.AddWithValue("@id", producto.IdProducto);
                comando.Parameters.AddWithValue("@nombre", producto.Nombre);
                comando.Parameters.AddWithValue("@cantidad", producto.Cantidad);
                comando.Parameters.AddWithValue("@rareza", producto.Rareza);

                comando.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }

        }
    }
}
