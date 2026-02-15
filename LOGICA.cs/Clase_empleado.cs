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
    public class Clase_empleado:BASE_DE_DATOS.Conexion
    {
        private long id_empleado;
        private string nombre_empleado;
        private string email;
        private float salario;
        private string estado;

        public long id_empleadoM
        { 
            get { return id_empleado; }
            set { id_empleado = value; }
        }

        public string nombre_empleadoM
        {
            get { return nombre_empleado; }
            set { nombre_empleado = value; }
        }
        
        public string emailM
        {
            get { return email; }
            set { email = value; }
        }

        public float salarioM
        {
            get { return salario; }
            set { salario = value; }
        }

        public string estadoM
        {
            get { return estado; }
            set { estado = value; }
        }

        public void insertar_empleado()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();
                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "INSERTAR_EMPLEADO";
                cmm.Parameters.AddWithValue("@ID_EMPLEADO", id_empleadoM);
                cmm.Parameters.AddWithValue("@NOMBRE", nombre_empleadoM);
                cmm.Parameters.AddWithValue("@EMAIL", emailM);
                cmm.Parameters.AddWithValue("@SALARIO", salarioM);
                cmm.Parameters.AddWithValue("@ESTADO", estadoM);

                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se ha insertado un nuevo empleado");
            }
            catch (Exception)
            {
                MessageBox.Show("error al insertar el nuevo empleado");
            }
        }

        public void Consultageneral_empleado(ref DataGridView grilla)
        {
            conectar();
            string nombreprocedimiento;

            nombreprocedimiento = "CONSULTA_GENERAL_EMPLEADO";
            SqlDataAdapter da = new SqlDataAdapter(nombreprocedimiento, con);
            DataSet dset = new DataSet();
            da.Fill(dset, nombreprocedimiento);
            grilla.DataSource = dset;
            grilla.DataMember = nombreprocedimiento;
            DESCONECTAR();
        }

        public void actualizar_empleado()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();

                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "ACTUALIZAR_EMPLEADO";
                cmm.Parameters.AddWithValue("@ID_EMPLEADO", id_empleadoM);
                cmm.Parameters.AddWithValue("@NOMBRE", nombre_empleadoM);
                cmm.Parameters.AddWithValue("@EMAIL", emailM);
                cmm.Parameters.AddWithValue("@SALARIO", salarioM);
                cmm.Parameters.AddWithValue("@ESTADO", estadoM);

                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se actualizo correctamente los datos del empleado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar los datos del empleado");
            }
        }

        public void eliminar_empleado()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();

                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "ELIMINAR_EMPLEADO";
                cmm.Parameters.AddWithValue("@ID_EMPLEADO", id_empleadoM);
                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se elimino correctamente los datos del empleado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar los datos del empleado" + ex);
            }
        }
    }
}
