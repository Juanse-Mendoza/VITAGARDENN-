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
    public class Clase_detalle_entrada_producto : BASE_DE_DATOS.Conexion
    {
        private int cantidad_entrada_producto;
        private float valor_entrada_producto;
        private long id_producto_fk_entrada_producto;
        private long id_venta_producto_fk_entrada_producto;

        public int cantidad_entrada_productoM
        {
            get { return cantidad_entrada_producto; }
            set { cantidad_entrada_producto = value; }
        }

        public float valor_entrada_productoM
        {
            get { return valor_entrada_producto; }
            set { valor_entrada_producto = value; }
        }

        public long id_producto_fk_entrada_productoM
        {
            get { return id_producto_fk_entrada_producto; }
            set { id_producto_fk_entrada_producto = value; }
        }

        public long id_venta_producto_fk_entrada_productoM
        {
            get { return id_venta_producto_fk_entrada_producto; }
            set { id_venta_producto_fk_entrada_producto = value; }
        }

        public void insertar_entrada_producto()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();
                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "INSERTAR_ENTRADA_PRODUCTO";
                cmm.Parameters.AddWithValue("@CANTIDAD", cantidad_entrada_productoM);
                cmm.Parameters.AddWithValue("@VALOR", valor_entrada_productoM);
                cmm.Parameters.AddWithValue("@ID_PRODUCTO_FK_ENTRADA_PRODUCTO", id_producto_fk_entrada_productoM);
                cmm.Parameters.AddWithValue("@ID_ENTRADA_COMPRA_FK_ENTRADA_PRODUCTO", id_venta_producto_fk_entrada_productoM);

                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se ha insertado una nueva entrada de un producto");
            }
            catch (Exception)
            {
                MessageBox.Show("error al insertar la nueva entrada del producto");
            }
        }

        public void Consultageneral_entrada_producto(ref DataGridView grilla)
        {
            conectar();
            string nombreprocedimiento;

            nombreprocedimiento = " CONSULTA_GENERAL_ENTRADA_PRODUCTO ";
            SqlDataAdapter da = new SqlDataAdapter(nombreprocedimiento, con);
            DataSet dset = new DataSet();
            da.Fill(dset, nombreprocedimiento);
            grilla.DataSource = dset;
            grilla.DataMember = nombreprocedimiento;
            DESCONECTAR();
        }

        public void actualizar_entrada_producto()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();

                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "ACTUALIZAR_ENTRADA_PRODUCTO";
                cmm.Parameters.AddWithValue("@CANTIDAD", cantidad_entrada_productoM);
                cmm.Parameters.AddWithValue("@VALOR", valor_entrada_productoM);
                cmm.Parameters.AddWithValue("@ID_PRODUCTO_FK_ENTRADA_PRODUCTO", id_producto_fk_entrada_productoM);
                cmm.Parameters.AddWithValue("@ID_ENTRADA_COMPRA_FK_ENTRADA_PRODUCTO", id_venta_producto_fk_entrada_productoM);
                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se actualizo correctamente los datos de la entrada de compra");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar los datos de la entrada de la compra");
            }
        }

        public void eliminar_entrada_producto()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();

                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "ELIMINAR_ENTRADA_PRODUCTO";
                cmm.Parameters.AddWithValue("@ID_PRODUCTO_FK_ENTRADA_PRODUCTO", id_producto_fk_entrada_productoM);
                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se elimino correctamente los datos de la entrada del producto");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar los datos de la entrada del producto" + ex);
            }
        }
    }
}
