using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Threading;
using System.Reflection;

namespace Entidades
{
    public enum EDbOperation
    {
        insert,
        update
    }
    public static class DB
    {
        const string STRINGCONNEC = "Data Source = .\\SQLEXPRESS;Initial Catalog = SeifMariano2dTp4; Integrated Security = True;";

        static SqlConnection sqlConn;
        static SqlCommand command;

        static DB()
        {
            sqlConn = new SqlConnection();
            sqlConn.ConnectionString = STRINGCONNEC;
            command = new SqlCommand();
            command.Connection = sqlConn;
        }

        /// <summary>
        /// Guarda un objeto de la clase producto en la base de datos, puede ser una operacion insert o update
        /// </summary>
        /// <param name="producto"></param>
        /// <param name="operacion"></param>
        /// <returns></returns>
        public static bool GuardarProducto(Producto producto, EDbOperation operacion)
        {
            string consulta = String.Empty;
            switch (operacion)
            {
                case EDbOperation.insert:
                    consulta = "insert into productos values (@descripcion, @precio, @stock)";
                    break;
                case EDbOperation.update:
                    consulta = "update productos set stock = @stock where id = @id";
                    break;
            }

            command.CommandText = consulta;
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter("@descripcion", producto.Descripcion));
            command.Parameters.Add(new SqlParameter("@precio", producto.Precio));
            command.Parameters.Add(new SqlParameter("@stock", producto.Stock));
            command.Parameters.Add(new SqlParameter("@id", producto.Id));

            try
            {
                if (sqlConn.State != System.Data.ConnectionState.Open)
                    sqlConn.Open();
                int retorno = command.ExecuteNonQuery();
                if(retorno == 1 && operacion == EDbOperation.insert)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@descripcion", "%" + producto.Descripcion + "%");
                    command.CommandText = "select id from productos where descripcion like @descripcion";
                    producto.Id = (int)command.ExecuteScalar();
                }
                return retorno != -1;
            }
            catch (Exception ex)
            {
                throw new DatabaseException(ex);
            }
            finally
            {
                if (sqlConn.State != System.Data.ConnectionState.Closed)
                {
                    sqlConn.Close();
                }
            }
        }

        /// <summary>
        /// Arma una lista de productos con los datos traidos de la base de datos
        /// </summary>
        /// <returns></returns>
        public static List<Producto> TraerProductos()
        {
            string consulta = "select * from productos where stock > 0";
            List<Producto> productos = new List<Producto>();

            try
            {
                command.CommandText = consulta;

                if( sqlConn.State != System.Data.ConnectionState.Open)
                {
                    sqlConn.Open();
                }
                
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    productos.Add(new Producto(
                        int.Parse(dataReader["id"].ToString()),
                        dataReader["descripcion"].ToString(),
                        double.Parse(dataReader["precio"].ToString()),
                        int.Parse(dataReader["stock"].ToString())
                    ));
                }
                return productos;
            }
            catch (Exception ex)
            {
                throw new DatabaseException(ex);
            }
            finally
            {
                if (sqlConn.State != System.Data.ConnectionState.Closed)
                {
                    sqlConn.Close();
                }
            }
        }

        /// <summary>
        /// Arma una lista de clientes con los datos traidos de la base de datos
        /// </summary>
        /// <returns></returns>
        public static List<Cliente> TraerClientes()
        {
            string consulta = "select * from clientes";
            List<Cliente> clientes = new List<Cliente>();

            try
            {
                command.CommandText = consulta;

                if (sqlConn.State != System.Data.ConnectionState.Open)
                {
                    sqlConn.Open();
                }

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    clientes.Add(new Cliente(
                        int.Parse(dataReader["id"].ToString()),
                        dataReader["nombre"].ToString()
                    ));
                }
                return clientes;
            }
            catch (Exception ex)
            {
                throw new DatabaseException(ex);
            }
            finally
            {
                if (sqlConn.State != System.Data.ConnectionState.Closed)
                {
                    sqlConn.Close();
                }
            }
        }

        /// <summary>
        /// Guarda una venta en la base de datos-Se utiliza una tabla ventas y una tabla itemsventa
        /// </summary>
        /// <param name="venta"></param>
        public static void GuardarVenta(Venta venta)
        {
            string consulta = "insert into ventas (idCliente) output INSERTED.ID values (@idCliente)";
            string consulta2 = "insert into itemsventa values (@idVenta, @idProducto, @cantidad)";

            command.CommandText = consulta;
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter("@idCliente", venta.Cliente.Id));

            try
            {
                if (sqlConn.State != System.Data.ConnectionState.Open)
                    sqlConn.Open();
                int id = (int)command.ExecuteScalar();
                
                command.CommandText = consulta2;
                foreach (ItemVenta item in venta.Items)
                {
                    command.Parameters.Clear();
                    command.Parameters.Add(new SqlParameter("@idVenta", id));
                    command.Parameters.Add(new SqlParameter("@idProducto", item.Producto.Id));
                    command.Parameters.Add(new SqlParameter("@cantidad", item.Cantidad));

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseException(ex);
            }
            finally
            {
                if (sqlConn.State != System.Data.ConnectionState.Closed)
                {
                    sqlConn.Close();
                }
            }
        }
    }
}
