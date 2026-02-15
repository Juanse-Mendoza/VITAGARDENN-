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
    public class Clase_detalle_compra_producto:BASE_DE_DATOS.Conexion
    {
        private string fecha;
        private int hora;
        private long id_producto_fk_compra_producto;
        private long id_compra_fk_compra_producto;

        public string fechaM
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public int horaM
        {
            get { return hora; }
            set { hora = value; }
        }

        public long id_producto_fk_compra_productoM
        {
            get { return id_producto_fk_compra_producto; }
            set { id_producto_fk_compra_producto = value; }
        }

        public long id_compra_fk_compra_productoM
        {
            get { return id_compra_fk_compra_producto; }
            set { id_compra_fk_compra_producto = value; }
        }

        public void insertar_compra_producto()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();
                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "INSERTAR_COMPRA_PRODUCTO";
                cmm.Parameters.AddWithValue("@FECHA", fechaM);
                cmm.Parameters.AddWithValue("@HORA", horaM);
                cmm.Parameters.AddWithValue("@ID_PRODUCTO_FK_COMPRA_PRODUCTO", id_producto_fk_compra_productoM);
                cmm.Parameters.AddWithValue("@ID_COMPRA_FK_COMPRA_PRODUCTO", id_compra_fk_compra_productoM);

                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se ha insertado una nueva compra del producto");
            }
            catch (Exception)
            {
                MessageBox.Show("error al insertar la nueva compra del producto");
            }
        }

        public void Consultageneral_compra_producto(ref DataGridView grilla)
        {
            conectar();
            string nombreprocedimiento;

            nombreprocedimiento = "CONSULTA_GENERAL_COMPRA_PRODUCTO";
            SqlDataAdapter da = new SqlDataAdapter(nombreprocedimiento, con);
            DataSet dset = new DataSet();
            da.Fill(dset, nombreprocedimiento);
            grilla.DataSource = dset;
            grilla.DataMember = nombreprocedimiento;
            DESCONECTAR();
        }

        public void actualizar_compra_producto()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();

                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "ACTUALIZAR_COMPRA_PRODUCTO";
                cmm.Parameters.AddWithValue("@FECHA", fechaM);
                cmm.Parameters.AddWithValue("@HORA", horaM);
                cmm.Parameters.AddWithValue("@ID_PRODUCTO_FK_COMPRA_PRODUCTO", id_producto_fk_compra_productoM);
                cmm.Parameters.AddWithValue("@ID_COMPRA_FK_COMPRA_PRODUCTO", id_compra_fk_compra_productoM);
                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se actualizo correctamente los datos de la compra del producto");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar los datos de la compra del producto");
            }
        }

        public void eliminar_compra_producto()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();

                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "ELIMINAR_COMPRA_PRODUCTO";
                cmm.Parameters.AddWithValue("@FECHA", fechaM);
                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se elimino correctamente los datos de la compra del producto");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar los datos de la compra del producto" + ex);
            }
        }
    }
}
