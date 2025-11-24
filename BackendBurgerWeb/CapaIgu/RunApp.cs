using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using Microsoft.Data.SqlClient;

namespace CapaIgu
{
    public partial class RunApp : Form
    {
        public RunApp()
        {
            InitializeComponent();
        }

        private void RunApp_Load(object sender, EventArgs e)
        {

            Conexion conexion = new Conexion();

            using (SqlConnection runConexion = conexion.ObtenerCadenaDeConexion())
            {
                try
                {
                    runConexion.Open();
                    Debug.WriteLine("[****CapaIgu****].[OK].[Conexion Exitosa A dbBurgerWeb]");
                    Console.WriteLine("[****CapaIgu****].[OK].[Conexion Exitosa A dbBurgerWeb]");
                }
                catch(Exception ex)
                {
                    Debug.WriteLine("[----CapaIgu----].[ERROR].[No Se Conecta A dbBurgerWeb].[cs Vacia]" + ex.Message);
                    Console.WriteLine("[----CapaIgu----].[ERROR].[No Se Conecta A dbBurgerWeb].[cs Vacia]" + ex.Message);
                }
            }


        }
    }
}
