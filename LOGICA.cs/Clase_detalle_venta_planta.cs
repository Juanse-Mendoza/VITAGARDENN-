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
    public class Clase_detalle_venta_planta:BASE_DE_DATOS.Conexion
    {
        private string observaciones_venta_planta;
        private int cantidad;
        private float subtotal;
        private long id_planta_fk_venta_planta;
        private long id_venta_fk_venta_planta;

        public string observaciones_venta_plantaM
        {
            get { return observaciones_venta_planta; }
            set { observaciones_venta_planta = value; }
        }

        public int cantidadM
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public float subtotalM
        {
            get { return subtotal; }
            set { subtotal = value; }
        }

        public long id_planta_fk_venta_plantaM
        {
            get { return id_planta_fk_venta_planta;}
            set { id_planta_fk_venta_planta = value; }        
        }

        public long id_venta_fk_venta_plantaM
        {
            get { return id_venta_fk_venta_planta; }
            set { id_venta_fk_venta_planta = value; }
        }

        public void insertar_venta_planta()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();
                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "INSERTAR_VENTA_PLANTA";
                cmm.Parameters.AddWithValue("@OBSERVACIONES", observaciones_venta_plantaM);
                cmm.Parameters.AddWithValue("@CANTIDAD", cantidadM);
                cmm.Parameters.AddWithValue("@SUBTOTAL", subtotalM);
                cmm.Parameters.AddWithValue("@ID_PLANTA_FK_VENTA_PLANTA", id_planta_fk_venta_plantaM);
                cmm.Parameters.AddWithValue("@ID_VENTA_FK_VENTA_PLANTA", id_venta_fk_venta_plantaM);

                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se ha insertado una nueva venta de una planta");
            }
            catch (Exception)
            {
                MessageBox.Show("error al insertar la venta de la planta");
            }
        }

        public void Consultageneral_venta_planta(ref DataGridView grilla)
        {
            conectar();
            string nombreprocedimiento;

            nombreprocedimiento = " CONSULTA_GENERAL_VENTA_PLANTA";
            SqlDataAdapter da = new SqlDataAdapter(nombreprocedimiento, con);
            DataSet dset = new DataSet();
            da.Fill(dset, nombreprocedimiento);
            grilla.DataSource = dset;
            grilla.DataMember = nombreprocedimiento;
            DESCONECTAR();
        }

        public void actualizar_venta_planta()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();

                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "ACTUALIZAR_VENTA_PLANTA";
                cmm.Parameters.AddWithValue("@OBSERVACIONES", observaciones_venta_plantaM);
                cmm.Parameters.AddWithValue("@CANTIDAD", cantidadM);
                cmm.Parameters.AddWithValue("@SUBTOTAL", subtotalM);
                cmm.Parameters.AddWithValue("@ID_PLANTA_FK_VENTA_PLANTA", id_planta_fk_venta_plantaM);
                cmm.Parameters.AddWithValue("@ID_VENTA_FK_VENTA_PLANTA", id_venta_fk_venta_plantaM);
                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se actualizo correctamente los datos de la venta de la planta");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar los datos de la venta de la planta");
            }
        }

        public void eliminar_venta_planta()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();

                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "ELIMINAR_VENTA_PLANTA";
                cmm.Parameters.AddWithValue("@ID_VENTA_FK_VENTA_PLANTA", id_venta_fk_venta_plantaM);
                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se elimino correctamente los datos de la venta de planta");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar los datos de la venta de la planta" + ex);
            }
        }
    }
}
