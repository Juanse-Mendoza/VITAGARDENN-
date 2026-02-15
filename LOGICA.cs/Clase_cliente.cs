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
    public class Clase_cliente:BASE_DE_DATOS.Conexion
    {
        private long id_cliente;
        private string email_cliente;
        private string nombre_cliente;
        private string estado_cliente;
        private long id_empleado_fk_cliente;

        public long id_clienteM
        {
            get { return id_cliente; }
            set { id_cliente = value; }
        }

        public string email_clienteM
        {
            get { return email_cliente; }
            set { email_cliente = value; }
        }

        public string nombre_clienteM
        {
            get { return nombre_cliente; }
            set { nombre_cliente = value; }
        }

        public string estado_clienteM
        {
            get { return estado_cliente; }
            set { estado_cliente = value; }
        }

        public long id_empleado_fk_clienteM
        {
            get { return id_empleado_fk_cliente; }
            set { id_empleado_fk_cliente = value; }
        }

        public void insertar_cliente()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();
                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "INSERTAR_CLIENTE";
                cmm.Parameters.AddWithValue("@ID_CLIENTE", id_clienteM);
                cmm.Parameters.AddWithValue("@EMAIL", email_clienteM);
                cmm.Parameters.AddWithValue("@NOMBRE", nombre_clienteM);
                cmm.Parameters.AddWithValue("@ESTADO", estado_clienteM);
                cmm.Parameters.AddWithValue("@ID_EMPLEADO_FK_CLIENTE", id_empleado_fk_clienteM);

                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se ha insertado un nuevo cliente");
            }
            catch (Exception)
            {
                MessageBox.Show("error al insertar el nuevo cliente");
            }
        }

        public void Consultageneral_cliente(ref DataGridView grilla)
        {
            conectar();
            string nombreprocedimiento;

            nombreprocedimiento = "CONSULTA_GENERAL_CLIENTE";
            SqlDataAdapter da = new SqlDataAdapter(nombreprocedimiento, con);
            DataSet dset = new DataSet();
            da.Fill(dset, nombreprocedimiento);
            grilla.DataSource = dset;
            grilla.DataMember = nombreprocedimiento;
            DESCONECTAR();
        }

        public void actualizar_cliente()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();

                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "ACTUALIZAR_CLIENTE";
                cmm.Parameters.AddWithValue("@ID_CLIENTE", id_clienteM);
                cmm.Parameters.AddWithValue("@EMAIL", email_clienteM);
                cmm.Parameters.AddWithValue("@NOMBRE", nombre_clienteM);
                cmm.Parameters.AddWithValue("@ESTADO", estado_clienteM);
                cmm.Parameters.AddWithValue("@ID_EMPLEADO_FK_CLIENTE", id_empleado_fk_clienteM);
                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se actualizo correctamente los datos del cliente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar los datos de la entrada del cliente");
            }
        }

        public void eliminar_cliente()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();

                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "ELIMINAR_CLIENTE";
                cmm.Parameters.AddWithValue("@ID_CLIENTE", id_clienteM);
                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se elimino correctamente los datos del cliente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar los datos del cliente" + ex);
            }
        }
    }
}
