using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.Json;
using static JuegoRol.ApiClima;
using System.Net;
using System.IO;

namespace JuegoRol
{
    public partial class VentanaCrearPersonaje : Form
    {
        private List<Personaje> ListaDePersonajes = new List<Personaje>(); // LISTA DE PERSONAJES
        public VentanaCrearPersonaje()
        {
            InitializeComponent();
            APIClima();
        }

        private void click_crear(object sender, EventArgs e)
        {

            Personaje NuevoPesonaje = crearPersonaje(); // CREANDO UN NUEVO PERSONAJE
            agregarALista(NuevoPesonaje);
            listbox_creados.Items.Add(Personaje.mostrarPersonaje(NuevoPesonaje)); // MOSTRAR PERSONAJES EN LISTBOX
            string datoCreado = "El personaje "+ NuevoPesonaje.Nombre + "Fue agregado exitosamente";
            lbl_listapersonaje.Text= datoCreado;
            limpiarInput();
            Console.Beep(); // sonido al agregar personaje
        }
        private void limpiarInput()
        {
            nombre.Clear();
            apodo.Clear();
        }
        public void APIClima()
        {
            var url = $"https://ws.smn.gob.ar/map_items/weather";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            List<API> listaDeClimas = JsonSerializer.Deserialize<List<API>>(responseBody);
                            foreach (var clima in listaDeClimas)
                            {
                                if (clima.Name == "San Miguel de Tucumán")
                                {
                                    string climaDesc = clima.Weather.Description;
                                    float tempClima = clima.Weather.Temp;
                                    switch (Verificar(climaDesc))
                                    {
                                        case 1:
                                            Clima_Temp.Text = tempClima.ToString() + " Grados";
                                            Clima_desc.Text = climaDesc;
                                            break;
                                        case 2:
                                            Clima_Temp.Text = tempClima.ToString() + " Grados";
                                            Clima_desc.Text = climaDesc;
                                            break;
                                        case 3:
                                            Clima_Temp.Text = tempClima.ToString() + " Grados";
                                            Clima_desc.Text = climaDesc;
                                            break;
                                        case 4:
                                            Clima_Temp.Text = tempClima.ToString() + " Grados";
                                            Clima_desc.Text = climaDesc;
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                string error = ex.ToString();
            }
        }
        public int Verificar(string descripcion)
        {
            string[] descClima = new string[14]
            {
               "Nublado", "Algo Nublado", "Algo nublado con bruma", "Algo nublado con humo", "Algo nublado con neblina"
        , "Cubierto", "Cubierto con neblina", "Cubierto con humo", "Cubierto con ventisca baja", "Parcialmente nublado", "Parcialmente nublado con nevlina", "Parcialmente nublado con bruma", "Parcialmente nublado con humo", "Despejado"
            };
            if (descripcion == descClima[0] || descripcion == descClima[1] || descripcion == descClima[2] || descripcion == descClima[3] || descripcion == descClima[4])
            {
                return 1; 
            }
            else if (descripcion == descClima[5] || descripcion == descClima[6] || descripcion == descClima[7] || descripcion == descClima[8])
            {
                return 2; 
            }
            else if (descripcion == descClima[9] || descripcion == descClima[10] || descripcion == descClima[11] || descripcion == descClima[12])
            {
                return 3;
            }
            else if (descripcion == descClima[12])
            {
                return 4; 
            }
            return 0;
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
                VentanaPelea Pelea = new VentanaPelea(ListaDePersonajes);
                Pelea.ShowDialog();
            }
        }
    }
}
