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
    public class Clase_telefono_cliente:BASE_DE_DATOS.Conexion
    {
        private long id_telefono_cliente;
        private int numero_telefono_cliente;
        private long id_cliente_fk_telefono;

        public long id_telefono_clienteM
        {
            get { return id_telefono_cliente; }
            set { id_telefono_cliente = value; }
        }

        public int numero_telefono_clienteM
        {
            get { return numero_telefono_cliente; }
            set { numero_telefono_cliente = value; }
        }

        public long id_cliente_fk_telefonoM
        {
            get { return id_cliente_fk_telefono; }
            set { id_cliente_fk_telefono = value; }
        }

        public void insertar_telefono_cliente()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();
                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "INSERTAR_TELEFONO_CLIENTE";
                cmm.Parameters.AddWithValue("@ID_TELEFONO", id_telefono_clienteM);
                cmm.Parameters.AddWithValue("@NUMERO", numero_telefono_clienteM);
                cmm.Parameters.AddWithValue("@ID_CLIENTE_FK_TELEFONO", id_cliente_fk_telefonoM);

                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se ha insertado un nuevo telefono de cliente");
            }
            catch (Exception)
            {
                MessageBox.Show("error al insertar el nuevo telefono del cliente");
            }
        }

        public void Consultageneral_Tel_cliente(ref DataGridView grilla)
        {
            conectar();
            string nombreprocedimiento;

            nombreprocedimiento = "CONSULTA_GENERAL_TELEFONO_CLIENTE";
            SqlDataAdapter da = new SqlDataAdapter(nombreprocedimiento, con);
            DataSet dset = new DataSet();
            da.Fill(dset, nombreprocedimiento);
            grilla.DataSource = dset;
            grilla.DataMember = nombreprocedimiento;
            DESCONECTAR();
        }

        public void actualizar_telefono_cliente()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();

                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "ACTUALIZAR_TELEFONO_CLIENTE";
                cmm.Parameters.AddWithValue("@ID_TELEFONO", id_telefono_clienteM);
                cmm.Parameters.AddWithValue("@NUMERO", numero_telefono_clienteM);
                cmm.Parameters.AddWithValue("@ID_CLIENTE_FK_TELEFONO", id_cliente_fk_telefonoM);
                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se actualizo correctamente los datos del telefono del cliente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar los datos del telefono del cliente");
            }
        }

        public void eliminar_telefono_cliente()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();

                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "ELIMINAR_TELEFONO_CLIENTE";
                cmm.Parameters.AddWithValue("@ID_TELEFONO", id_telefono_clienteM);
                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se elimino correctamente los datos del telefono del cliente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar los datos del telefono del cliente" + ex);
            }
        }
    }
}
