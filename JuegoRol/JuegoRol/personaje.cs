using System;

namespace JuegoRol
{
    public enum TipoDePersonaje
    {
        Orco,
        Elfo,
        Hobbit,
        Humano
    }
    public class Personaje
    {
        // DATOS
        private TipoDePersonaje tipo;
        private string nombre;
        private string apodo;
        private DateTime FecNac;
        private int edad;
        private int salud;

        // CARACTERISTICAS 
        private int velocidad;
        private int destreza;
        private int fuerza;
        private int nivel;
        private int armadura;


        // METODO CONSTRUCTOR

        public Personaje()
        {
            Salud = 100; //asigno a cada personaje creado salud 100 x defecto

        }

        public TipoDePersonaje Tipo { get => tipo; set => tipo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apodo { get => apodo; set => apodo = value; }
        public DateTime FecNac1 { get => FecNac; set => FecNac = value; }
        public int Edad { get => edad; set => edad = value; }
        public int Salud { get => salud; set => salud = value; }
        public int Velocidad { get => velocidad; set => velocidad = value; }
        public int Destreza { get => destreza; set => destreza = value; }
        public int Fuerza { get => fuerza; set => fuerza = value; }
        public int Nivel { get => nivel; set => nivel = value; }
        public int Armadura { get => armadura; set => armadura = value; }

        public static string  mostrarPersonaje(Personaje personaje)
        {
            string personajeDatos = "Nombre: " + personaje.Nombre + "Apodo: " + personaje.Apodo + "Tipo: " + personaje.Tipo;
            return personajeDatos;
        }
    }
}
