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
    public class Clase_telefono_proveedor:BASE_DE_DATOS.Conexion
    {
        private long id_telefono_proveedor;
        private int numero_telefono_proveedor;
        private long id_proveedor_fk_telefono_proveedor;

        public long id_telefono_proveedorM
        {
            get { return id_telefono_proveedor; }
            set { id_telefono_proveedor = value; }
        }

        public int numero_telefono_proveedorM
        {
            get { return numero_telefono_proveedor; }
            set { numero_telefono_proveedor = value; }
        }

        public long id_proveedor_fk_telefono_proveedorM
        {
            get { return id_proveedor_fk_telefono_proveedor; }
            set { id_proveedor_fk_telefono_proveedor = value;}
        }

        public void insertar_telefono_proveedor()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();
                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "INSERTAR_TELEFONO_PROVEEDOR";
                cmm.Parameters.AddWithValue("@ID_TELEFONO", id_telefono_proveedorM);
                cmm.Parameters.AddWithValue("@NUMERO", numero_telefono_proveedorM);
                cmm.Parameters.AddWithValue("@ID_PROVEEDOR_FK_TELEFONO", id_proveedor_fk_telefono_proveedorM);

                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se ha insertado un nuevo telefono de proveedor");
            }
            catch (Exception)
            {
                MessageBox.Show("error al insertar el nuevo telefono de proveedor");
            }
        }

        public void Consultageneral_tel_proveedor(ref DataGridView grilla)
        {
            conectar();
            string nombreprocedimiento;

            nombreprocedimiento = "CONSULTA_GENERAL_TELEFONO_PROVEEDOR ";
            SqlDataAdapter da = new SqlDataAdapter(nombreprocedimiento, con);
            DataSet dset = new DataSet();
            da.Fill(dset, nombreprocedimiento);
            grilla.DataSource = dset;
            grilla.DataMember = nombreprocedimiento;
            DESCONECTAR();
        }

        public void actualizar_telefono_proveedor()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();

                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "ACTUALIZAR_TELEFONO_PROVEEDOR";
                cmm.Parameters.AddWithValue("@ID_TELEFONO", id_telefono_proveedorM);
                cmm.Parameters.AddWithValue("@NUMERO", numero_telefono_proveedorM);
                cmm.Parameters.AddWithValue("@ID_PROVEEDOR_FK_TELEFONO", id_proveedor_fk_telefono_proveedorM);
                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se actualizo correctamente los datos del telefono del proveedor");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar los datos del telefono del proveedor");
            }
        }

        public void eliminar_telefono_proveedor()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();

                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "ELIMINAR_TELEFONO_PROVEEDOR";
                cmm.Parameters.AddWithValue("@ID_TELEFONO", id_telefono_proveedorM);
                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se elimino correctamente los datos del telefono del proveedor");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar los datos del telefono del proveedor" + ex);
            }
        }
    }
}
