using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuegoRol
{
    public partial class VentanaPelea : Form
    {
        int player1, player2;
        List<Personaje> ListaDePeleadores = new List<Personaje>();
        public VentanaPelea(List<Personaje> personajes)
        {
         
            InitializeComponent();
            ListaDePeleadores = personajes;
            CargarDatosDeLaPelea(personajes);
        }
         public void CargarDatosDeLaPelea(List<Personaje> luchadores )
        {
            Random rand = new Random();
             player1 = rand.Next(0,luchadores.Count); // seleccion random de personajes de la lista
             player2 = rand.Next(0, luchadores.Count); // seleccion random de personajes de la lista

            while(player2 == player1)
            {
                player2 = rand.Next(0, luchadores.Count);
            }

            // PLAYER 1
            lbl_nombreP1.Text = luchadores[player1].Nombre;
            lbl_SaludP1.Text = luchadores[player1].Salud.ToString();
            lbl_VelocidadP1.Text = luchadores[player1].Velocidad.ToString();
            lbl_fuerzaP1.Text = luchadores[player1].Fuerza.ToString();
            lbl_NivelP1.Text = luchadores[player1].Nivel.ToString();
            lbl_DestrezaP1.Text = luchadores[player1].Destreza.ToString();
            lbl_ArmaduraP1.Text = luchadores[player1].Armadura.ToString();

            // PLAYER 2
            lbl_nombreP2.Text = luchadores[player1].Nombre;
            lbl_SaludP2.Text = luchadores[player1].Salud.ToString();
            lbl_VelocidadP2.Text = luchadores[player1].Velocidad.ToString();
            lbl_FuerzaP2.Text = luchadores[player1].Fuerza.ToString();
            lbl_NivelP2.Text = luchadores[player1].Nivel.ToString();
            lbl_DestrezaP2.Text = luchadores[player1].Destreza.ToString();
            lbl_ArmaduraP2.Text = luchadores[player1].Armadura.ToString();
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
            }
            int danioProvocado = DanioDeAtaque(ListaDePeleadores, sender);

        }
    }
}
