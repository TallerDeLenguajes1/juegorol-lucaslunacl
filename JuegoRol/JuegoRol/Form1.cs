using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JuegoRol
{
    public partial class Form1 : Form
    {
        private List<personaje> ListaDePersonajes = new List<personaje>();
        public Form1()
        {
            InitializeComponent();
        }

        private void click_crear(object sender, EventArgs e)
        {

            personaje NuevoPesonaje = crearPersonaje();
            agregarALista(NuevoPesonaje);
        }

        private void agregarALista(personaje NuevoPersonaje)
        {
            ListaDePersonajes.Add(NuevoPersonaje);
        }
        public personaje crearPersonaje()
        {
            Random rand = new Random();
            personaje nuevoPersonaje = new personaje();
            nuevoPersonaje.Edad = rand.Next(0, 300);
            nuevoPersonaje.Velocidad = rand.Next(1, 11);
            nuevoPersonaje.Destreza = rand.Next(1, 6);
            nuevoPersonaje.Fuerza = rand.Next(1, 11);
            nuevoPersonaje.Nivel = rand.Next(1, 11);
            nuevoPersonaje.Armadura = rand.Next(1, 11);

            TipoDePersonaje auxiliar = TipoDePersonaje.Humano;
            if (Humano.Checked)
            {
                nuevoPersonaje.Tipo = TipoDePersonaje.Humano;
            }else if(Orco.Checked){
                nuevoPersonaje.Tipo = TipoDePersonaje.Orco;
            }else if (Hobbit.Checked)
            {
                nuevoPersonaje.Tipo = TipoDePersonaje.Hobbit;
            }else if (Elfo.Checked)
            {
                nuevoPersonaje.Tipo = TipoDePersonaje.Elfo;
            }

            personaje NuevaClaseDePersonaje = new personaje(nombre.Text, auxiliar, apodo.Text, fecnaci.Value);

            return nuevoPersonaje;
        }
    }
}
