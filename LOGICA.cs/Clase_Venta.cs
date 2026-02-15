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
    public class Clase_Venta : BASE_DE_DATOS.Conexion
    {
        private long id_venta;
        private float valor_venta;
        private int cantidad_venta;
        private string fecha_venta;
        private float iva;
        private long id_empleado_fk_venta;
        private long id_cliente_fk_venta;

        public long id_ventaM
        {
            get { return id_venta; }
            set { id_venta = value; }
        }

        public float valor_ventaM
        {
            get { return valor_venta; }
            set { valor_venta = value; }
        }

        public int cantidad_ventaM
        {
            get { return cantidad_venta;}
            set { cantidad_venta = value; }
        }

        public string fecha_ventaM
        {
            get { return fecha_venta; }
            set { fecha_venta = value; }
        }

        public float ivaM
        {
            get { return iva; }
            set { iva = value; }
        }

        public long id_empleado_fk_ventaM
        {
            get { return id_empleado_fk_venta; }
            set { id_empleado_fk_venta = value; }
        }

        public long id_cliente_fk_ventaM
        {
            get { return id_cliente_fk_venta; }
            set { id_cliente_fk_venta= value; }
        }

        public void insertar_venta()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();
                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "INSERTAR_VENTA";
                cmm.Parameters.AddWithValue("@ID_VENTA", id_ventaM);
                cmm.Parameters.AddWithValue("@VALOR", valor_ventaM);
                cmm.Parameters.AddWithValue("@CANTIDAD", cantidad_ventaM);
                cmm.Parameters.AddWithValue("@FECHA", fecha_ventaM);
                cmm.Parameters.AddWithValue("@IVA", ivaM);
                cmm.Parameters.AddWithValue("@ID_EMPLEADO_FK_VENTA", id_empleado_fk_ventaM);
                cmm.Parameters.AddWithValue("@ID_CLIENTE_FK_VENTA", id_cliente_fk_ventaM);

                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se ha insertado una nueva venta");
            }
            catch (Exception)
            {
                MessageBox.Show("error al insertar venta");
            }
        }

        public void Consultageneral_venta(ref DataGridView grilla)
        {
            conectar();
            string nombreprocedimiento;

            nombreprocedimiento = "CONSULTA_GENERAL_VENTA";
            SqlDataAdapter da = new SqlDataAdapter(nombreprocedimiento, con);
            DataSet dset = new DataSet();
            da.Fill(dset, nombreprocedimiento);
            grilla.DataSource = dset;
            grilla.DataMember = nombreprocedimiento;
            DESCONECTAR();
        }

        public void actualizar_venta()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();

                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "ACTUALIZAR_VENTA";
                cmm.Parameters.AddWithValue("@ID_VENTA", id_ventaM);
                cmm.Parameters.AddWithValue("@VALOR", valor_ventaM);
                cmm.Parameters.AddWithValue("@CANTIDAD", cantidad_ventaM);
                cmm.Parameters.AddWithValue("@FECHA", fecha_ventaM);
                cmm.Parameters.AddWithValue("@IVA", ivaM);
                cmm.Parameters.AddWithValue("@ID_EMPLEADO_FK_VENTA", id_empleado_fk_ventaM);
                cmm.Parameters.AddWithValue("@ID_CLIENTE_FK_VENTA", id_cliente_fk_ventaM);
                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se actualizo correctamente los datos de la venta");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar los datos de la venta");
            }
        }

        public void eliminar_venta()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();

                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "ELIMINAR_VENTA";
                cmm.Parameters.AddWithValue("@ID_VENTA", id_ventaM);
                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se elimino correctamente los datos de la venta");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar los datos de la venta" + ex);
            }
        }
    }
}
