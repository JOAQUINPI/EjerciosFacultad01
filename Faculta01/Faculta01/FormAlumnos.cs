using Faculta01.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faculta01
{
    public partial class FormAlumnos : Form
    {
        public FormAlumnos()
        {
            InitializeComponent();
        }

        private void FormAlumnos_Load(object sender, EventArgs e)
        {

        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            PersistenciaUtils persistenciaUtils = new PersistenciaUtils();
            List<String> listado = persistenciaUtils.LeerRegistro("alumnos.csv");

            foreach (String registro in listado)
            {
                Alumno alumno = new Alumno(registro);
                lstAlumnos.Items.Add(alumno);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            var itemSeleccionado = lstAlumnos.SelectedItems;
            Alumno alumno = (Alumno)itemSeleccionado[0];

            txtNombre.Text = alumno.Nombre;
            txtApellido.Text = alumno.Apellido;
            dtpFechaNacimiento.Value = alumno.FechaNac;
        }
    }
}
