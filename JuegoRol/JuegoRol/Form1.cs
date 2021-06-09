using System;
using System.Windows.Forms;

namespace JuegoRol
{
    public partial class Form1 : Form
    {
        private List<personaje> ListaPersonajes = new List<personaje>();
        public Form1()
        {
            InitializeComponent();
        }

        private void click_crear(object sender, EventArgs e)
        {
            personaje NuevaClaseDePersonaje = new personaje();
            personaje NuevoPesonaje = NuevaClaseDePersonaje.crearPersonaje();
            agregarALista(NuevoPesonaje);
        }

        private void agregarALista(personaje NuevoPersonaje)
        {
            ListaPersonajes.Add(NuevoPersonaje);
        }
    }
}
