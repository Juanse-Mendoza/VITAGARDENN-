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
    public class Clase_detalle_venta_producto:BASE_DE_DATOS.Conexion
    {
        private string observaciones_venta_producto;
        private int cantidad;
        private float valor;
        private long id_producto_fk_venta_producto;
        private long id_venta_fk_venta_producto;

        public string observaciones_venta_productoM
        {
            get { return observaciones_venta_producto; }
            set { observaciones_venta_producto = value; }
        }

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
        public long id_producto_fk_venta_productoM
        {
            get { return id_producto_fk_venta_producto; }
            set { id_producto_fk_venta_producto = value; }
        }

        public long id_venta_fk_venta_productoM
        {
            get { return id_venta_fk_venta_producto; }
            set { id_venta_fk_venta_producto = value; }
        }

        public void insertar_venta_producto()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();
                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "INSERTAR_VENTA_PRODUCTO";
                cmm.Parameters.AddWithValue("@OBSERVACIONES", observaciones_venta_productoM);
                cmm.Parameters.AddWithValue("@CANTIDAD", cantidadM);
                cmm.Parameters.AddWithValue("@VALOR", valorM);
                cmm.Parameters.AddWithValue("@ID_PRODUCTO_FK_VENTA_PRODUCTO", id_producto_fk_venta_productoM);
                cmm.Parameters.AddWithValue("@ID_VENTA_FK_VENTA_PRODUCTO", id_venta_fk_venta_productoM);

                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se ha insertado una nueva venta del producto");
            }
            catch (Exception)
            {
                MessageBox.Show("error al insertar la nueva venta del producto");
            }
        }

        public void Consultageneral_venta_producto(ref DataGridView grilla)
        {
            conectar();
            string nombreprocedimiento;

            nombreprocedimiento = " CONSULTA_GENERAL_VENTA_PRODUCTO";
            SqlDataAdapter da = new SqlDataAdapter(nombreprocedimiento, con);
            DataSet dset = new DataSet();
            da.Fill(dset, nombreprocedimiento);
            grilla.DataSource = dset;
            grilla.DataMember = nombreprocedimiento;
            DESCONECTAR();
        }

        public void actualizar_venta_producto()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();

                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "ACTUALIZAR_VENTA_PRODUCTO";
                cmm.Parameters.AddWithValue("@OBSERVACIONES", observaciones_venta_productoM);
                cmm.Parameters.AddWithValue("@CANTIDAD", cantidadM);
                cmm.Parameters.AddWithValue("@VALOR", valorM);
                cmm.Parameters.AddWithValue("@ID_PRODUCTO_FK_VENTA_PRODUCTO", id_producto_fk_venta_productoM);
                cmm.Parameters.AddWithValue("@ID_VENTA_FK_VENTA_PRODUCTO", id_venta_fk_venta_productoM);
                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se actualizo correctamente los datos de la venta del producto");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar los datos de la venta del producto");
            }
        }

        public void eliminar_venta_producto()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();

                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "ELIMINAR_VENTA_PRODUCTO";
                cmm.Parameters.AddWithValue("@ID_PRODUCTO_FK_VENTA_PRODUCTO", id_producto_fk_venta_productoM);
                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se elimino correctamente los datos de la venta del producto");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar los datos de la venta del producto" + ex);
            }
        }
    }
}
