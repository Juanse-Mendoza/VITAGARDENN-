using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BASE_DE_DATOS;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace LOGICA
{
    public class Clase_salida_producto:BASE_DE_DATOS.Conexion
    {
        private int cantidad;
        private float valor;
        private long id_producto_fk_salida_producto;
        private long id_salida_inventario_fk_salida_producto;

        public int cantidadM
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public float valorM
        {
            get { return valor; }
            set { valor = value; }
        }

        public long id_producto_fk_salida_productoM
        {
            get { return id_producto_fk_salida_producto; }
            set { id_producto_fk_salida_producto = value; }
        }

        public long id_salida_inventario_fk_salida_productoM
        {
            get { return id_salida_inventario_fk_salida_producto; }
            set { id_salida_inventario_fk_salida_producto = value; }
        }

        public void insertar_salida_producto()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();
                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "INSERTAR_SALIDA_PRODUCTO";
                cmm.Parameters.AddWithValue("@CANTIDAD", cantidadM);
                cmm.Parameters.AddWithValue("@VALOR", valorM);
                cmm.Parameters.AddWithValue("@ID_PRODUCTO_FK_SALIDA_PRODUCTO", id_producto_fk_salida_productoM);
                cmm.Parameters.AddWithValue("@ID_SALIDA_INVENTARIO_FK_SALIDA_PRODUCTO", id_salida_inventario_fk_salida_productoM);
                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se ha insertado una nueva salida del producto");
            }
            catch (Exception)
            {
                MessageBox.Show("error al insertar la nueva salida del producto");
            }
        }

        public void Consultageneral_salida_producto(ref DataGridView grilla)
        {
            conectar();
            string nombreprocedimiento;

            nombreprocedimiento = "CONSULTA_GENERAL_SALIDA_PRODUCTO";
            SqlDataAdapter da = new SqlDataAdapter(nombreprocedimiento, con);
            DataSet dset = new DataSet();
            da.Fill(dset, nombreprocedimiento);
            grilla.DataSource = dset;
            grilla.DataMember = nombreprocedimiento;
            DESCONECTAR();
        }

        public void actualizar_salida_producto()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();

                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "ACTUALIZAR_SALIDA_PRODUCTO";
                cmm.Parameters.AddWithValue("@CANTIDAD", cantidadM);
                cmm.Parameters.AddWithValue("@VALOR", valorM);
                cmm.Parameters.AddWithValue("@ID_PRODUCTO_FK_SALIDA_PRODUCTO", id_producto_fk_salida_productoM);
                cmm.Parameters.AddWithValue("@ID_SALIDA_INVENTARIO_FK_SALIDA_PRODUCTO", id_salida_inventario_fk_salida_productoM);

                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se actualizo correctamente los datos de la salida del producto");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar los datos de la salida del producto");
            }
        }

        public void eliminar_salida_producto()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();

                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "ELIMINAR_SALIDA_PRODUCTO";
                cmm.Parameters.AddWithValue("@CANTIDAD", cantidadM);
                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se elimino correctamente los datos de la salida del producto");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar los datos de la salida del producto" + ex);
            }
        }
    }
}
