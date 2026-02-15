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
    public class Clase_det_salida_inventario : BASE_DE_DATOS.Conexion
    {
        private long id_salida_inventario;
        private string fecha;
        private string estado;
        private long id_venta_fk_salida_inventario;
        private long id_empleado_fk_salida_inventario;

        public long id_salida_inventarioM
        {
            get { return id_salida_inventario; }
            set { id_salida_inventario = value; }
        }

        public string fechaM
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public string estadoM
        {
            get { return estado; }
            set { estado = value; }
        }

        public long id_venta_fk_salida_inventarioM
        {
            get { return id_venta_fk_salida_inventario; }
            set { id_venta_fk_salida_inventario = value; }
        }

        public long id_empleado_fk_salida_inventarioM
        {
            get { return id_empleado_fk_salida_inventario; }
            set { id_empleado_fk_salida_inventario = value; }
        }

        public void insertar_salida_producto ()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();
                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "INSERTAR_SALIDA_INVENTARIO";
                cmm.Parameters.AddWithValue("@ID_SALIDA_INVENTARIO", id_salida_inventarioM);
                cmm.Parameters.AddWithValue("@FECHA", fechaM);
                cmm.Parameters.AddWithValue("@ESTADO", estadoM);
                cmm.Parameters.AddWithValue("@ID_VENTA_FK_SALIDA_INVENTARIO", id_venta_fk_salida_inventarioM);
                cmm.Parameters.AddWithValue("@ID_EMPLEADO_FK_SALIDA_INVENTARIO", id_empleado_fk_salida_inventarioM);

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

            nombreprocedimiento = "CONSULTA_GENERAL_SALIDA_INVENTARIO";
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
                cmm.CommandText = "ACTUALIZAR_SALIDA_INVENTARIO";
                cmm.Parameters.AddWithValue("@ID_SALIDA_INVENTARIO", id_salida_inventarioM);
                cmm.Parameters.AddWithValue("@FECHA", fechaM);
                cmm.Parameters.AddWithValue("@ESTADO", estadoM);
                cmm.Parameters.AddWithValue("@ID_VENTA_FK_SALIDA_INVENTARIO", id_venta_fk_salida_inventarioM);
                cmm.Parameters.AddWithValue("@ID_EMPLEADO_FK_SALIDA_INVENTARIO", id_empleado_fk_salida_inventarioM);
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
                cmm.Parameters.AddWithValue("@ID_SALIDA_INVENTARIO", id_salida_inventarioM);
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
