using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Practica_FinalDCU
{
    public partial class Escuela : Form
    {
        public Escuela()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Conexion.Conectar();
            MessageBox.Show("CONEXION EXITOSA");

            dataGridView1.DataSource = llenar_grid();
        }

        public DataTable llenar_grid()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM ALUMNO";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            return dt;

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "INSERT INTO ALUMNO (CODIGO,NOMBRE,APELLIDO,DIRECCION,CORREO,TELEFONO) VALUES(@CODIGO,@NOMBRE,@APELLIDO,@DIRECCION,@CORREO,@TELEFONO)";
            SqlCommand cmd1 = new SqlCommand(insertar, Conexion.Conectar());
            cmd1.Parameters.AddWithValue("@CODIGO", textCodigo.Text);
            cmd1.Parameters.AddWithValue("@NOMBRE", textNombre.Text);
            cmd1.Parameters.AddWithValue("@APELLIDO", textApellido.Text);
            cmd1.Parameters.AddWithValue("@DIRECCION", textDireccion.Text);
            cmd1.Parameters.AddWithValue("@CORREO", textCorreo.Text);
            cmd1.Parameters.AddWithValue("@TELEFONO", textTelefono.Text);

            cmd1.ExecuteNonQuery();

            MessageBox.Show("LOS DATOS FUERON AGREGADOS CON EXITO");

            dataGridView1.DataSource = llenar_grid();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            String actualizar = "UPDATE ALUMNO SET CODIGO=@CODIGO, NOMBRE=@NOMBRE, APELLIDO=@APELLIDO, DIRECCION=@DIRECCION, CORREO=@CORREO, TELEFONO =@TELEFONO WHERE CODIGO=@CODIGO";
            SqlCommand cmd2 = new SqlCommand(actualizar, Conexion.Conectar());

            cmd2.Parameters.AddWithValue("@CODIGO", textCodigo.Text);
            cmd2.Parameters.AddWithValue("@NOMBRE", textNombre.Text);
            cmd2.Parameters.AddWithValue("@APELLIDO", textApellido.Text);
            cmd2.Parameters.AddWithValue("@DIRECCION", textDireccion.Text);
            cmd2.Parameters.AddWithValue("@CORREO", textCorreo.Text);
            cmd2.Parameters.AddWithValue("@TELEFONO", textTelefono.Text);


            cmd2.ExecuteNonQuery();

            MessageBox.Show("LOS DATOS SE HAN ACTUALIZADO CORRECTAMENTE");
            dataGridView1.DataSource = llenar_grid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                textCodigo.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textApellido.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textDireccion.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textCorreo.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textTelefono.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            }

            catch { }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            String eliminar = "DELETE FROM ALUMNO WHERE CODIGO = @CODIGO";
            SqlCommand cmd3 = new SqlCommand(eliminar, Conexion.Conectar());
            cmd3.Parameters.AddWithValue("@CODIGO", textCodigo.Text);

            cmd3.ExecuteNonQuery();

            MessageBox.Show("LOS DATOS HAN SIDO ELIMINADOS CORRECTAMENTE");

            dataGridView1.DataSource = llenar_grid();

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            textCodigo.Clear();
            textNombre.Clear();
            textApellido.Clear();
            textDireccion.Clear();
            textCorreo.Clear();
            textTelefono.Clear();
        }

        private void textTelefono_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
