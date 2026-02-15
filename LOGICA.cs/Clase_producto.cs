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
    public class Clase_producto:BASE_DE_DATOS.Conexion
    {
        private long id_producto;
        private string nombre_producto;
        private float valor_producto;
        private int cantidad_producto;
        private string estado_producto;
        private long id_empleado_fk_producto;
        private long id_proveedor_fk_producto;

        public long id_productoM
        {
            get { return id_producto; }
            set { id_producto = value; }
        }

        public string nombre_productoM
        {
            get { return nombre_producto;}
            set { nombre_producto = value; }
        }

        public float valor_productoM
        {
            get { return valor_producto; }
            set { valor_producto = value; }
        }

        public int cantidad_productoM
        {
            get { return cantidad_producto; }
            set { cantidad_producto = value; }
        }

        public string estado_productoM
        {
            get { return estado_producto; }
            set { estado_producto = value; }
        }
        public long id_empleado_fk_productoM
        {
            get { return id_empleado_fk_producto; }
            set { id_empleado_fk_producto = value; }
        }

        public long id_proveedor_fk_productoM
        {
            get { return id_proveedor_fk_producto; }
            set { id_proveedor_fk_producto = value; }
        }

        public void insertar_producto()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();
                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "INSERTAR_PRODUCTO";
                cmm.Parameters.AddWithValue("@ID_PRODUCTO", id_productoM);
                cmm.Parameters.AddWithValue("@NOMBRE", nombre_productoM);
                cmm.Parameters.AddWithValue("@VALOR", valor_productoM);
                cmm.Parameters.AddWithValue("@CANTIDAD", cantidad_productoM);
                cmm.Parameters.AddWithValue("@ESTADO", estado_productoM);
                cmm.Parameters.AddWithValue("@ID_EMPLEADO_FK_PRODUCTO", id_empleado_fk_productoM);
                cmm.Parameters.AddWithValue("@ID_PROVEEDOR_FK_PRODUCTO", id_proveedor_fk_productoM);

                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se ha insertado un nuevo producto");
            }
            catch (Exception)
            {
                MessageBox.Show("error al insertar el nuevo producto");
            }
        }

        public void Consultageneral_producto(ref DataGridView grilla)
        {
            conectar();
            string nombreprocedimiento;

            nombreprocedimiento = "CONSULTA_GENERAL_PRODUCTO";
            SqlDataAdapter da = new SqlDataAdapter(nombreprocedimiento, con);
            DataSet dset = new DataSet();
            da.Fill(dset, nombreprocedimiento);
            grilla.DataSource = dset;
            grilla.DataMember = nombreprocedimiento;
            DESCONECTAR();
        }

        public void actualizar_producto()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();

                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "ACTUALIZAR_PRODUCTO";
                cmm.Parameters.AddWithValue("@ID_PRODUCTO", id_productoM);
                cmm.Parameters.AddWithValue("@NOMBRE", nombre_productoM);
                cmm.Parameters.AddWithValue("@VALOR", valor_productoM);
                cmm.Parameters.AddWithValue("@CANTIDAD", cantidad_productoM);
                cmm.Parameters.AddWithValue("@ESTADO", estado_productoM);
                cmm.Parameters.AddWithValue("@ID_EMPLEADO_FK_PRODUCTO", id_empleado_fk_productoM);
                cmm.Parameters.AddWithValue("@ID_PROVEEDOR_FK_PRODUCTO", id_proveedor_fk_productoM);
                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se actualizo correctamente los datos del producto");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar los datos del producto");
            }
        }

        public void eliminar_producto()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();

                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "ELIMINAR_PRODUCTO";
                cmm.Parameters.AddWithValue("@ID_PRODUCTO", id_productoM);
                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se elimino correctamente los datos del producto");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar los datos del producto" + ex);
            }
        }
    }
}
