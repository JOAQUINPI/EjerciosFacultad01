using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faculta01.Entidades
{
    public class Bedel : Empleado
    {
        //ATRIBUTOS
        private string _apodo;

        //PROPIEDADES
        public string Apodo { get => _apodo; set => _apodo = value; }

    }
}
