using System;

namespace HotelSharp
{
    class Program
    {
        static void Main(string[] args)
        {
           Console.Title = "HotelSystem Red Guara";
           
           // Llamar a la clase public Inicio
           Inicio login = new Inicio();
           login.interfaz();
        }
    }
}