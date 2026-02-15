using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BASE_DE_DATOS;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Security.Policy;

namespace LOGICA
{
    public class Clase_planta:BASE_DE_DATOS.Conexion
    {
        private long id_planta;
        private string nombre_planta;
        private float valor_planta;
        private int cantidad_planta;
        private string estado_planta;
        private long id_especie_fk_planta;
        private long id_empleado_fk_planta;

        public long id_plantaM
        {
            get { return id_planta; }
            set { id_planta = value; }
        }

        public string nombre_plantaM
        {
            get { return nombre_planta;}
            set { nombre_planta = value; }
        }

        public float valor_plantaM
        {
            get { return valor_planta; }
            set { valor_planta = value; }
        }

        public int cantidad_plantaM
        {
            get { return cantidad_planta; }
            set { cantidad_planta = value; }
        }

        public string estado_plantaM
        {
            get { return estado_planta; }
            set { estado_planta = value; }
        }

        public long id_especie_fk_plantaM
        {
            get { return id_especie_fk_planta; }
            set { id_especie_fk_planta = value; }
        }
        public long id_empleado_fk_plantaM
        {
            get { return id_empleado_fk_planta; }
            set { id_empleado_fk_planta = value; }
        }

        public void insertar_planta()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();
                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "INSERTAR_PLANTA";
                cmm.Parameters.AddWithValue("@ID_PLANTA", id_plantaM);
                cmm.Parameters.AddWithValue("@NOMBRE", nombre_plantaM);
                cmm.Parameters.AddWithValue("@VALOR", valor_plantaM);
                cmm.Parameters.AddWithValue("@CANTIDAD", cantidad_plantaM);
                cmm.Parameters.AddWithValue("@ESTADO", estado_plantaM);
                cmm.Parameters.AddWithValue("@ID_ESPECIE_FK_PLANTA", id_especie_fk_plantaM);
                cmm.Parameters.AddWithValue("@ID_EMPLEADO_FK_PLANTA", id_empleado_fk_plantaM);

                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se ha insertado una nueva planta");
            }
            catch (Exception)
            {
                MessageBox.Show("error al insertar la planta");
            }
        }

        public void Consultageneral_planta(ref DataGridView grilla)
        {
            conectar();
            string nombreprocedimiento;

            nombreprocedimiento = "CONSULTA_GENERAL_PLANTA";
            SqlDataAdapter da = new SqlDataAdapter(nombreprocedimiento, con);
            DataSet dset = new DataSet();
            da.Fill(dset, nombreprocedimiento);
            grilla.DataSource = dset;
            grilla.DataMember = nombreprocedimiento;
            DESCONECTAR();
        }

        public void actualizar_planta()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();

                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "ACTUALIZAR_PLANTA";
                cmm.Parameters.AddWithValue("@ID_PLANTA", id_plantaM);
                cmm.Parameters.AddWithValue("@NOMBRE", nombre_plantaM);
                cmm.Parameters.AddWithValue("@VALOR", valor_plantaM);
                cmm.Parameters.AddWithValue("@CANTIDAD", cantidad_plantaM);
                cmm.Parameters.AddWithValue("@ESTADO", estado_plantaM);
                cmm.Parameters.AddWithValue("@ID_ESPECIE_FK_PLANTA", id_especie_fk_plantaM);
                cmm.Parameters.AddWithValue("@ID_EMPLEADO_FK_PLANTA", id_empleado_fk_plantaM);
                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se actualizo correctamente los datos de la planta");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar los datos de la planta");
            }
        }

        public void eliminar_planta()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();

                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "ELIMINAR_PLANTA";
                cmm.Parameters.AddWithValue("@ID_PLANTA", id_plantaM);
                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se elimino correctamente los datos de la planta");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar los datos de la planta" + ex);
            }
        }
    }
}
