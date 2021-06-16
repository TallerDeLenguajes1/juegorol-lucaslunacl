using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JuegoRol
{
    public partial class VentanaCrearPersonaje : Form
    {
        private List<Personaje> ListaDePersonajes = new List<Personaje>();
        public VentanaCrearPersonaje()
        {
            InitializeComponent();
        }

        private void click_crear(object sender, EventArgs e)
        {

            Personaje NuevoPesonaje = crearPersonaje();
            agregarALista(NuevoPesonaje);
            listbox_creados.Items.Add(Personaje.mostrarPersonaje(NuevoPesonaje));
        }

        private void agregarALista(Personaje NuevoPersonaje)
        {
            ListaDePersonajes.Add(NuevoPersonaje);
        }
        public Personaje crearPersonaje()
        {
            Random rand = new Random();
            Personaje nuevoPersonaje = new Personaje();
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

            //personaje NuevaClaseDePersonaje = new personaje(nombre.Text, auxiliar, apodo.Text, fecnaci.Value);
            return nuevoPersonaje;
        }
        
    }
}
