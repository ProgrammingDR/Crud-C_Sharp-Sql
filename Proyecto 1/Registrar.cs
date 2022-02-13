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
    public partial class Registrar : Form
    {
        SqlConnection conexion = new SqlConnection("server=DESKTOP-6NJDFKT\\SQLEXPRESS; database= Proyecto_1; integrated security = true");
        public Registrar()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login view = new Login();
            view.Show();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                string query = "insert into Usuarios Values(@user,@pass)";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@user",txtUser.Text);
                comando.Parameters.AddWithValue("@pass", txtPass.Text);
                comando.ExecuteNonQuery();
                conexion.Close();
                MessageBox.Show("Se guardo");
                this.Hide();
                Login view = new Login();
                view.Show();
            }
            catch
            {
                MessageBox.Show("No se inserto");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
