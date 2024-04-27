using Microsoft.VisualBasic;
using System.Text.RegularExpressions;

namespace Actividad_Integradora_Nro_1
{
    public partial class Form1 : Form
    {
        List<Personas> ListaDePersonas = new List<Personas>();
        List<Auto> ListaDeAutos = new List<Auto>();

        public Form1()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ListaDeAutos.Add(new Auto("123456789", "Toyota", "Yaris", "2016", 200000));
            ListaDeAutos.Add(new Auto("758954158", "Ferrari", "F40", "1998", 286123));
            ListaDePersonas.Add(new Personas("987654321", "Tomas", "Lockett"));
            ListaDePersonas.Add(new Personas("753159846", "Pachu", "Soria"));
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ListaDePersonas;
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = ListaDeAutos;
            dataGridView2.Columns[6].Visible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string Patron = @"^[0-9]{8}";
                string Dni = textBox1.Text;
                if (!Regex.IsMatch(Dni, Patron)) 
                {
                    throw new Exception("No es un Dni");
                }
                string Nombre = textBox2.Text;
                if (!Regex.IsMatch(Nombre, @"[a-zA-Z]+$"))
                {
                    throw new Exception("No es un Nombre");
                }
                string Apellido = textBox3.Text;
                if (!Regex.IsMatch(Apellido, @"[a-zA-Z]+$"))
                {
                    throw new Exception("No es un Apellido");
                }
                ListaDePersonas.Add(new Personas(Dni, Nombre, Apellido));
                Actualizar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0)
                {
                    throw new Exception("No hay nada que modificar");
                }
                var DniAux = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                var PersonaModificado = ListaDePersonas.Find(x => x.Dni.ToString() == DniAux);

                if (PersonaModificado != null)
                {
                    PersonaModificado.Nombre = Interaction.InputBox("Nombre", "Nombre", PersonaModificado.Nombre);
                    PersonaModificado.Apellido = Interaction.InputBox("Apellido", "Apellido", PersonaModificado.Apellido);
                }
                Actualizar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0)
                {
                    throw new Exception("No hay nada que Eliminar");
                }
                var DniAux = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                var PersonaEliminado = ListaDePersonas.Find(x => x.Dni.ToString() == DniAux);

                if (PersonaEliminado != null)
                {
                    ListaDePersonas.Remove(PersonaEliminado);
                    PersonaEliminado = null;
                }

                Actualizar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string Patron = @"^[a-zA-Z]{3}[0-9]{3}";
                string Patente = (string)textBox4.Text;
                if (!Regex.IsMatch(Patente, Patron))
                {
                    throw new Exception("No es una patente");
                }
                string Marca = textBox5.Text;
                if (!Regex.IsMatch(Marca, @"[a-zA-Z]+$"))
                {
                    throw new Exception("No es una Marca");
                }
                string Modelo = (string)textBox6.Text;
                if (!Regex.IsMatch(Modelo, @"[a-zA-Z]+$"))
                {
                    throw new Exception("No es un Modelo");
                }
                string Año = (string)textBox7.Text;
                if (!Regex.IsMatch(Año, @"\d{4}$"))
                {
                    throw new Exception("No es un Año");
                }
                decimal Precio = Convert.ToDecimal(textBox8.Text);
                if (!Information.IsNumeric(Convert.ToInt16(Precio)))
                {
                    throw new Exception("No es un Numero");
                }
                ListaDeAutos.Add(new Auto(Patente, Marca, Modelo, Año, Precio));
                Actualizar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.Rows.Count == 0)
                {
                    throw new Exception("No hay nada que modificar");
                }
                var PatenteAux = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                var AutoModificado = ListaDeAutos.Find(x => x.Patente.ToString() == PatenteAux);

                if (AutoModificado != null)
                {
                    AutoModificado.Marca = Interaction.InputBox("Marca", "Marca", AutoModificado.Marca);
                    AutoModificado.Modelo = Interaction.InputBox("Modelo", "Modelo", AutoModificado.Modelo);
                    AutoModificado.Año = Interaction.InputBox("Año", "Año", AutoModificado.Año);
                    AutoModificado.Precio = Convert.ToDecimal(Interaction.InputBox("Precio", "Precio", AutoModificado.Precio.ToString()));

                }
                Actualizar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.Rows.Count == 0)
                {
                    throw new Exception("No hay nada que eliminar");
                }
                var PatenteAux = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                var AutoEliminado = ListaDeAutos.Find(x => x.Patente.ToString() == PatenteAux);

                if (AutoEliminado != null)
                {
                    ListaDeAutos.Remove(AutoEliminado);
                    var Dueño = AutoEliminado.Dueño;
                    if (PatenteAux != null)
                    {
                        Dueño.EliminarLista(PatenteAux);
                    }

                    AutoEliminado = null;

                }
                Actualizar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                var DniAux = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                var Persona = ListaDePersonas.Find(x => x.Dni.ToString() == DniAux);
                var PatenteAux = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                var Auto = ListaDeAutos.Find(x => x.Patente.ToString() == PatenteAux);

                if (Persona != null && Auto != null)
                {
                    if (Auto.Dueño == null)
                    {
                        Auto.Dueño = Persona;
                        Persona.AgregarAuto = Auto;
                    }
                    else
                    {
                        throw new Exception("Ya tiene dueño");
                    }
                }
                if (Persona != null)
                {
                    label11.Text = $"El valor total de los autos de:{Persona.Nombre}";

                }

                Actualizar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                var DniAux = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                var Persona = ListaDePersonas.Find(x => x.Dni.ToString() == DniAux);

                if (Persona != null)
                {
                    Decimal Preciofinal = 0;
                    var Lista = Persona.ListaDeAutos();
                    foreach ( var x in Lista)
                    {
                        Preciofinal += x.Precio;
                    }

                    label11.Text = $"El valor total de los autos de {Persona.Nombre} es de {Preciofinal}";


                    dataGridView3.DataSource = null;
                    dataGridView3.DataSource = Persona.ListaDeAutos();
                    dataGridView3.Columns[5].Visible = false;
                    dataGridView3.Columns[6].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Actualizar()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ListaDePersonas;

            dataGridView2.DataSource = null;
            dataGridView2.DataSource = ListaDeAutos;
            dataGridView2.Columns[6].Visible = false;

            var DniAux = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            var Persona = ListaDePersonas.Find(x => x.Dni.ToString() == DniAux);
            if (Persona != null)
            {
                dataGridView3.DataSource = null;
                dataGridView3.DataSource = Persona.ListaDeAutos();
                dataGridView3.Columns[5].Visible = false;
                dataGridView3.Columns[6].Visible = false;
            }

            dataGridView4.Rows.Clear();
            dataGridView4.Columns.Clear();
            dataGridView4.Columns.Add("Marca", "Marca");
            dataGridView4.Columns.Add("Año", "Año");
            dataGridView4.Columns.Add("Modelo", "Modelo");
            dataGridView4.Columns.Add("Patente", "Patente");
            dataGridView4.Columns.Add("Dni", "Dni");
            dataGridView4.Columns.Add("Apellido y Nombre", "Apellido y Nombre");
            foreach (var item in ListaDeAutos)
            {
                if (item.Dueño != null)
                {
                    string NombreYApellido = $"{item.Dueño.Apellido},{item.Dueño.Nombre}";
                    dataGridView4.Rows.Add(item.Marca, item.Año, item.Modelo, item.Patente, item.Dueño.Dni, NombreYApellido);
                }
            }


        }
    }
}
