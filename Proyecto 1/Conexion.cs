using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_1
{
    internal class Conexion
    {
        
        SqlConnection conexion = new SqlConnection("server=DESKTOP-6NJDFKT\\SQLEXPRESS; database= Proyecto_1; integrated security = true");



        public void conectando()
        {
            try
            {
                conexion.Open();
                MessageBox.Show("se conecto");
                conexion.Close();
                MessageBox.Show("se cerro");
            }
            catch 
            {
                MessageBox.Show("no se conecto");
            }
        }

    }


}
