using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Wakanda.Models
{
    public class CProductos
    {
        private SqlConnection con;

        public CProductos()
        {
            this.con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionProductos"].ToString());
            
        }

        public List<ProductosModel> GetProducts()
        {
            List<ProductosModel> productos = new List<ProductosModel>();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "ObtenerProductos";
            cmd.Connection = this.con;
            cmd.CommandType = CommandType.StoredProcedure;

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            
            this.con.Open();
            da.Fill(dt);
            this.con.Close();

            foreach(DataRow dr in dt.Rows)
            {
                productos.Add(
                    new ProductosModel
                    {
                        ID = Convert.ToInt32(dr["ID"]),
                        Nombre = dr["Nombre"].ToString(),
                        Descripcion = dr["Descripcion"].ToString(),
                        Precio = Convert.ToDecimal(dr["Precio"])
                    }
                    );
            }

            return productos;
        }

        public bool Insertar(ProductosModel p)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "InsertarProducto";
            cmd.Connection = this.con;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Nombre", p.Nombre);
            cmd.Parameters.AddWithValue("@Descripcion", p.Descripcion);
            cmd.Parameters.AddWithValue("@Precio", p.Precio);


            this.con.Open();
            int vf = cmd.ExecuteNonQuery();
            this.con.Close();

            if (vf >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Actualizar(ProductosModel p)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "ActualizarProducto";
            cmd.Connection = this.con;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID", p.ID);
            cmd.Parameters.AddWithValue("@Nombre", p.Nombre);
            cmd.Parameters.AddWithValue("@Descripcion", p.Descripcion);
            cmd.Parameters.AddWithValue("@Precio", p.Precio);


            this.con.Open();
            int vf = cmd.ExecuteNonQuery();
            this.con.Close();

            if (vf >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Eliminar(int ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EliminarProducto";
            cmd.Connection = this.con;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID", ID);


            this.con.Open();
            int vf = cmd.ExecuteNonQuery();
            this.con.Close();

            if (vf >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}