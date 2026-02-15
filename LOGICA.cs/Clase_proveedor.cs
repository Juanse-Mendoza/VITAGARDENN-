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
    public class Clase_proveedor:BASE_DE_DATOS.Conexion
    {
        private long id_proveedor;
        private string nombre_proveedor;
        private float valor_proveedor;
        private string ciudad_proveedor;
        private string direccion_proveedor;
        private string estado_proveedor;
        private long id_empleado_fk_proveedor;

        public long id_proveedorM
        {
            get { return id_proveedor; }
            set { id_proveedor = value; }
        }

        public string nombre_proveedorM
        {
            get { return nombre_proveedor; }
            set { nombre_proveedor = value; }
        }

        public float valor_proveedorM
        {
            get { return valor_proveedor; }
            set { valor_proveedor = value; }
        }
        public string ciudad_proveedorM
        {
            get { return ciudad_proveedor; }
            set { ciudad_proveedor = value; }
        }

        public string direccion_proveedorM
        {
            get { return direccion_proveedor; }
            set { direccion_proveedor = value; }
        }

        public string estado_proveedorM
        {
            get { return estado_proveedor; }
            set { estado_proveedor = value; }
        }
        public long id_empleado_fk_proveedorM
        {
            get { return id_empleado_fk_proveedor; }
            set { id_empleado_fk_proveedor = value; }
        }

        public void insertar_proveedor()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();
                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "INSERTAR_PROVEEDOR";
                cmm.Parameters.AddWithValue("@ID_PROVEEDOR", id_proveedorM);
                cmm.Parameters.AddWithValue("@NOMBRE", nombre_proveedorM);
                cmm.Parameters.AddWithValue("@VALOR", valor_proveedorM);
                cmm.Parameters.AddWithValue("@CIUDAD", ciudad_proveedorM);
                cmm.Parameters.AddWithValue("@DIRECCION", direccion_proveedorM);
                cmm.Parameters.AddWithValue("@ESTADO", estado_proveedorM);
                cmm.Parameters.AddWithValue("@ID_EMPLEADO_FK_PROVEEDOR", id_empleado_fk_proveedorM);

                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se ha insertado un nuevo proveedor");
            }
            catch (Exception)
            {
                MessageBox.Show("error al insertar un nuevo proveedor");
            }
        }

        public void Consultageneral_proveedor(ref DataGridView grilla)
        {
            conectar();
            string nombreprocedimiento;

            nombreprocedimiento = "CONSULTA_GENERAL_PROVEEDOR";
            SqlDataAdapter da = new SqlDataAdapter(nombreprocedimiento, con);
            DataSet dset = new DataSet();
            da.Fill(dset, nombreprocedimiento);
            grilla.DataSource = dset;
            grilla.DataMember = nombreprocedimiento;
            DESCONECTAR();
        }

        public void actualizar_proveedor()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();

                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "ACTUALIZAR_PROVEEDOR";
                cmm.Parameters.AddWithValue("@ID_PROVEEDOR", id_proveedorM);
                cmm.Parameters.AddWithValue("@NOMBRE", nombre_proveedorM);
                cmm.Parameters.AddWithValue("@VALOR", valor_proveedorM);
                cmm.Parameters.AddWithValue("@CIUDAD", ciudad_proveedorM);
                cmm.Parameters.AddWithValue("@DIRECCION", direccion_proveedorM);
                cmm.Parameters.AddWithValue("@ESTADO", estado_proveedorM);
                cmm.Parameters.AddWithValue("@ID_EMPLEADO_FK_PROVEEDOR", id_empleado_fk_proveedorM);
                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se actualizo correctamente los datos del proveedor");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar los datos del proveedor");
            }
        }

        public void eliminar_proveedor()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();

                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "ELIMINAR_PROVEEDOR";
                cmm.Parameters.AddWithValue("@ID_PROVEEDOR", id_proveedorM);
                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se elimino correctamente los datos del proveedor");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar los datos del proveedor" + ex);
            }
        }
    }
}
