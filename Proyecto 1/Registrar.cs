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
using System.Text.RegularExpressions;

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
                string usuario = txtUser.Text;
                string contrasena = txtPass.Text;

                if (!ValidarContrasena(contrasena))
                {
                    MessageBox.Show("La contraseña debe contener al menos una letra mayúscula, una letra minúscula, un carácter especial y un número.");
                    return;
                }

                string query = "INSERT INTO Usuarios VALUES (@user, @pass)";
                SqlCommand comando = new SqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@user", usuario);
                comando.Parameters.AddWithValue("@pass", contrasena);
                comando.ExecuteNonQuery();
                conexion.Close();
                MessageBox.Show("Se guardó correctamente.");
                this.Hide();
                Login view = new Login();
                view.Show();
            }
            catch
            {
                MessageBox.Show("No se inserto");
            }
        }

        private bool ValidarContrasena(string contrasena)
        {
            // Al menos una letra mayúscula
            if (!Regex.IsMatch(contrasena, @"[A-Z]"))
                return false;

            // Al menos una letra minúscula
            if (!Regex.IsMatch(contrasena, @"[a-z]"))
                return false;

            // Al menos un carácter especial
            if (!Regex.IsMatch(contrasena, @"[!@#$%^&*()_+=\[{\]};:<>|./?,-]"))
                return false;

            // Al menos un número
            if (!Regex.IsMatch(contrasena, @"\d"))
                return false;

            return true;
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
