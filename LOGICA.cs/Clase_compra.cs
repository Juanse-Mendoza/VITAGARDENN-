using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using BASE_DE_DATOS;
using System.Data;

namespace LOGICA
{
    public class Clase_compra:BASE_DE_DATOS.Conexion
    {
        private long id_compra;
        private int cantidad_compra;
        private float valor;
        private string estado;
        private long id_empleado_fk_compra;
        private long id_proveedor_fk_compra;

        public long id_compraM
        {
            get { return id_compra; }
            set { id_compra = value; }  
        }

        public int cantidad_compraM
        {
            get { return cantidad_compra; }
            set { cantidad_compra = value; }
        }

        public float valor_compraM
        {
            get { return valor; }
            set { valor = value; }
        }

        public string estadoM
        {
            get { return estado; }
            set { estado = value; }
        }

        public long id_empleado_fk_compraM
        {
            get { return id_empleado_fk_compra; }
            set { id_empleado_fk_compra = value; }
        }

        public long id_proveedor_fk_compraM
        {
            get { return id_proveedor_fk_compra; }
            set { id_proveedor_fk_compra = value; }
        }

        public void insertar_compra()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();
                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "INSERTAR_COMPRA";
                cmm.Parameters.AddWithValue("@ID_COMPRA", id_compraM);
                cmm.Parameters.AddWithValue("@CANTIDAD", cantidad_compraM);
                cmm.Parameters.AddWithValue("@VALOR", valor_compraM);
                cmm.Parameters.AddWithValue("@ESTADO", estadoM);
                cmm.Parameters.AddWithValue("@ID_EMPLEADO_FK_COMPRA", id_empleado_fk_compraM);
                cmm.Parameters.AddWithValue("@ID_PROVEEDOR_FK_COMPRA", id_proveedor_fk_compraM);

                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se ha insertado una nueva compra");
            }
            catch (Exception)
            {
                MessageBox.Show("error al insertar la compra");
            }
        }

        public void Consultageneral_compra(ref DataGridView grilla)
        {
            conectar();
            string nombreprocedimiento;

            nombreprocedimiento = "CONSULTA_GENERAL_COMPRA";
            SqlDataAdapter da = new SqlDataAdapter(nombreprocedimiento, con);
            DataSet dset = new DataSet();
            da.Fill(dset, nombreprocedimiento);
            grilla.DataSource = dset;
            grilla.DataMember = nombreprocedimiento;
            DESCONECTAR();
        }

        public void actualizar_compra()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();

                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "ACTUALIZAR_COMPRA";
                cmm.Parameters.AddWithValue("@ID_COMPRA", id_compraM);
                cmm.Parameters.AddWithValue("@CANTIDAD", cantidad_compraM);
                cmm.Parameters.AddWithValue("@VALOR", valor_compraM);
                cmm.Parameters.AddWithValue("@ESTADO", estadoM);
                cmm.Parameters.AddWithValue("@ID_EMPLEADO_FK_COMPRA", id_empleado_fk_compraM);
                cmm.Parameters.AddWithValue("@ID_PROVEEDOR_FK_COMPRA", id_proveedor_fk_compraM);
                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se actualizo correctamente los datos de la compra");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar los datos de la compra");
            }
        }

        public void eliminar_compra()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();

                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "ELIMINAR_COMPRA";
                cmm.Parameters.AddWithValue("@ID_COMPRA", id_compraM);
                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se elimino correctamente los datos de la compra");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar los datos de la compra" + ex);
            }
        }
    }
}
