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
    public class Clase_telefono_empleado : BASE_DE_DATOS.Conexion
    {
        private long id_telefono_empleado;
        private int numero_telefono_empleado;
        private long id_empleado_fk_telefono_empleado;

        public long id_telefono_empleadoM
        {
            get { return id_telefono_empleado; }
            set { id_telefono_empleado = value; }
        }

        public int numero_telefono_empleadoM
        {
            get { return numero_telefono_empleado; }
            set { numero_telefono_empleado = value; }
        } 

        public long id_empleado_fk_telefono_empleadoM
        {
            get { return id_empleado_fk_telefono_empleado; }
            set { id_empleado_fk_telefono_empleado = value; }
        }

        public void insertar_telefono_empleado()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();
                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "INSERTAR_TELEFONO_EMPLEADO";
                cmm.Parameters.AddWithValue("@ID_TELEFONO", id_telefono_empleadoM);
                cmm.Parameters.AddWithValue("@NUMERO", numero_telefono_empleadoM);
                cmm.Parameters.AddWithValue("@ID_EMPLEADO_FK_TELEFONO", id_empleado_fk_telefono_empleadoM);

                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se ha insertado un nuevo telefono de un empleado");
            }
            catch (Exception)
            {
                MessageBox.Show("error al insertar un nuevo telefono de un empleado");
            }
        }

        public void Consultageneral_tel_empleado(ref DataGridView grilla)
        {
            conectar();
            string nombreprocedimiento;

            nombreprocedimiento = "CONSULTA_GENERAL_TELEFONO_EMPLEADO";
            SqlDataAdapter da = new SqlDataAdapter(nombreprocedimiento, con);
            DataSet dset = new DataSet();
            da.Fill(dset, nombreprocedimiento);
            grilla.DataSource = dset;
            grilla.DataMember = nombreprocedimiento;
            DESCONECTAR();
        }

        public void actualizar_telefono_empleado()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();

                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "ACTUALIZAR_TELEFONO_EMPLEADO";
                cmm.Parameters.AddWithValue("@ID_TELEFONO", id_telefono_empleadoM);
                cmm.Parameters.AddWithValue("@NUMERO", numero_telefono_empleadoM);
                cmm.Parameters.AddWithValue("@ID_EMPLEADO_FK_TELEFONO", id_empleado_fk_telefono_empleadoM);
                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se actualizo correctamente los datos del telefono del empleado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar los datos del telefono del empleado");
            }
        }

        public void eliminar_telefono_empleado()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();

                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "ELIMINAR_TELEFONO_EMPLEADO";
                cmm.Parameters.AddWithValue("@ID_TELEFONO", id_telefono_empleadoM);
                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se elimino correctamente los datos del telefono del empleado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar los datos del telefono del empleado" + ex);
            }
        }
    }
}
