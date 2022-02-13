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

namespace Proyecto_1
{
    public partial class Login : Form
    {
        SqlConnection conexion = new SqlConnection("server=DESKTOP-6NJDFKT\\SQLEXPRESS; database= Proyecto_1; integrated security = true");
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string query = "select * from Usuarios where Usuario = @user and Pass= @pass";
            SqlCommand command = new SqlCommand(query,conexion);
            command.Parameters.AddWithValue("@user", txtUser.Text);
            command.Parameters.AddWithValue("@pass", txtPass.Text);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                MessageBox.Show("Login Exitoso");
                Menu mostrar = new Menu();
                mostrar.Show();
                this.Hide();
                conexion.Close();
            }
            else
            {
                MessageBox.Show("Error al iniciar seccion");
                conexion.Close();
            }
            


         }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lblAgregarUsuario_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registrar view = new Registrar();
            view.Show();
        }
    }
}
