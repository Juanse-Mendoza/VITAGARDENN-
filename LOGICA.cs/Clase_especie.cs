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
    public class Clase_especie:BASE_DE_DATOS.Conexion
    {
        private long id_especie;
        private string nombre_especie;
        private string estado_especie;

        public long id_especieM
        {
            get { return id_especie; }
            set { id_especie = value; }
        }

        public string nombre_especieM
        {
            get { return nombre_especie; }
            set { nombre_especie = value; }
        }

        public string estado_especieM
        {
            get { return estado_especie; }
            set { estado_especie = value; }
        }

        public void insertar_especie()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();
                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "INSERTAR_ESPECIE";
                cmm.Parameters.AddWithValue("@ID_ESPECIE", id_especieM);
                cmm.Parameters.AddWithValue("@NOMBRE", nombre_especieM);
                cmm.Parameters.AddWithValue("@ESTADO", estado_especieM);

                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se ha insertado una nueva especie");
            }
            catch (Exception)
            {
                MessageBox.Show("error al insertar la nueva especie");
            }
        }

        public void Consultageneral_especie(ref DataGridView grilla)
        {
            conectar();
            string nombreprocedimiento;

            nombreprocedimiento = "CONSULTA_GENERAL_ESPECIE";
            SqlDataAdapter da = new SqlDataAdapter(nombreprocedimiento, con);
            DataSet dset = new DataSet();
            da.Fill(dset, nombreprocedimiento);
            grilla.DataSource = dset;
            grilla.DataMember = nombreprocedimiento;
            DESCONECTAR();
        }

        public void actualizar_especie()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();

                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "ACTUALIZAR_ESPECIE";
                cmm.Parameters.AddWithValue("@ID_ESPECIE", id_especieM);
                cmm.Parameters.AddWithValue("@NOMBRE", nombre_especieM);
                cmm.Parameters.AddWithValue("@ESTADO", estado_especieM);
                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se actualizo correctamente los datos de la especie");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar los datos de la especie");
            }
        }

        public void eliminar_especie()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();

                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "ELIMINAR_ESPECIE";
                cmm.Parameters.AddWithValue("@ID_ESPECIE", id_especieM);
                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se elimino correctamente los datos de la especie");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar los datos de la especie" + ex);
            }
        }
    }
}
