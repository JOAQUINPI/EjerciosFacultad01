using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faculta01.Entidades
{
    public abstract class Empleado : Persona // con la herencia puedo acceder a las propiedades definidas por el padre
    {
        // ATRIBUTOS
        protected DateTime _fechaIngreso;
        protected int _legajo;


        // PROPIEDADES
        public DateTime FechaIngreso { get => _fechaIngreso; set => _fechaIngreso = value; }
        public int Legajo { get => _legajo; set => _legajo = value; }

        // PROPERTIES HEREDADAS
        public DateTime FechaNacimiento { get => FechaNac; set => FechaNac = value; }

        // PROPERTIES CUSTOM
        public int Antiguedad { get => (DateTime.Now - _fechaIngreso).Days / 365; }

        // METODOS
        protected override void GetCredencial() // Herencia es un contrato entre las clases padres y las clases hijo.....si no sobreEscribo el metodo, no estariamos cumpliendo el contrato.
        {
            // Solo la que se podria sobreEscribir para modificar el metodo seria la virtual, la que es solo void no.
            // Esta la marca porque es obligatoria implementarla dentro de la clase hijo...las otras no lo son.
        }
    }
}
