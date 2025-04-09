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
       
        private void btnSaludar_Click(object sender, EventArgs e)
        {

            // 1) Validaciones

            // 

            string usuarios = textNombre.Text;
            string contraseña = textContraseña.Text;

            string errores = "";

            errores += ValidarUsuario(usuarios);
            errores += ValidarContraseña(contraseña);


            if (!string.IsNullOrEmpty(errores))
            {
                MessageBox.Show(errores, "Errores");
                return; // 🚫 No continúa si hay errores
            }

            // ✅ Solo pasa acá si está todo bien
            this.Hide();
            FormMenu formMenu = new FormMenu();
            formMenu.ShowDialog();


            string archivo = "usuarios.csv";
            string usuarioInput = "admin1";
            string passwordInput = "Abc123";

            string[] lineas = File.ReadAllLines(archivo);

            foreach (string linea in lineas)
            {
                string[] partes = linea.Split('\t');
                string usuario = partes[0];
                string password = partes[1];
                DateTime fechaLogin = DateTime.Parse(partes[2]);
                DateTime fechaExpiracion = DateTime.Parse(partes[3]);

                if (usuario == usuarioInput && password == passwordInput)
                {
                    Console.WriteLine("✅ Login correcto");

                    // 1.4) Verificar si expiró la contraseña
                    if (DateTime.Now > fechaExpiracion)
                    {
                        Console.WriteLine("⚠️ La contraseña ha expirado. Debes cambiarla.");
                    }
                    else
                    {
                        Console.WriteLine("✅ La contraseña es válida.");
                    }

                    // 1.3) Cambiar la contraseña
                    Console.Write("Ingresa nueva contraseña: ");
                    string nuevaPassword = Console.ReadLine();

                    // Actualizar el archivo
                    partes[1] = nuevaPassword;
                    string nuevaLinea = string.Join("\t", partes);
                    File.WriteAllLines(archivo, new string[] { nuevaLinea });

                    Console.WriteLine("🔐 Contraseña actualizada.");
                    return;
                }
            }

            Console.WriteLine("❌ Usuario o contraseña incorrectos");
        }
            //  1.1) Validaciones de integridad de datos
            // 1.) Validaciones de negocio

            // 1.1) Longitud de usuario (mayor igual a 6)

            // 1.2) Longitud de password (mayor igual a 6)

            // 1.3) Primero Login? -> Cambio password

            // 1.4) Expira password?



            // 2) Redirigir


      
        private string ValidarUsuario(string usuario)
        {
            string error;

            if (string.IsNullOrEmpty(usuario))
            {
                error = "El campo de usuario no debe ser vacío.\n";
            }
            else if (usuario.Length < 6)
            {
                error = "El usuario debe tener una longitud de al menos 6 caracteres.\n";
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

        private void FormInicio_Load(object sender, EventArgs e)
        {

        }
    }

        





    
}

