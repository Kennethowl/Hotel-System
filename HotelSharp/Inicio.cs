using System; 
using System.Threading; 
using System.IO; 

public class Inicio
{   
    // Dar posicionamiento hacia arriba
    protected void position(int a, int b, string mensaje)
    {
        Console.SetCursorPosition(a, b);
        Console.WriteLine(mensaje);
    }

    // Interfaz del sistema 
    public void interfaz()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        position(30, 6, "  ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");
        Console.WriteLine("");
        position(30, 8, "\t      Fecha Actual: " + DateTime.Now);
        position(30, 10, "\t      PRODUCTIONS RED GUARA");
        Console.WriteLine("");
        Console.WriteLine("\t\t\t\t▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.DarkYellow; // Color amarillo
        Console.WriteLine("\t\t\t\t╔═══════════════════════════════════════════════════════╗");
        Console.ForegroundColor = ConsoleColor.Green;      // Color verde
        Console.WriteLine("\t\t\t\t║     ■    ■  ■■■■■■  ■■■■■■■■■■  ■■■■■■■■    ■         ║");
        Console.WriteLine("\t\t\t\t║    ■    ■  ■    ■       ■      ■           ■          ║");
        Console.WriteLine("\t\t\t\t║   ■■■■■■  ■    ■       ■      ■■■■■       ■           ║");
        Console.WriteLine("\t\t\t\t║  ■    ■  ■    ■       ■      ■           ■  (1.0.1)   ║");
        Console.WriteLine("\t\t\t\t║ ■    ■  ■■■■■■       ■      ■■■■■■■■■   ■■■■■■■■■     ║");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("\t\t\t\t╚═══════════════════════════════════════════════════════╝");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("\t\t\t\t  ■■>  Welcome to Guara Hotel // Bienvenido a Hotel Guara");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("\t\t\t\t  ■■>  Press ENTER for begin or press F2 for exit system");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("\t\t\t\t ████████████████████████████████████████████████████████");
        Console.WriteLine("");
        Console.WriteLine("\t\t\t\t ■■> ENTER=Begin Hotel    F2=Exit Hotel    BACKSPACE=Help");
        Console.WriteLine("");
           
        if (Console.ReadKey().Key == ConsoleKey.Enter) // Funcion ReadKey 
        {
            login();
        }
        else if (Console.ReadKey().Key == ConsoleKey.F2)
        {
            Console.WriteLine("\t\t\t\t Saliendo del Sistema");
            Thread.Sleep(1500);
        }
        else if (Console.ReadKey().Key == ConsoleKey.Backspace)
        {
            helpFile();
        }
        
        else
        {
            Console.WriteLine("\t\t\t\t Acceso denegado, seleccione el comando correcto");
            Thread.Sleep(1500);
            interfaz();
        }
    }

    // Menu principal del programa
    private void menuPrincipal()
    {
        // Llamar a clase ProcesoReservacion
        ProcesoReservacion procesoReservacion = new ProcesoReservacion();

        string opcion = "";

        do
        {
            Console.Clear();
            Console.WriteLine("--CARGANDO SISTEMA--");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("------------------------------");
            Console.WriteLine("         Hotel Guacamaya      ");
            Console.WriteLine("------------------------------");
            Console.WriteLine("");
            Console.WriteLine("1 - Base de Datos");
            Console.WriteLine("2 - Restaurante");
            Console.WriteLine("3 - Realizar Reservacion");
            Console.WriteLine("4 - Reportes (Reservas)");
            Console.WriteLine("0 - Salir del Sistema");
            Console.WriteLine("");
            Console.Write("COMMAND => ");
            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                procesoReservacion.dataBase();
                break;
                case "2":
                // Pendiente entrarRestaurante();
                break;
                case "3":
                procesoReservacion.crearReservacion();
                break;
                case "4":
                procesoReservacion.imprimirReporte();
                break;
                default:
                break;
            }           
        } while (opcion != "0");

        Console.WriteLine("--VOLVER A INICIO--");
        Thread.Sleep(1000);
        interfaz(); //Volver a la interfaz de inicio
    }

    // Funcion delegar para nuevas funciones void
    //private delegate void Function();

    // Login de inicio del sistema
    private void login()
    {
        string user;
        string password;
    
        Console.ForegroundColor = ConsoleColor.White;
        Console.Clear();
        Console.WriteLine("--CARGANDO SISTEMA--");
        Thread.Sleep(1000);
        Console.Clear();
        Console.Write("userid: ");
        user = Console.ReadLine();
        Console.Write("password: ");
        password = Console.ReadLine();
        Console.Write("");

        if (user == "admin" && password == "castlevania")
        {
           menuPrincipal();
        }
        else
        {
           Console.WriteLine("--VOLVER A INICIO, LOGIN INCORRECTO--");
           Thread.Sleep(1000);
           interfaz();
        }
        // Operador ternario ?
        /*((user == "admin" && password == "castlevania" || user == "user" && password == "castlevania") 
        ?  new Function(menuPrincipal) : new Function((interfaz)))();*/
    }

    // Funcion para leer documentacion acerca del sistema
    private void helpFile()
    {
        try
        {
            TextReader help_file; // Tipo de dato TextReader

            help_file = new StreamReader(@"C:\Users\OPT790\Desktop\Kenneth\Programacion\C#\HotelSystem\HotelSharp\Database\documentacion\help.txt"); // Funcion leer archivo
                
            Console.Clear();
            Console.WriteLine(help_file.ReadToEnd()); // Imprimir archivo

            Console.ReadLine();

            help_file.Close(); // Cerrar archivo
        }
        catch (System.Exception)
        {
            
            Console.WriteLine("\t\t\t\tEl archivo que usted selecciono no existe!");
            Console.ReadLine();
        }

        Console.WriteLine("--VOLVER A INICIO--");
        Thread.Sleep(1000);
        interfaz(); // Volver a inicio
    }
}   