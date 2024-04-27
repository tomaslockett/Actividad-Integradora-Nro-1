using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_Integradora_Nro_1
{
    internal class Auto
    {
        public Auto(string PPatente, string PMarca, string PModelo, string PAño, decimal PPrecio)
        {
            Patente = PPatente;
            Marca = PMarca;
            Modelo = PModelo;
            Precio = PPrecio;
            Año = PAño;
        }
        public Auto(string PPatente, string PMarca, string PModelo, string PAño, decimal PPrecio,Personas PDueño) : this(PPatente,PMarca,PModelo,PAño,PPrecio)
        {
            dueño = PDueño;
        }


        public string Patente { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public decimal Precio { get; set; }
        public string Año { get; set; }

        private Personas dueño;

       

        public string QuienEsDueño
        {
            get
            {
                var dueñoaux = dueño;
                if (dueño != null)
                {
                    return dueñoaux.Nombre;
                }
                return string.Empty;
            }
        } 
        public Personas Dueño
        {
            set
            {
                dueño = value;
            }
            get
            {
                return dueño;
            }
        }
    }
}
