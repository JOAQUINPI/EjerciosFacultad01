using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faculta01
{
    public partial class FormInicio : Form
    {
        public FormInicio()
        {
            InitializeComponent();
        }
        public bool EsPrimerLogin { get; set; }
        public DateTime FechaUltimoCambioPassword { get; set; }
        private void btnSaludar_Click(object sender, EventArgs e)
        {

            // 1) Validaciones

            // 1.1) Validaciones de integridad de datos

            string usuario = textNombre.Text;
            string contraseña = textContraseña.Text;

            string errores = "";

            errores += ValidarUsuario(usuario);
            errores += ValidarContraseña(contraseña);
            errores += ValidarLogin(usuario);


            if (!string.IsNullOrEmpty(errores))
            {
                MessageBox.Show(errores, "Errores");
            }
            {
                this.Hide();
                FormMenu formMenu = new FormMenu();
                formMenu.ShowDialog();

            }

            // 1.) Validaciones de negocio

            // 1.1) Longitud de usuario (mayor igual a 6)

            // 1.2) Longitud de password (mayor igual a 6)

            // 1.3) Primero Login? -> Cambio password

            // 1.4) Expira password?



            // 2) Redirigir

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        //  private List<String> obtenerUsuarios()
        //  {
        // List<String> listado = persistenciaUtils.LeerRegistro("credenciales.csv");

        //   return listado;
        //  }
        private void FormInicio_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textNombre_TextChanged(object sender, EventArgs e)
        {

        }




        private string ValidarUsuario(string usuario)
        {
            string error;

            if (string.IsNullOrEmpty(usuario))
            {
                error = "El campo  no debe ser vacío." + System.Environment.NewLine;
            }
            else if (usuario.Length < 6)
            {
                error = "El isuario debe tener una longitud de 6 caracteres" + System.Environment.NewLine;
            }
            else
            {
                error = "";
            }

            return error;
        }

        private string ValidarContraseña(string contraseña)
        {
            string error;

            if (string.IsNullOrEmpty(contraseña))
            {
                error = "El campo  no debe ser vacío." + System.Environment.NewLine;
            }
            else if (contraseña.Length < 6)
            {
                error = "El la contraseña debe tener una longitud de 6 caracteres" + System.Environment.NewLine;
            }
            else if (!contraseña.Any(char.IsUpper))
            {
                error = "La contraseña debe contener al menos una letra mayúscula." + System.Environment.NewLine;
            }
            else if (!contraseña.Any(char.IsDigit))
            {
                error = "La contraseña debe contener al menos un número." + System.Environment.NewLine;
            }
            else
            {
                error = "";
            }
            return error;
        }

        private string ValidarLogin(string usuario)
        {
            string usuario = textNombre.Text;

            List<string> usuarios = ObtenerUsuarios(); // tu lista simulada o desde archivo

            foreach (Usuario usuario in usuarios)
            {
                if (usuario.Nombre != usuario)
                {
                    if (usuario.EsPrimerLogin)
                    {
                        MessageBox.Show("Es su primer ingreso. Ingrese nueva contraseña:");
                    }
                }
            }

            TimeSpan tiempo = DateTime.Now - usuario.FechaUltimoCambioPassword;
            if (tiempo.TotalDays > 90)
            {
                MessageBox.Show("Contraseña Expirada");

            }
            else
            {
                return "Login Exitoso";
            }
        }

                private void ObtenerUsuarios()
                {
                    string path = "C:\\Users\\maro_\\OneDrive\\Desktop\\Modelo 1\\Factura.txt";

                    StreamWriter sw = new StreamWriter(path);

                    foreach (usuario u in usuarios)
                    {
                        sw.WriteLine(u.ToCSV());
                    }

                    sw.Close();
                    MessageBox.Show("Se guardó correctamente el archivo de usuarios en: " + path + ".");
                }


    }

        





    }
}

