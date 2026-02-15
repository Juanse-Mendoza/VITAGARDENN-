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
    public class Clase_usuario:BASE_DE_DATOS.Conexion
    {
        private string nombre_usuario;
        private string contraseña_usuario;
        private long id_empleado_fk_usuario;

        public string nombre_usuarioM
        {
            get { return nombre_usuario; }
            set { nombre_usuario = value; } 
        }

        public string contraseña_usuarioM
        {
            get { return contraseña_usuario; }
            set { contraseña_usuario = value; }
        }

        public long id_empleado_fk_usuarioM
        {
            get { return id_empleado_fk_usuario; }
            set { id_empleado_fk_usuario = value; }
        }

        public void insertar_usuario()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();
                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "INSERTAR_USUARIO";
                cmm.Parameters.AddWithValue("@NOMBRE", nombre_usuarioM);
                cmm.Parameters.AddWithValue("@CONTRASEÑA", contraseña_usuarioM);
                cmm.Parameters.AddWithValue("@ID_EMPLEADO_FK_USUARIO", id_empleado_fk_usuarioM);

                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se ha insertado un nuevo usuario");
            }
            catch (Exception)
            {
                MessageBox.Show("error al insertar un nuevo usuario");
            }
        }

        public void Consultageneral_usuario(ref DataGridView grilla)
        {
            conectar();
            string nombreprocedimiento;

            nombreprocedimiento = "CONSULTA_GENERAL_USUARIO";
            SqlDataAdapter da = new SqlDataAdapter(nombreprocedimiento, con);
            DataSet dset = new DataSet();
            da.Fill(dset, nombreprocedimiento);
            grilla.DataSource = dset;
            grilla.DataMember = nombreprocedimiento;
            DESCONECTAR();
        }

        public void actualizar_usuario()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();

                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "ACTUALIZAR_USUARIO";
                cmm.Parameters.AddWithValue("@NOMBRE", nombre_usuarioM);
                cmm.Parameters.AddWithValue("@CONTRASEÑA", contraseña_usuarioM);
                cmm.Parameters.AddWithValue("@ID_EMPLEADO_FK_USUARIO", id_empleado_fk_usuarioM);
                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se actualizo correctamente los datos del usuario");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar los datos del usuario");
            }
        }

        public void eliminar_usuario()
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = con;
                conectar();

                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "ELIMINAR_USUARIO";
                cmm.Parameters.AddWithValue("@NOMBRE", nombre_usuarioM);
                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                DESCONECTAR();
                MessageBox.Show("Se elimino correctamente los datos del usuario");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar los datos del usuario" + ex);
            }
        }

        public void Datos_usuario(string NOMUSUARIO, string CONTRASEÑA)
        {
            this.nombre_usuarioM = NOMUSUARIO;
            this.contraseña_usuarioM = CONTRASEÑA;
        }


        public void validacion_usuario(ref TextBox user, ref TextBox password)
        {
            try
            {
                DESCONECTAR();
                SqlCommand cmm = new SqlCommand("CONSULTA_ESPECIFICA_USUARIO_3", con);
                cmm.Connection = con;
                conectar();
                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.Parameters.AddWithValue("@NOMBRE", nombre_usuarioM);
                cmm.Parameters.AddWithValue("@CONTRASEÑA", contraseña_usuarioM);
                SqlDataReader reader = cmm.ExecuteReader();
                reader.Close();
                SqlDataAdapter adapter = new SqlDataAdapter(cmm);
                DataTable DataTable = new DataTable();
                adapter.Fill(DataTable);
                DESCONECTAR();

                if (DataTable.Rows.Count > 0)
                {
                    MessageBox.Show("Bienvenido(a) " + nombre_usuarioM);
                    foreach (DataRow filas in DataTable.Rows)
                    {
                        user.Text = filas["NOMBRE"].ToString();
                        password.Text = filas["CONTRASEÑA"].ToString();
                    }

                }

                else
                {
                    MessageBox.Show("No se econtro este usuario", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            catch (Exception e)

            {
                MessageBox.Show("ERROR AL REALIZAR LA CONSULTA" + e);
            }

        }

        public void validacion_usuario(ref string p1, ref string p2)
        {
            throw new NotImplementedException();

        }

        public void validacion_usuario()
        {
            throw new NotSupportedException();
        }
    }
}
