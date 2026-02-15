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
    public class Clase_entrada_compra:BASE_DE_DATOS.Conexion
    {
        private long id_entrada_compra;
        private string fecha;
        private string estado;
        private long id_compra_fk_entrada_compra;
        private long id_empleado_fk_entrada_compra;

        public long id_entrada_compraM
        {
            get { return id_entrada_compra; }
            set { id_entrada_compra = value; }  
        }

        public string fechaM
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public string estadoM
        {
            get { return estado; }
            set { estado = value; }
        }

        public long id_compra_fk_entrada_compraM
        {
            get { return id_compra_fk_entrada_compra; }
            set { id_compra_fk_entrada_compra = value; }
        }

        public long id_empleado_fk_entrada_compraM
        {
            get { return id_empleado_fk_entrada_compra; }
            set { id_empleado_fk_entrada_compra = value; }
        }

        public void insertar_entrada_compra()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();
                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "INSERTAR_ENTRADA_COMPRA";
                cmm.Parameters.AddWithValue("@ID_ENTRADA_COMPRA", id_entrada_compraM);
                cmm.Parameters.AddWithValue("@FECHA", fechaM);
                cmm.Parameters.AddWithValue("@ESTADO", estadoM);
                cmm.Parameters.AddWithValue("@ID_COMPRA_FK_ENTRADA_COMPRA", id_compra_fk_entrada_compraM);
                cmm.Parameters.AddWithValue("@ID_EMPLEADO_FK_ENTRADA_COMPRA", id_empleado_fk_entrada_compraM);

                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se ha insertado una nueva entrada de compra");
            }
            catch (Exception)
            {
                MessageBox.Show("error al insertar la entrada de la compra");
            }
        }

        public void Consultageneral_entrada_compra(ref DataGridView grilla)
        {
            conectar();
            string nombreprocedimiento;

            nombreprocedimiento = "CONSULTA_GENERAL_ENTRADA_COMPRA";
            SqlDataAdapter da = new SqlDataAdapter(nombreprocedimiento, con);
            DataSet dset = new DataSet();
            da.Fill(dset, nombreprocedimiento);
            grilla.DataSource = dset;
            grilla.DataMember = nombreprocedimiento;
            DESCONECTAR();
        }

        public void actualizar_entrada_compra()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();

                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "ACTUALIZAR_ENTRADA_COMPRA";
                cmm.Parameters.AddWithValue("@ID_ENTRADA_COMPRA", id_entrada_compraM);
                cmm.Parameters.AddWithValue("@FECHA", fechaM);
                cmm.Parameters.AddWithValue("@ESTADO", estadoM);
                cmm.Parameters.AddWithValue("@ID_COMPRA_FK_ENTRADA_COMPRA", id_compra_fk_entrada_compraM);
                cmm.Parameters.AddWithValue("@ID_EMPLEADO_FK_ENTRADA_COMPRA", id_empleado_fk_entrada_compraM);
                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se actualizo correctamente los datos de la entrada de compra");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar los datos de la entrada de la compra");
            }
        }

        public void eliminar_entrada_compra()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();

                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "ELIMINAR_ENTRADA_COMPRA";
                cmm.Parameters.AddWithValue("@ID_ENTRADA_COMPRA", id_entrada_compraM);
                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se elimino correctamente los datos de la entrada de la compra");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar los datos de la entrada de la compra" + ex);
            }
        }
    }
}
