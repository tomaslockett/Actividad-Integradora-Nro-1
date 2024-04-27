using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_Integradora_Nro_1
{
    internal class Personas
    {
        public Personas(string PDni, string PNombre, string PApellido)
        {
            Dni = PDni;
            Nombre = PNombre;
            Apellido = PApellido;
        }
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        List<Auto> ListaAutosDueño = new List<Auto>();

        public List<Auto> ListaDeAutos()
        {
            List<Auto> Auxiliar = new List<Auto>();
            foreach (var item in ListaAutosDueño)
            {
                Auxiliar.Add(new Auto(item.Patente, item.Marca, item.Modelo, item.Año, item.Precio));
            }
            return Auxiliar;
        }

        public void EliminarLista(string Patente)
        {
            var Auto = ListaAutosDueño.Find(x => x.Patente.ToString() == Patente);
            if (Auto != null)
            {
                ListaAutosDueño.Remove(Auto);
            }

        }

        public void ModificarLista(string Patente, string Marca, string Modelo, string año, decimal precio)
        {
            var Auto = ListaAutosDueño.Find(x => x.Patente.ToString() == Patente);
            if (Auto != null)
            {
                Auto.Marca = Marca;
                Auto.Modelo = Modelo;
                Auto.Año = año;
                Auto.Precio = precio;
            }

        }
        public Auto AgregarAuto
        {
            set
            {
                ListaAutosDueño.Add(value);
            }
        }

        public int Cantidad_Autos
        {
            get
            {
                int Cantidad = 0;
                Cantidad = ListaAutosDueño.Count;
                return Cantidad;
            }
        }


    }
}
