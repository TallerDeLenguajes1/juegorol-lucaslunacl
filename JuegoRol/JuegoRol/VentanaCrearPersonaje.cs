using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JuegoRol
{
    public partial class VentanaCrearPersonaje : Form
    {
        private List<Personaje> ListaDePersonajes = new List<Personaje>(); // LISTA DE PERSONAJES
        public VentanaCrearPersonaje()
        {
            InitializeComponent();
        }

        private void click_crear(object sender, EventArgs e)
        {

            Personaje NuevoPesonaje = crearPersonaje(); // CREANDO UN NUEVO PERSONAJE
            agregarALista(NuevoPesonaje);
            listbox_creados.Items.Add(Personaje.mostrarPersonaje(NuevoPesonaje)); // MOSTRAR PERSONAJES EN LISTBOX
            string datoCreado = "El personaje "+ NuevoPesonaje.Nombre + "fue agregado exitosamente";
            lbl_listapersonaje.Text= datoCreado;
            limpiarInput();
        }
        private void limpiarInput()
        {
            nombre.Clear();
            apodo.Clear();
        }
        private void agregarALista(Personaje NuevoPersonaje)
        {
            ListaDePersonajes.Add(NuevoPersonaje); // AGREGAR PERSONAJES CREADOS A MI LISTA
        }
        public Personaje crearPersonaje()
        {
            string nombrePersonaje = nombre.Text; //obtengo los valores de los inputs
            string apodoPersonaje = apodo.Text; //obtengo los valores de los inputs
            Random rand = new Random();
            Personaje nuevoPersonaje = new Personaje();
            nuevoPersonaje.Edad = rand.Next(0, 300); // VALOR ALEATORIO
            nuevoPersonaje.Velocidad = rand.Next(1, 11); // VALOR ALEATORIO
            nuevoPersonaje.Destreza = rand.Next(1, 6); // VALOR ALEATORIO
            nuevoPersonaje.Fuerza = rand.Next(1, 11); // VALOR ALEATORIO
            nuevoPersonaje.Nivel = rand.Next(1, 11); // VALOR ALEATORIO
            nuevoPersonaje.Armadura = rand.Next(1, 11); // VALOR ALEATORIO
            nuevoPersonaje.Nombre = nombrePersonaje; 
            nuevoPersonaje.Apodo = apodoPersonaje;
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

            
            return nuevoPersonaje;
        }

        private void btn_pelea_Click(object sender, EventArgs e)
        {
            if ( ListaDePersonajes.Count < 2) // controlo que la lista de personaje no tenga menos de 2 personajes
            {
                MessageBox.Show("Tenes menos de 2 personajes creados, por favor crea otro", "Error");
            }
            else
            {

            }
        }
    }
}
