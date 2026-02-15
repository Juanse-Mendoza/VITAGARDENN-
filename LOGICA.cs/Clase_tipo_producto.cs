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
    public class Clase_tipo_producto:BASE_DE_DATOS.Conexion
    {
        private long id_tipo_producto;
        private string nombre_tipo_producto;
        private string estado_tipo_producto;
        private long id_producto_fk_tipo_producto;

        public long id_tipo_productoM
        {
            get { return id_tipo_producto; }
            set { id_tipo_producto = value; }
        }

        public string nombre_tipo_productoM
        {
            get { return nombre_tipo_producto; }
            set { nombre_tipo_producto = value; }
        }

        public string estado_tipo_productoM
        {
            get { return estado_tipo_producto; }
            set { estado_tipo_producto = value; }
        }
        public long id_producto_fk_tipo_productoM
        {
            get { return id_producto_fk_tipo_producto; }
            set { id_producto_fk_tipo_producto = value; }
        }

        public void insertar_tipo_producto()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();
                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "INSERTAR_TIPO_PRODUCTO";
                cmm.Parameters.AddWithValue("@ID_TIPO_PRODUCTO", id_tipo_productoM);
                cmm.Parameters.AddWithValue("@NOMBRE", nombre_tipo_productoM);
                cmm.Parameters.AddWithValue("@ESTADO", estado_tipo_productoM);
                cmm.Parameters.AddWithValue("@ID_PRODUCTO_FK_TIPO_PRODUCTO", id_producto_fk_tipo_productoM);

                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se ha insertado un nuevo tipo de producto");
            }
            catch (Exception)
            {
                MessageBox.Show("error al insertar un nuevo tipo de producto");
            }
        }

        public void Consultageneral_tipo_producto(ref DataGridView grilla)
        {
            conectar();
            string nombreprocedimiento;

            nombreprocedimiento = "CONSULTA_GENERAL_TIPO_PRODUCTO";
            SqlDataAdapter da = new SqlDataAdapter(nombreprocedimiento, con);
            DataSet dset = new DataSet();
            da.Fill(dset, nombreprocedimiento);
            grilla.DataSource = dset;
            grilla.DataMember = nombreprocedimiento;
            DESCONECTAR();
        }

        public void actualizar_tipo_producto()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();

                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "ACTUALIZAR_TIPO_PRODUCTO";
                cmm.Parameters.AddWithValue("@ID_TIPO_PRODUCTO", id_tipo_productoM);
                cmm.Parameters.AddWithValue("@NOMBRE", nombre_tipo_productoM);
                cmm.Parameters.AddWithValue("@ESTADO", estado_tipo_productoM);
                cmm.Parameters.AddWithValue("@ID_PRODUCTO_FK_TIPO_PRODUCTO", id_producto_fk_tipo_productoM);
                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se actualizo correctamente los datos del tipo de producto");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar los datos del tipo de producto");
            }
        }

        public void eliminar_tipo_producto()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();

                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "ELIMINAR_TIPO_PRODUCTO";
                cmm.Parameters.AddWithValue("@ID_TIPO_PRODUCTO", id_tipo_productoM);
                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se elimino correctamente los datos del tipo de producto");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar los datos del tipo de producto" + ex);
            }
        }
    }
}
