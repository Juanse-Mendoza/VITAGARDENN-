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
    public class Clase_marca:BASE_DE_DATOS.Conexion
    {
        private long id_marca;
        private string nombre_marca;
        private long id_producto_fk_marca;

        public long id_marcaM
        {
            get { return id_marca; }
            set { id_marca = value; }
        }

        public string nombre_marcaM
        {
            get { return nombre_marca;}
            set { nombre_marca = value; }
        }

        public long id_producto_fk_marcaM
        {
            get { return id_producto_fk_marca; }
            set { id_producto_fk_marca = value; }
        }

        public void insertar_marca()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();
                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "INSERTAR_MARCA";
                cmm.Parameters.AddWithValue("@ID_MARCA", id_marcaM);
                cmm.Parameters.AddWithValue("@NOMBRE", nombre_marcaM);
                cmm.Parameters.AddWithValue("@ID_PRODUCTO_FK_MARCA", id_producto_fk_marcaM);

                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se ha insertado una nueva marca");
            }
            catch (Exception)
            {
                MessageBox.Show("error al insertar la nueva marca");
            }
        }

        public void Consultageneral_marca(ref DataGridView grilla)
        {
            conectar();
            string nombreprocedimiento;

            nombreprocedimiento = "CONSULTA_GENERAL_MARCA";
            SqlDataAdapter da = new SqlDataAdapter(nombreprocedimiento, con);
            DataSet dset = new DataSet();
            da.Fill(dset, nombreprocedimiento);
            grilla.DataSource = dset;
            grilla.DataMember = nombreprocedimiento;
            DESCONECTAR();
        }

        public void actualizar_marca()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();

                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "ACTUALIZAR_MARCA";
                cmm.Parameters.AddWithValue("@ID_MARCA", id_marcaM);
                cmm.Parameters.AddWithValue("@NOMBRE", nombre_marcaM);
                cmm.Parameters.AddWithValue("@ID_PRODUCTO_FK_MARCA", id_producto_fk_marcaM);
                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se actualizo correctamente los datos de la marca");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar los datos de la marca");
            }
        }

        public void eliminar_marca()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();

                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "ACTUALIZAR_MARCA";
                cmm.Parameters.AddWithValue("@ID_MARCA", id_marcaM);
                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se elimino correctamente los datos de la marca");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar los datos de la marca" + ex);
            }
        }
    }
}
