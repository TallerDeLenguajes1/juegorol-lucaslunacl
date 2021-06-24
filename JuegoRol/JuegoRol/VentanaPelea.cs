using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Windows.Forms;
using static JuegoRol.ApiClima;

namespace JuegoRol
{
    public partial class VentanaPelea : Form
    {
        int player1, player2, cantAtaques;
        List<Personaje> ListaDePeleadores = new List<Personaje>();
        public VentanaPelea(List<Personaje> personajes)
        {

            InitializeComponent();
            ListaDePeleadores = personajes;
            CargarDatosDeLaPelea(personajes);
            APIClima();
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
                                            Clima_Temp.Text = tempClima.ToString() + " Grados" ;
                                            Clima_desc.Text = climaDesc;
                                            break;
                                        case 4:
                                            Clima_Temp.Text = tempClima.ToString() + " Grados" ;
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


        public void CargarDatosDeLaPelea(List<Personaje> luchadores)
        {
            Random rand = new Random();
            player1 = rand.Next(0, luchadores.Count); // seleccion random de personajes de la lista
            player2 = rand.Next(0, luchadores.Count); // seleccion random de personajes de la lista

            while (player2 == player1)
            {
                player2 = rand.Next(0, luchadores.Count);
            }

            // PLAYER 1
            lbl_nombreP1.Text = luchadores[player1].Nombre;
            lbl_SaludP1.Text = "Salud: " + luchadores[player1].Salud.ToString();
            lbl_VelocidadP1.Text = "Velocidad: " + luchadores[player1].Velocidad.ToString();
            lbl_fuerzaP1.Text = "Fuerza: " + luchadores[player1].Fuerza.ToString();
            lbl_NivelP1.Text = "Nivel: " + luchadores[player1].Nivel.ToString();
            lbl_DestrezaP1.Text = "Destreza: " + luchadores[player1].Destreza.ToString();
            lbl_ArmaduraP1.Text = "Armadura: " + luchadores[player1].Armadura.ToString();

            // PLAYER 2
            lbl_nombreP2.Text = luchadores[player1].Nombre;
            lbl_SaludP2.Text = "Salud: " + luchadores[player1].Salud.ToString();
            lbl_VelocidadP2.Text = "Velocidad: " + luchadores[player1].Velocidad.ToString();
            lbl_FuerzaP2.Text = "Fuerza: " + luchadores[player1].Fuerza.ToString();
            lbl_NivelP2.Text = "Nivel: " + luchadores[player1].Nivel.ToString();
            lbl_DestrezaP2.Text = "Destreza: " + luchadores[player1].Destreza.ToString();
            lbl_ArmaduraP2.Text = "Armadura: " + luchadores[player1].Armadura.ToString();
            btn_atacarP2.Enabled = false;
        }

        private int DanioDeAtaque(List<Personaje> luchadores, object sender)
        {
            // ED = EFECTIVIDAD DE DISPARO, PD = PODER DE DISPARO , VA = VALOR DE ATAQUE, PDEF = PODER DE DEFENSA, MPD = MAXIMO DAÑO PROVOCABLE
            Random rand2 = new Random();
            Button boton = (Button)sender;
            int ED, PD, VA, PDEF, MDP;
            ED = rand2.Next(1, 101); // RANDOM DE 1 A 100
            if (boton.Name == "btn_atacarP1")
            {
                PD = luchadores[player1].Destreza * luchadores[player1].Fuerza * luchadores[player1].Nivel;
                VA = PD * ED;
                PDEF = luchadores[player2].Armadura * luchadores[player2].Velocidad;
                MDP = 50000;
                int Total = (((VA * ED) - PDEF) / MDP) * rand2.Next(2, 5);
                return Total;
            }
            else
            {
                PD = luchadores[player2].Destreza * luchadores[player2].Fuerza * luchadores[player2].Nivel;
                VA = PD * ED;
                PDEF = luchadores[player1].Armadura * luchadores[player1].Velocidad;
                MDP = 50000;
                int Total = (((VA * ED) - PDEF) / MDP) * rand2.Next(2, 5);
                return Total;
            }

        }
        private void btn_atacar(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            if (boton.Equals(btn_atacarP1))
            {
                btn_atacarP1.Enabled = false;
                btn_atacarP2.Enabled = true;
            }
            else
            {
                btn_atacarP2.Enabled = false;
                btn_atacarP1.Enabled = true;
            }
            /*
            switch (boton.Name)
            {
                case "btn_atacarP1":
                    btn_atacarP1.Enabled = false;
                    btn_atacarP2.Enabled = true;
                    break;
                case "btn_atacarP2":
                    btn_atacarP2.Enabled = false;
                    btn_atacarP1.Enabled = true;
                    break;
            }*/
            int danioProvocado = DanioDeAtaque(ListaDePeleadores, sender);
            ataque(ListaDePeleadores, danioProvocado, sender);
        }
        private void ataque(List<Personaje> Peleadores, int danio, object sender)
        {
            Button boton = (Button)sender;
            if (boton.Equals(btn_atacarP1))
            {
                int nuevaSaludP2 = Peleadores[player2].Salud -= danio;
                if (nuevaSaludP2 < 0)
                { // Para que la vida no sea negativa
                    lbl_SaludP2.Text = "0";
                    Peleadores[player2].Salud = 0;
                    mostrarGanador(Peleadores);
                }
                else
                {
                    lbl_SaludP2.Text = nuevaSaludP2.ToString();
                }
            }
            else
            {
                cantAtaques++;
                int nuevaSaludP1 = Peleadores[player1].Salud -= danio;
                if (nuevaSaludP1 < 0)
                { // Para que la vida no sea negativa
                    lbl_SaludP1.Text = "0";
                    Peleadores[player1].Salud = 0;
                    mostrarGanador(Peleadores);
                }
                else
                {
                    lbl_SaludP1.Text = nuevaSaludP1.ToString();
                }
            }
            if (cantAtaques >= 3)
            {
                mostrarGanador(Peleadores);
            }
        }
      /*  public void MusicaGanador()
        {
            string path = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            path = path.Replace("\\bin", "");
            string ruta = path + "\\MusicaGanador\\Musica.wav";
            SoundPlayer musicaGanador = new SoundPlayer(ruta);
            musicaGanador.Play();

        }*/
        private void VentanaPelea_Load(object sender, EventArgs e)
        {

        }

        private void mostrarGanador(List<Personaje> Peleadores)
        {
            string Vencedor;
            if (Peleadores[player1].Salud > Peleadores[player2].Salud)
            {
                Vencedor = Peleadores[player1].Nombre + " (" + Peleadores[player1].Apodo + ")";
            }
            else if (Peleadores[player1].Salud < Peleadores[player2].Salud)
            {
                Vencedor = Peleadores[player2].Nombre + " (" + Peleadores[player2].Apodo + ")";
            }
            else
            {
                Vencedor = "EMPATE";
            }
            if (Vencedor == "EMPATE")
            {
                MessageBox.Show("EMPATE!", "Pelea");
            }
            else
            {
                MessageBox.Show("EL LUCHADOR " + Vencedor + " ES EL GANADOR", "Resultado de la Pelea");
            }
            ModificarPeleadores(Peleadores);
            //MusicaGanador();
            this.Close();
        }
        private void ModificarPeleadores(List<Personaje> Peleadores)
        { 
            if (Peleadores[player1].Salud > Peleadores[player2].Salud)
            {
                //Elminar al perdedor
                Peleadores.RemoveAt(player2);
            }
            else if (Peleadores[player1].Salud < Peleadores[player2].Salud)
            {
                // eliminar perdedor
                Peleadores.RemoveAt(player1);
            }
        }
    }
}
