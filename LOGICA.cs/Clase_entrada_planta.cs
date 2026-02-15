using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BASE_DE_DATOS;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Windows.Markup;

namespace LOGICA
{
    public class Clase_entrada_planta:BASE_DE_DATOS.Conexion
    {
        private string observaciones;
        private int cantidad;
        private long id_entrada_compra_fk_entrada_planta;
        private long id_planta_fk_entrada_planta;

        public string observacionesM
        {
            get { return observaciones; }
            set { observaciones = value; }
        }

        public int cantidadM
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public long id_entrada_compra_fk_entrada_plantaM
        {
            get { return id_entrada_compra_fk_entrada_planta; }
            set { id_entrada_compra_fk_entrada_planta = value; }
        }

        public long id_planta_fk_entrada_plantaM
        {
            get { return id_planta_fk_entrada_planta; }
            set { id_planta_fk_entrada_planta = value; }
        }

        public void insertar_entrada_planta()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();
                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "INSERTAR_ENTRADA_PLANTA";
                cmm.Parameters.AddWithValue("@OBSERVACIONES", observacionesM);
                cmm.Parameters.AddWithValue("@CANTIDAD", cantidadM);
                cmm.Parameters.AddWithValue("@ID_ENTRADA_COMPRA_FK_ENTRADA_PLANTA", id_entrada_compra_fk_entrada_plantaM);
                cmm.Parameters.AddWithValue("@ID_PLANTA_FK_ENTRADA_PLANTA", id_planta_fk_entrada_plantaM);

                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se ha insertado una nueva entrada de la planta");
            }
            catch (Exception)
            {
                MessageBox.Show("error al insertar la nueva entrada de la planta");
            }
        }

        public void Consultageneral_entrada_planta(ref DataGridView grilla)
        {
            conectar();
            string nombreprocedimiento;

            nombreprocedimiento = "CONSULTA_GENERAL_ENTRADA_PLANTA";
            SqlDataAdapter da = new SqlDataAdapter(nombreprocedimiento, con);
            DataSet dset = new DataSet();
            da.Fill(dset, nombreprocedimiento);
            grilla.DataSource = dset;
            grilla.DataMember = nombreprocedimiento;
            DESCONECTAR();
        }

        public void actualizar_entrada_planta()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();

                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "ACTUALIZAR_ENTRADA_PLANTA";
                cmm.Parameters.AddWithValue("@OBSERVACIONES", observacionesM);
                cmm.Parameters.AddWithValue("@CANTIDAD", cantidadM);
                cmm.Parameters.AddWithValue("@ID_ENTRADA_COMPRA_FK_ENTRADA_PLANTA", id_entrada_compra_fk_entrada_plantaM);
                cmm.Parameters.AddWithValue("@ID_PLANTA_FK_ENTRADA_PLANTA", id_planta_fk_entrada_plantaM);

                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se actualizo correctamente los datos de la entrada de la planta");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar los datos de la entrada de la planta");
            }
        }

        public void eliminar_entrada_planta()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();

                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "ELIMINAR_ENTRADA_PLANTA";
                cmm.Parameters.AddWithValue("@ID_ENTRADA_COMPRA_FK_ENTRADA_PLANTA", id_entrada_compra_fk_entrada_planta);
                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se elimino correctamente los datos de la entrada de la planta");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar los datos de la entrada de la planta" + ex);
            }
        }
    }
}
