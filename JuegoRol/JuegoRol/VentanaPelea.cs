using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Windows.Forms;

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
                            API ListClimas = JsonSerializer.Deserialize<List<API>>(responseBody);
                            foreach (var clima in ListClimas)
                            {
                                if (clima.Name == "San Miguel de Tucumán")
                                {
                                    string descripcionClima = clima.Weather.Description;
                                    switch (ChequearClima(descripcionClima))
                                    {
                                        case 1:
                                            Image img1 = Image.FromFile(path + "\\FotosClima\\nublado.jpg");
                                            this.BackgroundImage = img1;
                                            break;
                                        case 2:
                                            Image img2 = Image.FromFile(path + "\\FotosClima\\cubierto.jpg");
                                            this.BackgroundImage = img2;
                                            break;
                                        case 3:
                                            Image img3 = Image.FromFile(path + "\\FotosClima\\parc-nublado.jpg");
                                            this.BackgroundImage = img3;
                                            break;
                                        case 4:
                                            Image img4 = Image.FromFile(path + "\\FotosClima\\despejado.jpg");
                                            this.BackgroundImage = img4;
                                            break;
                                        case 5:
                                            Image img5 = Image.FromFile(path + "\\FotosClima\\lluvia.jpg");
                                            this.BackgroundImage = img5;
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
                error = ex.ToString();
            }
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
                        private void mostrarGanador(List<Personaje> Peleadores)
                        {
                            string Vencedor;
                            if (Peleadores[player1].Salud > Peleadores[player2].Salud)
                            {
                                Vencedor = Peleadores[player1].Nombre + " (" + Peleadores[player1].Tipo + ")";
                            }
                            else if (Peleadores[player1].Salud < Peleadores[player2].Salud)
                            {
                                Vencedor = Peleadores[player2].Nombre + " (" + Peleadores[player2].Tipo + ")";
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
                            this.Close();
                        }
                        private void ModificarPeleadores(List<Personaje> Peleadores)
                        { // Elimina al perdedor y le bonifica un poco de vida, nivel y fuerza al ganador
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
