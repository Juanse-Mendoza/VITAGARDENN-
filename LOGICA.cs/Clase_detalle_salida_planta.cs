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
    public class Clase_detalle_salida_planta:BASE_DE_DATOS.Conexion
    {
        private string observaciones;
        private int cantidad;
        private long id_planta_fk_salida_planta;
        private long id_salida_inventario_fk_salida_planta;

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
        public long id_planta_fk_salida_plantaM
        {
            get { return id_planta_fk_salida_planta; }
            set { id_planta_fk_salida_planta = value; }
        }

        public long id_salida_inventario_fk_salida_plantaM
        { 
            get { return id_salida_inventario_fk_salida_planta; }
            set { id_salida_inventario_fk_salida_planta = value; }
        }

        public void insertar_salida_planta()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();
                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "INSERTAR_SALIDA_PLANTA";
                cmm.Parameters.AddWithValue("@OBSERVACIONES", observacionesM);
                cmm.Parameters.AddWithValue("@CANTIDAD", cantidadM);
                cmm.Parameters.AddWithValue("@ID_PLANTA_FK_SALIDA_PLANTA", id_planta_fk_salida_plantaM);
                cmm.Parameters.AddWithValue("@ID_SALIDA_INVENTARIO_FK_SALIDA_PLANTA", id_salida_inventario_fk_salida_plantaM);

                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se ha insertado una nueva salida de una planta");
            }
            catch (Exception)
            {
                MessageBox.Show("error al insertar la nueva salida de la planta");
            }
        }

        public void Consultageneral_salida_planta(ref DataGridView grilla)
        {
            conectar();
            string nombreprocedimiento;

            nombreprocedimiento = "CONSULTA_GENERAL_SALIDA_PLANTA";
            SqlDataAdapter da = new SqlDataAdapter(nombreprocedimiento, con);
            DataSet dset = new DataSet();
            da.Fill(dset, nombreprocedimiento);
            grilla.DataSource = dset;
            grilla.DataMember = nombreprocedimiento;
            DESCONECTAR();
        }

        public void actualizar_salida_planta()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();

                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "ACTUALIZAR_SALIDA_PLANTA";
                cmm.Parameters.AddWithValue("@OBSERVACIONES", observacionesM);
                cmm.Parameters.AddWithValue("@CANTIDAD", cantidadM);
                cmm.Parameters.AddWithValue("@ID_PLANTA_FK_SALIDA_PLANTA", id_planta_fk_salida_plantaM);
                cmm.Parameters.AddWithValue("@ID_SALIDA_INVENTARIO_FK_SALIDA_PLANTA", id_salida_inventario_fk_salida_plantaM);
                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se actualizo correctamente los datos de la salida de la planta");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar los datos de la salida de la planta");
            }
        }

        public void eliminar_salida_planta()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();

                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "ELIMINAR_SALIDA_PLANTA";
                cmm.Parameters.AddWithValue("@ID_PLANTA_FK_SALIDA_PLANTA", id_planta_fk_salida_plantaM);
                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se elimino correctamente los datos de la salida de la planta");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar los datos de la salida de la planta" + ex);
            }
        }
    }
}
