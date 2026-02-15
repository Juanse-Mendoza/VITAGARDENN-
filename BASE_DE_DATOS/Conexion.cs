using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BASE_DE_DATOS
{
    public class Conexion
    {
        static SqlDataAdapter adaptador = new SqlDataAdapter();
        public SqlConnection con = new SqlConnection();
        public SqlCommand comando = new SqlCommand();

        private string consultaSQL;

        private string cadena_conexion = ("Data source=LAPTOP-OSVBLMDC; Initial Catalog=VITAGARDENN_1;Integrated Security=true");

        public void Set_Consultar_sql(string consulta)
        {
            consultaSQL = consulta;
        }

        public void insertar_datos()
        {
            try
            {
                comando = new SqlCommand(consultaSQL, con);
                comando.ExecuteNonQuery();
            }
            catch (System.IO.IOException ex)
            {
                MessageBox.Show("Error al conectar a la Base de datos");
                MessageBox.Show(ex.Message);
            }
        }

        public bool conectar()
        {
            bool Estado = true;
            try
            {
                con.ConnectionString = cadena_conexion;
                con.Open();
            }
            catch
            {
                Estado = false;
                MessageBox.Show("ERROR AL CONECTAR AL SERVIDOR");
            }
            return Estado;
        }

        public void DESCONECTAR()
        {
            con.Close();
        }

        public SqlCommand Get_command()
        {
            return comando = new SqlCommand(consultaSQL, con);
        }

    }
}
