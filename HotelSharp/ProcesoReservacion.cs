using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Linq;

public class ProcesoReservacion
{
    public List<Reservador> ListadeReservadores { get; set; }
    public List<Cliente> ListadeClientes { get; set; }
    public List<TipoHabitacion> ListadeTipoHabitacion { get; set; }
    public List<PaqueteOferta> ListadePaquetes { get; set; }
    public List<Habitacion> ListadeHabitaciones { get; set; }
    public List<Factura> ListaFacturas { get; set; }
    public List<Usuario> ListadeUsuarios { get; set; }
    
    public ProcesoReservacion()
    {
        ListadeReservadores = new List<Reservador>();
        cargarReservadores();

        ListadeClientes = new List<Cliente>();
        cargarClientes();

        ListadeTipoHabitacion = new List<TipoHabitacion>();
        cargarTipoHabitacion();

        ListadePaquetes = new List<PaqueteOferta>();
        cargarPaquetes();

        ListadeHabitaciones = new List<Habitacion>();
        cargarHabitacion();

        ListaFacturas = new List<Factura>();

        ListadeUsuarios = new List<Usuario>();
        cargarUsuarios();
    }

    // cargar usuarios
    private void cargarUsuarios()
    {
        Usuario u1 = new Usuario(001, "tm01belmont", "123456");
        ListadeUsuarios.Add(u1);
        Usuario u2 = new Usuario(002, "mg02miriam", "56789");
        ListadeUsuarios.Add(u2);
        Usuario u3 = new Usuario(003, "seras03", "castlevania");
        ListadeUsuarios.Add(u3);
    }

    // enlistar a los usuarios
    private void enlistarUsuarios()
    {
        Console.Clear();
        Console.WriteLine("--CARGANDO USUARIOS--");
        Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
        Console.WriteLine("              Usuarios del Sistema               ");
        Console.WriteLine("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
        Console.WriteLine("");
        Console.WriteLine("+-----------------------------------------------+");
        Console.WriteLine("| " + " Codigo "+ " |\t " + "User" + " \t|\t " + "Password " + "  \t|");
        Console.WriteLine("+-----------------------------------------------+");
        Console.WriteLine("");

        foreach (var usuario in ListadeUsuarios.OrderBy(u => u.ID))
        {
            Console.WriteLine("| " + usuario.ID + "\t | " + usuario.User + " \t\t| " + usuario.Password +  " |");
            Console.WriteLine("════════════════════════════════════════════════");
        }
        Console.ReadLine();
    }

    //Remover usuarios
    private void removerUsuarios()
    {
        Console.Clear();
        Console.Write("Codigo del Usuario: ");
        string codigoUsuario = Console.ReadLine();
        Usuario usuario = ListadeUsuarios.Find(u => u.ID.ToString() == codigoUsuario);
        
        if (usuario == null)
        {
            Console.WriteLine("Usuario no valido o no encontrado");
            Console.ReadLine();
            menuUsuarios();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Usuario: " + usuario.User);
            Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Estas seguro que quieres eliminar este usuario s | n: ");
            string afirmar = Console.ReadLine();

            if (afirmar.ToLower() == "s")
            {
                ListadeUsuarios.Remove(usuario); // Funcion Remove
                Console.WriteLine("Usuario eliminado satisfactoriamente");
                Console.ReadLine();
            }
        } 
    }

     //Crear usuarios
    private void crearUsuarios()
    {
        Console.Clear();
        Console.Write("Ingrese el codigo nuevo: ");
        int codigo = Convert.ToInt32(Console.ReadLine());
        Console.Write("Ingrese el nuevo usuario: ");
        string user = Console.ReadLine();
        Console.Write("Ingrese la contraseña: ");
        string password = Console.ReadLine(); 
        Console.Write("Confirmar contraseña: ");
        string confirmarPassword = Console.ReadLine();

        while (confirmarPassword != password )
        {
            Console.WriteLine("Las passwords no son iguales, vuelva a crear otra");
            Console.ReadLine();
            Console.Clear();
            Console.Write("Ingrese la contraseña: ");
            password = Console.ReadLine(); 
            Console.Write("Confirmar password: ");
            confirmarPassword = Console.ReadLine();
        } 
         
        Usuario usuario = new Usuario(codigo, user, confirmarPassword);
        ListadeUsuarios.Add(usuario);

        Console.WriteLine("Usuario creado satisfactoriamente");
        Console.ReadLine();
    }

     // Mantenimiento de usuarios
    private void menuUsuarios()
    {
        string opcion = "";

        do
        {
            Console.Clear();
            Console.WriteLine("--CARGANDO SISTEMA--");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("------------------------------");
            Console.WriteLine("      Usuarios del Sistema    ");
            Console.WriteLine("------------------------------");
            Console.WriteLine("");
            Console.WriteLine("1 - Usuarios (ver)");
            Console.WriteLine("2 - Crear Usuarios");
            Console.WriteLine("3 - Borrar Usuarios");
            Console.WriteLine("0 - Salir del Sistema");
            Console.WriteLine("");
            Console.Write("COMMAND => ");
            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                enlistarUsuarios();
                break;
                case "2":
                crearUsuarios();
                break;
                case "3":
                removerUsuarios();
                break;
                default:
                break;
            }
        } while (opcion != "0");
    }

    //Funcion reservadores
    private void cargarReservadores()
    {
        Reservador r1 = new Reservador(001, "Thomas", "Belmont", "Reservador", "tm01belmont");
        ListadeReservadores.Add(r1);
        Reservador r2 = new Reservador(002, "Miriam", "Gonzales", "Recepcionista", "mg02miriam");
        ListadeReservadores.Add(r2);
        Reservador r3 = new Reservador(003, "Seras", "Victoria", "Reservadora", "seras03");
        ListadeReservadores.Add(r3);
    }

    //Enlistar los trabajadores Equivale al READ / Consultar Select
    private void enlistarReservadores()
    {
        Console.Clear();
        Console.WriteLine("--CARGANDO DATOS--");
        Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
        Console.WriteLine("                                           Reservadores del Hotel                                        ");
        Console.WriteLine("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
        Console.WriteLine(""); 
        Console.WriteLine("---------------------------------------------------------------------------------------------------------");
        Console.WriteLine("|\t " + " Codigo " + "\t|" + "\t Nombre Completo " + "\t|" + "\t Cargo " + "\t\t|" + "\t Usuario " + " \t|");
        Console.WriteLine("---------------------------------------------------------------------------------------------------------");
        Console.WriteLine("");

        foreach (var reservador in ListadeReservadores.OrderBy(r => r.ID))
        {
            Console.WriteLine("|\t     " + reservador.ID + "\t\t|\t" + reservador.Nombre 
            + " " + reservador.Apellido + "\t\t |\t " + reservador.Cargo + "\t |\t " + reservador.Usuario + " \t|");
            Console.WriteLine("═════════════════════════════════════════════════════════════════════════════════════════════════════════");
        }
        Console.ReadLine();
    }

    //Remover reservadores Equivale a Delete
    private void removerReservadores()
    {
        Console.Clear();
        Console.Write("Codigo del Reservador: ");
        string codigoReservador = Console.ReadLine();
        Reservador reservador = ListadeReservadores.Find(r => r.ID.ToString() == codigoReservador);
        
        if (reservador == null)
        {
            Console.WriteLine("Codigo no valido o no encontrado");
            Console.ReadLine();
            menuReservadores();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Nombre Completo: " + reservador.Nombre + " " + reservador.Apellido);
            Console.WriteLine("Cargo: " + reservador.Cargo);
            Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Estas seguro que quieres eliminar este registro s | n: ");
            string afirmar = Console.ReadLine();

            if (afirmar.ToLower() == "s")
            {
                ListadeReservadores.Remove(reservador); // Funcion Remove
                Console.WriteLine("Registro eliminado satisfactoriamente");
                Console.ReadLine();
            }
        }
    }

    //Ingresar Reservadores
    private void insertarReservadores()
    {
        Console.Clear();
        Console.Write("Inserte un codigo nuevo: ");
        int codigo = Convert.ToInt32(Console.ReadLine());  
        Console.Write("Ingrese el nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Ingrese el apellido: ");
        string apellido = Console.ReadLine(); 
        Console.Write("Ingrese el cargo: ");
        string cargo = Console.ReadLine(); 
        Console.Write("Ingrese el usuario: ");
        string usuario = Console.ReadLine();  

        Reservador reservador = new Reservador(codigo, nombre, apellido, cargo, usuario);
        ListadeReservadores.Add(reservador);

        Console.WriteLine("Registro agregado satisfactoriamente");
        Console.ReadLine();
    }

    // Actualizar reservadores o editar Update
    private void actualizarReservadores()
    {
        Console.Clear();
        Console.Write("Codigo del Reservador: ");
        string codigoReservador = Console.ReadLine();
        Reservador reservador = ListadeReservadores.Find(r => r.ID.ToString() == codigoReservador);

        if (reservador == null)
        {
            Console.WriteLine("Codigo no valido o no encontrado");
            Console.ReadLine();
            menuReservadores();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Nombre Completo: " + reservador.Nombre + " " + reservador.Apellido);
            Console.WriteLine("Cargo: " + reservador.Cargo);
            Console.ReadLine();

            ListadeReservadores.Remove(reservador);

            Console.WriteLine("");
            Console.Write("Ingrese el nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese el apellido: ");
            string apellido = Console.ReadLine(); 
            Console.Write("Ingrese el cargo: ");
            string cargo = Console.ReadLine(); 
            Console.Write("Ingrese el usuario: ");
            string usuario = Console.ReadLine();
            
            Reservador nuevoReservador = new Reservador(reservador.ID, nombre, apellido, cargo, usuario);
            ListadeReservadores.Add(nuevoReservador);
            Console.WriteLine("Registro actualizado satisfactoriamente");
            Console.ReadLine();  
        }
    }

    // Menu Reservadores
    private void menuReservadores()
    {
        Console.Clear();
        Console.WriteLine("--CARGANDO MENU--");
        Thread.Sleep(1000);
       // CRUD CREATE READ UPDATE DELETE
        while (true)
        {
            Console.Clear();
            Console.WriteLine("+-------------------------------------+");
            Console.WriteLine("+        SISTEMA DE RESERVADORES      +");
            Console.WriteLine("+-------------------------------------+");
            Console.WriteLine("");
            Console.WriteLine("1 - Detalle (Ver)");
            Console.WriteLine("2 - Remover (Eliminar)");
            Console.WriteLine("3 - Insertar (Agregar)");
            Console.WriteLine("4 - Actualizar");
            Console.WriteLine("0 - Salir");
            Console.WriteLine("");
            Console.Write("Seleccione una opcion: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                enlistarReservadores();
                break;
                case "2":
                removerReservadores();
                break;
                case "3":
                insertarReservadores();
                break;
                case "4":
                actualizarReservadores();
                break;
                default:
                break;
            } 
            if (opcion == "0")
            {
                break;
            } 
        }
    }
    // cargar clientes
    private void cargarClientes()
    {
        Cliente c1 = new Cliente(001, "Mayra", "Arauz", "9941-3312", "Ave. Juan Pablo Segundo", "Honduran", "1804-2222-11111");
        ListadeClientes.Add(c1);
        Cliente c2 = new Cliente(002, "Gisel", "Membreno", "9133-3333", "Col. Esperanza de Jesus", "Honduran", "0305-2222-11111");
        ListadeClientes.Add(c2);
        Cliente c3 = new Cliente(003, "Greidy", "Avila", "3341-0312", "Barrio Montevideo", "Honduran", "1804-3333-11111");
        ListadeClientes.Add(c3);
    }

    // enlistar clientes
    private void enlistarClientes()
    {
        Console.Clear();
        Console.WriteLine("--CARGANDO DATOS--");
        Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
        Console.WriteLine("                                                                     Clientes del Hotel                                                                  ");
        Console.WriteLine("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
        Console.WriteLine(""); 
        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("|\t " + " Codigo " + "\t|" + "\t Nombre Completo " + "\t|" + "\t No° Telefono " + "\t\t|" + "\t Direccion " + "\t| " + "    Nacionalidad " + "| " + " Identidad " +  " \t|");
        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("");

        foreach (var cliente in ListadeClientes.OrderBy(c => c.ID))
        {
            Console.WriteLine("|\t     " + cliente.ID + "\t\t  |\t " + cliente.Nombre 
            + " " + cliente.Apellido + "\t  |\t " + cliente.NumeroTelefono + "\t  |\t " + cliente.Direccion + "\t  | " +
            cliente.Nacionalidad + "\t  | " + cliente.Identidad + " \t|");
            Console.WriteLine("═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
        }
        Console.ReadLine();
    }

    // Remover clientes
    private void removerClientes()
    {
        Console.Clear();
        Console.Write("Codigo del Cliente: ");
        string codigoCliente = Console.ReadLine();
        Cliente cliente = ListadeClientes.Find(c => c.ID.ToString() == codigoCliente);
        
        if (cliente == null)
        {
            Console.WriteLine("Codigo no valido o no encontrado");
            Console.ReadLine();
            menuClientes();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Nombre Completo: " + cliente.Nombre + " " + cliente.Apellido);
            Console.WriteLine("Cargo: " + cliente.Identidad);
            Console.WriteLine("Nacionalidad: " + cliente.Nacionalidad);
            Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Estas seguro que quieres eliminar este registro s | n: ");
            string afirmar = Console.ReadLine();

            if (afirmar.ToLower() == "s")
            {
                ListadeClientes.Remove(cliente); // Funcion Remove
                Console.WriteLine("Registro eliminado satisfactoriamente");
                Console.ReadLine();
            }
        }
    }

    // Insertar clientes
    private void insertarClientes()
    {
        Console.Clear();
        Console.Write("Inserte un codigo nuevo: ");
        int codigo = Convert.ToInt32(Console.ReadLine());  
        Console.Write("Ingrese el nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Ingrese el apellido: ");
        string apellido = Console.ReadLine(); 
        Console.Write("Ingrese el telefono: ");
        string numeroTelefono = Console.ReadLine(); 
        Console.Write("Ingrese la direccion: ");
        string direccion = Console.ReadLine();
        Console.Write("Ingrese la nacionalidad: ");
        string nacionalidad = Console.ReadLine(); 
        Console.Write("Ingrese la identidad: ");
        string identidad = Console.ReadLine();    

        Cliente cliente = new Cliente(codigo, nombre, apellido, numeroTelefono, direccion, nacionalidad, identidad);
        ListadeClientes.Add(cliente);

        Console.WriteLine("Registro agregado satisfactoriamente");
        Console.ReadLine();
    }

    //Actualizar clientes
    private void actualizarClientes()
    {
        Console.Clear();
        Console.Write("Codigo del Cliente: ");
        string codigoCliente = Console.ReadLine();
        Cliente cliente = ListadeClientes.Find(c => c.ID.ToString() == codigoCliente);

        if (cliente == null)
        {
            Console.WriteLine("Codigo no valido o no encontrado");
            Console.ReadLine();
            menuClientes();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Nombre Completo: " + cliente.Nombre + " " + cliente.Apellido);
            Console.WriteLine("Cargo: " + cliente.Identidad);
            Console.WriteLine("Nacionalidad: " + cliente.Nacionalidad);
            Console.ReadLine();

            ListadeClientes.Remove(cliente);

            Console.WriteLine("");
            Console.Write("Ingrese el nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese el apellido: ");
            string apellido = Console.ReadLine(); 
            Console.Write("Ingrese el telefono: ");
            string numeroTelefono = Console.ReadLine(); 
            Console.Write("Ingrese la direccion: ");
            string direccion = Console.ReadLine();
            Console.Write("Ingrese la nacionalidad: ");
            string nacionalidad = Console.ReadLine(); 
            Console.Write("Ingrese la identidad: ");
            string identidad = Console.ReadLine(); 
            
            Cliente nuevoCliente = new Cliente(cliente.ID, nombre, apellido, numeroTelefono, direccion, nacionalidad, identidad);
            ListadeClientes.Add(nuevoCliente);
            Console.WriteLine("Registro actualizado satisfactoriamente");
            Console.ReadLine();  
        }
    }

    // Menu de los clientes
    private void menuClientes()
    {
        Console.Clear();
        Console.WriteLine("--CARGANDO MENU--");
        Thread.Sleep(1000);
       // CRUD CREATE READ UPDATE DELETE
        while (true)
        {
            Console.Clear();
            Console.WriteLine("+-------------------------------------+");
            Console.WriteLine("+          SISTEMA DE CLIENTES        +");
            Console.WriteLine("+-------------------------------------+");
            Console.WriteLine("");
            Console.WriteLine("1 - Detalle (Ver)");
            Console.WriteLine("2 - Remover (Eliminar)");
            Console.WriteLine("3 - Insertar (Agregar)");
            Console.WriteLine("4 - Actualizar");
            Console.WriteLine("0 - Salir");
            Console.WriteLine("");
            Console.Write("Seleccione una opcion: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                enlistarClientes();
                break;
                case "2":
                removerClientes();
                break;
                case "3":
                insertarClientes();
                break;
                case "4":
                actualizarClientes();
                break;
                default:
                break;
            } 
            if (opcion == "0")
            {
                break;
            } 
        }
    }

    //cargar las categorias (tipo de habitacion)
    private void cargarTipoHabitacion()
    {
        TipoHabitacion th1 = new TipoHabitacion(1, "Por Hora", 50, "No cuenta paquete");
        ListadeTipoHabitacion.Add(th1);
        TipoHabitacion th2 = new TipoHabitacion(2, "Sencilla", 400, "No cuenta paquete");
        ListadeTipoHabitacion.Add(th2);
        TipoHabitacion th3 = new TipoHabitacion(3, "Doble", 700, "Servicio a la habitacion");
        ListadeTipoHabitacion.Add(th3);
        TipoHabitacion th4 = new TipoHabitacion(4, "Suite", 2000, "Tour por la ciudad");
        ListadeTipoHabitacion.Add(th4);
        TipoHabitacion th5 = new TipoHabitacion(5, "5 Estrellas", 4000, "Tour, Spa");
        ListadeTipoHabitacion.Add(th5);
        TipoHabitacion th6 = new TipoHabitacion(6, "Galaxy", 5000, "Todos los privilegios");
        ListadeTipoHabitacion.Add(th6);
    }

    // enlistar las categorias de la habitacion
    private void enlistarTipoHabitacion()
    {
        Console.Clear();
        Console.WriteLine("--CARGANDO DATOS--");
        Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
        Console.WriteLine("                                Categorias de las Habitaciones                           ");
        Console.WriteLine("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
        Console.WriteLine("");
        Console.WriteLine("+---------------------------------------------------------------------------------------+");
        Console.WriteLine("|  " + "Codigo" + "  \t|  " + "Nombre Categoria" + "  \t|\t  " + "Precio" + "  \t|\t  " + "Paquete     " + "\t|");
        Console.WriteLine("+---------------------------------------------------------------------------------------+");
        Console.WriteLine("");

        foreach (var tipoHabitacion in ListadeTipoHabitacion.OrderBy(th => th.ID))
        {
            Console.WriteLine("|    " + tipoHabitacion.ID + " \t\t| " + tipoHabitacion.Nombre + " \t\t|\t " + tipoHabitacion.Precio + " \t\t|    " + tipoHabitacion.CuentaPaquete + "  |");
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════");
        }
        Console.ReadLine();
    }

    // Remover tipo habitaciones
    private void removerTipoHabitaciones()
    {
        Console.Clear();
        Console.Write("Codigo de Tipo habitacion: ");
        string codigoTipoHabitacion = Console.ReadLine();
        TipoHabitacion tipoHabitacion = ListadeTipoHabitacion.Find(c => c.ID.ToString() == codigoTipoHabitacion);
        
        if (tipoHabitacion == null)
        {
            Console.WriteLine("Codigo no valido o no encontrado");
            Console.ReadLine();
            menuTipoHabitaciones();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Nombre Categoria: " + tipoHabitacion.Nombre);
            Console.WriteLine("Paquete: " + tipoHabitacion.CuentaPaquete);
            Console.WriteLine("Precio: " + tipoHabitacion.Precio);
            Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Estas seguro que quieres eliminar este registro s | n: ");
            string afirmar = Console.ReadLine();

            if (afirmar.ToLower() == "s")
            {
                ListadeTipoHabitacion.Remove(tipoHabitacion); // Funcion Remove
                Console.WriteLine("Registro eliminado satisfactoriamente");
                Console.ReadLine();
            }
        }
    }

    // crear tipo de habitaciones
    private void insertarTipoHabitaciones()
    {
        Console.Clear();
        Console.Write("Ingrese el codigo: ");
        int codigo = Convert.ToInt32(Console.ReadLine());
        Console.Write("Ingrese el nombre de la categoria: ");
        string nombre = Console.ReadLine();
        Console.Write("Ingrese el precio: ");
        double precio = Convert.ToDouble(Console.ReadLine()); 
        Console.Write("Ingrese el paquete: ");
        string paquete = Console.ReadLine(); 
        
        TipoHabitacion tipoHabitacion = new TipoHabitacion(codigo, nombre, precio, paquete);
        ListadeTipoHabitacion.Add(tipoHabitacion);

        Console.WriteLine("Registro agregado satisfactoriamente");
        Console.ReadLine();
    }

    //actualizar tipo habitaciones
    private void actualizarTipoHabitaciones()
    {
        Console.Clear();
        Console.Write("Codigo de Tipo habitacion: ");
        string codigoTipoHabitacion = Console.ReadLine();
        TipoHabitacion tipoHabitacion = ListadeTipoHabitacion.Find(c => c.ID.ToString() == codigoTipoHabitacion);

        if (tipoHabitacion == null)
        {
            Console.WriteLine("Codigo no valido o no encontrado");
            Console.ReadLine();
            menuTipoHabitaciones();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Nombre Categoria: " + tipoHabitacion.Nombre);
            Console.WriteLine("Paquete: " + tipoHabitacion.CuentaPaquete);
            Console.WriteLine("Precio: " + tipoHabitacion.Precio);
            Console.ReadLine();

            ListadeTipoHabitacion.Remove(tipoHabitacion);

            Console.WriteLine("");
            Console.Write("Ingrese el nombre de la categoria: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese el precio nuevo: ");
            double precio = Convert.ToDouble(Console.ReadLine()); 
            Console.Write("Ingrese el paquete: ");
            string paquete = Console.ReadLine(); 
            
            TipoHabitacion nuevoTipoHabitacion = new TipoHabitacion(tipoHabitacion.ID, nombre, precio, paquete);
            ListadeTipoHabitacion.Add(nuevoTipoHabitacion);
            Console.WriteLine("Registro actualizado satisfactoriamente");
            Console.ReadLine();  
        }
    }

    // menu de tipo habitaciones
    private void menuTipoHabitaciones()
    {
        Console.Clear();
        Console.WriteLine("--CARGANDO MENU--");
        Thread.Sleep(1000);
       // CRUD CREATE READ UPDATE DELETE
        while (true)
        {
            Console.Clear();
            Console.WriteLine("+-------------------------------------+");
            Console.WriteLine("+          SISTEMA DE CATEGORIAS      +");
            Console.WriteLine("+-------------------------------------+");
            Console.WriteLine("");
            Console.WriteLine("1 - Detalle (Ver)");
            Console.WriteLine("2 - Remover (Eliminar)");
            Console.WriteLine("3 - Insertar (Agregar)");
            Console.WriteLine("4 - Actualizar");
            Console.WriteLine("0 - Salir");
            Console.WriteLine("");
            Console.Write("Seleccione una opcion: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                enlistarTipoHabitacion();
                break;
                case "2":
                removerTipoHabitaciones();
                break;
                case "3":
                insertarTipoHabitaciones();
                break;
                case "4":
                actualizarTipoHabitaciones();
                break;
                default:
                break;
            } 
            if (opcion == "0")
            {
                break;
            } 
        }
    }

    // Cargar los paquetes de oferta del hotel
    private void cargarPaquetes()
    {
        PaqueteOferta po1 = new PaqueteOferta(001, "Servicio a la Habitacion", 2000);
        ListadePaquetes.Add(po1);
        PaqueteOferta po2 = new PaqueteOferta(002, "Tour por la ciudad (3 dias)", 3500);
        ListadePaquetes.Add(po2);
        PaqueteOferta po3 = new PaqueteOferta(003, "Tour, Spa (3 dias, gratis)", 6000);
        ListadePaquetes.Add(po3);
        PaqueteOferta po4 = new PaqueteOferta(004, "All Privileges (1 semana)", 10000);
        ListadePaquetes.Add(po4);
    }

    // enlistar los paquetes de oferta del hotel
    private void enlistarPaquetes()
    {
        Console.Clear();
        Console.WriteLine("--CARGANDO DATOS--");
        Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine("══════════════════════════════════════════════════════════════════════════");
        Console.WriteLine("                            Paquetes del Hotel                            ");
        Console.WriteLine("══════════════════════════════════════════════════════════════════════════");
        Console.WriteLine("");
        Console.WriteLine("+-------------------------------------------------------------------------+");
        Console.WriteLine("|  " + "Codigo" + "  \t|  " + "Nombre Paquete" + "  \t\t\t|     " + "Precio" + "      |");
        Console.WriteLine("+-------------------------------------------------------------------------+");
        Console.WriteLine("");

        foreach (var paquete in ListadePaquetes.OrderBy(p => p.ID))
        {
            Console.WriteLine("| " + paquete.ID + " \t\t| " + paquete.Nombre + " \t\t|        " + paquete.Precio + "     |");
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════");
        }
        Console.ReadLine();
    }

    // remover paquetes
    private void removerPaquetes()
    {
        Console.Clear();
        Console.Write("Codigo del paquete: ");
        string codigoPaquete = Console.ReadLine();
        PaqueteOferta paqueteOferta = ListadePaquetes.Find(h => h.ID.ToString() == codigoPaquete);

        if (paqueteOferta == null)
        {
            Console.WriteLine("Codigo no valido o no encontrado");
            Console.ReadLine();
            menuPaquetes();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Nombre del paquete: " + paqueteOferta.Nombre);
            Console.WriteLine("Precio: " + paqueteOferta.Precio);
            Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Estas seguro que quieres eliminar este registro s | n: ");
            string afirmar = Console.ReadLine();

            if (afirmar.ToLower() == "s")
            {
                ListadePaquetes.Remove(paqueteOferta); // Funcion Remove
                Console.WriteLine("Registro eliminado satisfactoriamente");
                Console.ReadLine();
            }
        }
    }

    // crear paquetes
    private void insertarPaquetes()
    {
        Console.Clear();
        Console.Write("Ingrese el codigo: ");
        int codigo = Convert.ToInt32(Console.ReadLine());
        Console.Write("Ingrese el nombre del paquete: ");
        string nombre = Console.ReadLine();
        Console.Write("Ingrese el precio: ");
        double precio = Convert.ToDouble(Console.ReadLine()); 
        
        PaqueteOferta paqueteOferta = new PaqueteOferta(codigo, nombre, precio);
        ListadePaquetes.Add(paqueteOferta);

        Console.WriteLine("Registro agregado satisfactoriamente");
        Console.ReadLine();
    }

    // actualizar paquetes
    private void actualizarPaquetes()
    {
        Console.Clear();
        Console.Write("Codigo del paquete: ");
        string codigoPaquete = Console.ReadLine();
        PaqueteOferta paqueteOferta = ListadePaquetes.Find(h => h.ID.ToString() == codigoPaquete);

        if (paqueteOferta == null)
        {
            Console.WriteLine("Codigo no valido o no encontrado");
            Console.ReadLine();
            menuPaquetes();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Nombre del paquete: " + paqueteOferta.Nombre);
            Console.WriteLine("Precio: " + paqueteOferta.Precio);
            Console.ReadLine();

            ListadePaquetes.Remove(paqueteOferta);

            Console.WriteLine("");
            Console.Write("Ingrese el Nombre del paquete: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese el precio del paquete: ");
            double precio = Convert.ToDouble(Console.ReadLine());

            PaqueteOferta nuevoPaquete = new PaqueteOferta(paqueteOferta.ID, nombre, precio);
            ListadePaquetes.Add(nuevoPaquete);
            Console.WriteLine("Registro actualizado satisfactoriamente");
            Console.ReadLine();  
        }
    }

    // menu paquetes
    private void menuPaquetes()
    {
        Console.Clear();
        Console.WriteLine("--CARGANDO MENU--");
        Thread.Sleep(1000);
       // CRUD CREATE READ UPDATE DELETE
        while (true)
        {
            Console.Clear();
            Console.WriteLine("+-------------------------------------+");
            Console.WriteLine("+          SISTEMA DE PAQUETES        +");
            Console.WriteLine("+-------------------------------------+");
            Console.WriteLine("");
            Console.WriteLine("1 - Detalle (Ver)");
            Console.WriteLine("2 - Remover (Eliminar)");
            Console.WriteLine("3 - Insertar (Agregar)");
            Console.WriteLine("4 - Actualizar");
            Console.WriteLine("0 - Salir");
            Console.WriteLine("");
            Console.Write("Seleccione una opcion: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                enlistarPaquetes();
                break;
                case "2":
                removerPaquetes();
                break;
                case "3":
                insertarPaquetes();
                break;
                case "4":
                actualizarPaquetes();
                break;
                default:
                break;
            } 
            if (opcion == "0")
            {
                break;
            } 
        }
    }

    // cargar habitaciones
    private void cargarHabitacion()
    {
        Habitacion h1 = new Habitacion(1, "1");
        ListadeHabitaciones.Add(h1);
        Habitacion h2 = new Habitacion(2, "2");
        ListadeHabitaciones.Add(h2);
        Habitacion h3 = new Habitacion(3, "3");
        ListadeHabitaciones.Add(h3);
        Habitacion h4 = new Habitacion(4, "4");
        ListadeHabitaciones.Add(h4);
        Habitacion h5 = new Habitacion(5, "5");
        ListadeHabitaciones.Add(h5);
        Habitacion h6 = new Habitacion(6, "6");
        ListadeHabitaciones.Add(h6);
        Habitacion h7 = new Habitacion(7, "7");
        ListadeHabitaciones.Add(h7);
        Habitacion h8 = new Habitacion(8, "8");
        ListadeHabitaciones.Add(h8);
        Habitacion h9 = new Habitacion(9, "9");
        ListadeHabitaciones.Add(h9);
        Habitacion h10 = new Habitacion(10, "10");
        ListadeHabitaciones.Add(h10);
    }

    //enlistar habitaciones
    private void enlistarHabitaciones()
    {
        Console.Clear();
        Console.WriteLine("--CARGANDO DATOS--");
        Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
        Console.WriteLine("          Habitaciones del Hotel          ");
        Console.WriteLine("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
        Console.WriteLine("");
        Console.WriteLine("+-----------------------------------------+");
        Console.WriteLine("|  " + "Codigo" + "  \t|  " + "Numero Habitacion"  + "      |");
        Console.WriteLine("+-----------------------------------------+");
        Console.WriteLine("");

        foreach (var habitacion in ListadeHabitaciones.OrderBy(h => h.ID))
        {
            Console.WriteLine("\t  " + habitacion.ID + " \t\t  " + habitacion.NumeroHabitacion);
            Console.WriteLine("══════════════════════════════════════════");
        }
        Console.ReadLine();
    }

    // remover habitaciones
    private void removerHabitaciones()
    {
        Console.Clear();
        Console.Write("Codigo de habitacion: ");
        string codigoHabitacion = Console.ReadLine();
        Habitacion habitacion = ListadeHabitaciones.Find(h => h.ID.ToString() == codigoHabitacion);

        if (habitacion == null)
        {
            Console.WriteLine("Codigo no valido o no encontrado");
            Console.ReadLine();
            menuHabitaciones();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Numero de Habitacion: " + habitacion.NumeroHabitacion);
            Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Estas seguro que quieres eliminar este registro s | n: ");
            string afirmar = Console.ReadLine();

            if (afirmar.ToLower() == "s")
            {
                ListadeHabitaciones.Remove(habitacion); // Funcion Remove
                Console.WriteLine("Registro eliminado satisfactoriamente");
                Console.ReadLine();
            }
        }
    }

    //crear habitaciones
    private void insertarHabitaciones()
    {
        Console.Clear();
        Console.Write("Ingrese el codigo: ");
        int codigo = Convert.ToInt32(Console.ReadLine());
        Console.Write("Ingrese el numero de habitacion: ");
        string numero = Console.ReadLine();

        Habitacion habitacion = new Habitacion(codigo, numero);
        ListadeHabitaciones.Add(habitacion);

        Console.WriteLine("Registro agregado satisfactoriamente");
        Console.ReadLine();
    }

    //actualizar habitaciones
    private void actualizarHabitaciones()
    {
        Console.Clear();
        Console.Write("Codigo de habitacion: ");
        string codigoHabitacion = Console.ReadLine();
        Habitacion habitacion = ListadeHabitaciones.Find(h => h.ID.ToString() == codigoHabitacion);

        if (habitacion == null)
        {
            Console.WriteLine("Codigo no valido o no encontrado");
            Console.ReadLine();
            menuHabitaciones();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Numero de Habitacion: " + habitacion.NumeroHabitacion);
            Console.ReadLine();

            ListadeHabitaciones.Remove(habitacion);

            Console.WriteLine("");
            Console.Write("Ingrese el numero de la habitacion: ");
            string numero = Console.ReadLine();
           
            Habitacion nuevaHabitacion = new Habitacion(habitacion.ID, numero);
            ListadeHabitaciones.Add(nuevaHabitacion);
            Console.WriteLine("Registro actualizado satisfactoriamente");
            Console.ReadLine();  
        }
    }

    // menu habitaciones
    private void menuHabitaciones()
    {
        Console.Clear();
        Console.WriteLine("--CARGANDO MENU--");
        Thread.Sleep(1000);
       // CRUD CREATE READ UPDATE DELETE
        while (true)
        {
            Console.Clear();
            Console.WriteLine("+-------------------------------------+");
            Console.WriteLine("+        SISTEMA DE RESERVADORES      +");
            Console.WriteLine("+-------------------------------------+");
            Console.WriteLine("");
            Console.WriteLine("1 - Detalle (Ver)");
            Console.WriteLine("2 - Remover (Eliminar)");
            Console.WriteLine("3 - Insertar (Agregar)");
            Console.WriteLine("4 - Actualizar");
            Console.WriteLine("0 - Salir");
            Console.WriteLine("");
            Console.Write("Seleccione una opcion: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                enlistarHabitaciones();
                break;
                case "2":
                removerHabitaciones();
                break;
                case "3":
                insertarHabitaciones();
                break;
                case "4":
                actualizarHabitaciones();
                break;
                default:
                break;
            } 
            if (opcion == "0")
            {
                break;
            } 
        }
    }

    // Crear Reservacion
    public void crearReservacion()
    {
        Console.Clear();
        Console.WriteLine("---CREAR RESERVACION---");
        Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine("+-------------------------------------+");
        Console.WriteLine("+         SISTEMA DE RESERVACION      +");
        Console.WriteLine("+-------------------------------------+");
        Console.WriteLine("");
        Console.WriteLine("");

        Thread.Sleep(1000);
        Console.Clear();
        Console.Write("Codigo del Reservador: ");
        string codigoReservador = Console.ReadLine();

        Reservador reservador = ListadeReservadores.Find(r => r.ID.ToString() == codigoReservador);

        if (reservador == null)
        {
            Console.WriteLine("Codigo no valido o no encontrado");
            Console.ReadLine();
            crearReservacion();
        }
        else
        {
            Console.WriteLine("Nombre Completo: " + reservador.Nombre + " " + reservador.Apellido);
            Console.WriteLine("Usuario: " + reservador.Usuario);
            Console.WriteLine("Cargo: " + reservador.Cargo);
            Console.ReadLine();
        }
        
        Console.ReadLine();
        Console.Clear();
        Console.Write("Codigo del Cliente: ");
        string codigoCliente = Console.ReadLine();

        Cliente cliente = ListadeClientes.Find(c => c.ID.ToString() == codigoCliente);

        if (codigoCliente == null)
        {
            Console.WriteLine("Codigo no valido o no encontrado");
            Console.ReadLine();
            crearReservacion();
        }
        else
        {
            Console.WriteLine("Nombre Completo: " + cliente.Nombre + " " + cliente.Apellido);
            Console.WriteLine("Nacionalidad: " + cliente.Nacionalidad + " Identidad: " + cliente.Identidad);
            Console.WriteLine("Direccion: " + cliente.Direccion + " Telefono: " + cliente.NumeroTelefono);
            Console.ReadLine();
        }

        Console.ReadLine();
        Console.Clear();
        Console.Write("Codigo de la Habitacion: ");
        string codigoHabitacion = Console.ReadLine();

        Habitacion habitacion = ListadeHabitaciones.Find(h => h.ID.ToString() == codigoHabitacion);

        if (codigoHabitacion == null)
        {
            Console.WriteLine("Codigo no valido o no encontrado");
            Console.ReadLine();
            crearReservacion();
        }
        else
        {
            Console.WriteLine("Numero de Habitacion: " + habitacion.NumeroHabitacion);
            Console.ReadLine();
        }

        Console.ReadLine();
        Console.Clear();

        int nuevoCodigo = ListaFacturas.Count + 1;
        Factura factura = new Factura(nuevoCodigo, DateTime.UtcNow, reservador, cliente, habitacion, "RES" + nuevoCodigo);
        ListaFacturas.Add(factura);

        while (true)
        {
            Console.Write("Codigo Tipo de habitacion: ");
            string codigoTipoHabitacion = Console.ReadLine();

            TipoHabitacion tipoHabitacion = ListadeTipoHabitacion.Find(th => th.ID.ToString() == codigoTipoHabitacion);

            if (codigoTipoHabitacion == null)
            {
                Console.WriteLine("Codigo no valido o no encontrado");
                Console.ReadLine();
                crearReservacion();
            }
            else
            {
                Console.WriteLine("Paquete: " + tipoHabitacion.CuentaPaquete);
                Console.WriteLine("Tipo: " + tipoHabitacion.Nombre);
                Console.WriteLine("Precio: " + tipoHabitacion.Precio);
                factura.crearFactura(tipoHabitacion);
                Console.ReadLine();
            }

            Console.Write("Desea realizar otra reservacion (s o n) =>  ");
            string tecla = Console.ReadLine();
            if (tecla.ToLower() == "n")
            {
                break;
            }
        }

        Console.Clear();
        Console.WriteLine("---------GENERANDO FACTURA---------");
        Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("Fecha: " + DateTime.Now);
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("Subtotal: " + factura.Subtotal);
        Console.WriteLine("ISV - Impuesto: " + factura.Impuesto);
        Console.WriteLine("Total: " + factura.Total);
        Console.WriteLine("");
        Console.ReadLine();

        Console.Write("Desea tomar un paquete (s o n) => ");
        string afirmacion = Console.ReadLine();

        if (afirmacion.ToLower() == "s")
        {
            while (true)
            {
                Console.ReadLine();
                Console.Clear();
                Console.Write("Codigo Paquete: ");
                string codigoPaquete = Console.ReadLine();

                PaqueteOferta paqueteOferta = ListadePaquetes.Find(p => p.ID.ToString() == codigoPaquete);

                if (codigoPaquete == null)
                {
                    Console.WriteLine("Codigo no valido o no encontrado");
                    Console.ReadLine();
                    crearReservacion();
                }
                else
                {
                    Console.WriteLine("Paquete: " + paqueteOferta.Nombre );
                    Console.WriteLine("Precio: " + paqueteOferta.Precio);
                    factura.Total = factura.Total + paqueteOferta.Precio;
                    Console.ReadLine();
                }

                Console.Write("Desea Continuar (s o n) => ");
                string key = Console.ReadLine(); 
                if (key.ToLower() == "n")
                {
                    break;
                }
            }   
                Console.WriteLine("");
                Console.WriteLine("Nuevo Total: " + factura.Total);
                Console.WriteLine("");

                Console.Write("Digite el monto: ");
                factura.Monto = Convert.ToInt32(Console.ReadLine());

                factura.Cambio = factura.Monto - factura.Total;

                Console.WriteLine("Su cambio: " + factura.Cambio);
                Console.ReadLine();
        }
        else
        {
            Console.Write("Digite el monto: ");
            factura.Monto = Convert.ToInt32(Console.ReadLine());

            factura.Cambio = factura.Monto - factura.Total;

            Console.WriteLine("Su cambio: " + factura.Cambio);
            Console.ReadLine();
        }  
        Console.Write("Desea ver factura (s ver) (n salir) => ");
        string opcion = Console.ReadLine();
        if (opcion.ToLower() == "s")
        {
            verFactura();
        }  
    }

    // Imprimir reporte
    public void imprimirReporte()
    {
        Console.Clear();
        Console.WriteLine("---CARGANDO REPORTE---");
        Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine("------------------------------");
        Console.WriteLine("       Reportes del Dia       ");
        Console.WriteLine("------------------------------");
        Console.WriteLine("");
        Console.WriteLine("|  Nombre Completo   |  Total | Monto | Cambio |   Nombre Cliente    |");
        Console.WriteLine("|  Precio Paquete | Precio | Tipo de Habitacion |");
        Console.WriteLine("");
        Console.WriteLine("");

        foreach (var reporte in ListaFacturas)
        {
            Console.WriteLine(reporte.Reservador.Nombre + " " + reporte.Reservador.Apellido + " " + reporte.Total + " " + reporte.Monto + " " + reporte
            .Cambio + " " + reporte.Cliente.Nombre + " " + reporte.Cliente.Apellido + " " + reporte.Impuesto);

            foreach (var reporte2 in reporte.ListaDetalleFactura)
            {
                Console.WriteLine(reporte2.Cantidad + " " + reporte2.Precio + " " +reporte2.TipoHabitacion.Precio);
            }
            Console.WriteLine(); 
        }
        Console.ReadLine();
    }

    // ver factura en pantalla
    public void verFactura() {
        Console.Clear();
        Console.WriteLine("---CARGANDO FACTURA---");
        Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine("*********************************************************************");
        Console.WriteLine("                               FACTURA                               ");
        Console.WriteLine("                            HOTEL RED GUARA                          ");
        Console.WriteLine("             Disfruta de tus vacaciones con nuestro servicio         ");
        Console.WriteLine("*********************************************************************");
        Console.WriteLine("---------------------------------------------------------------------");
        Console.WriteLine("");
        Console.WriteLine(" \t\t " + " FECHA " + " \t\t " + " \t " + " TRABAJADOR ");
        Console.WriteLine("");

        foreach (var reporte in ListaFacturas)
        {
            Console.WriteLine( " \t  "  + reporte.Fecha + "   \t    " + reporte.Reservador.Nombre + "   \t    " + reporte.Reservador.Apellido );
			Console.WriteLine("");
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine(" \t  "  + "Cliente: " + reporte.Cliente.Nombre + "   \t    " + reporte.Cliente.Apellido);
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine(" \t  " + "Numero de Habitacion: " + reporte.Habitacion.NumeroHabitacion);
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine(" \t  " + "Codigo de Habitacion: " + reporte.ID);
            Console.WriteLine("---------------------------------------------------------------------");
			Console.WriteLine("");
			Console.WriteLine("SUBTOTAL: " + reporte.Subtotal);
			Console.WriteLine("IMPUESTO: " + reporte.Impuesto);
			Console.WriteLine("TOTAL: " + reporte.Total);
            Console.WriteLine("MONTO RECIBIDO: " + reporte.Monto);
            Console.WriteLine("CAMBIO: " + reporte.Cambio);
			Console.WriteLine("");
			Console.WriteLine("---------------------------------------------------------------------");
			Console.WriteLine(""); 

            foreach (var reporte2 in reporte.ListaDetalleFactura)
            {
                Console.WriteLine( "  "  + reporte2.TipoHabitacion.Nombre + "      " + reporte2.Precio + "      " + reporte2.ID);
				Console.WriteLine("---------------------------------------------------------------------");
            }
        }
        Console.ReadLine();

        while (true)
        {
            Console.WriteLine("");
            Console.WriteLine("SpaceBar=Imprimir Factura");
            Console.WriteLine("Insert=Salir");
            if (Console.ReadKey().Key == ConsoleKey.Spacebar)
            {
                imprimirFactura();
            }
            if (Console.ReadKey().Key == ConsoleKey.Insert)
            {
                break;
            }
        }
    }

    // imprimir factura
    private void imprimirFactura()
    {
        string path = "";
        string afirmacion;

        Console.Write("Desea imprimir la factura (si o no): ");
        afirmacion = Console.ReadLine();

        while (afirmacion.ToLower() == "si")
        {
            Console.Write("Ingrese el nombre de la factura: ");
            path = Console.ReadLine();

            StreamWriter factura = new StreamWriter(@"C:\Users\OPT790\Desktop\Kenneth\Programacion\C#\HotelSystem\HotelSharp\Database\facturas\" + path + ".txt"); 
            
            Console.Clear();
            Console.WriteLine("---IMPRIMIENDO FACTURA---");
            Thread.Sleep(1000);
            Console.Clear();
            factura.WriteLine("*********************************************************************");
            factura.WriteLine("                               FACTURA                               ");
            factura.WriteLine("                            HOTEL RED GUARA                          ");
            factura.WriteLine("             Disfruta de tus vacaciones con nuestro servicio         ");
            factura.WriteLine("*********************************************************************");
            factura.WriteLine("---------------------------------------------------------------------");
            factura.WriteLine("");
            factura.WriteLine(" \t\t " + " FECHA " + " \t\t " + " \t " + " TRABAJADOR ");
            factura.WriteLine("");

            foreach (var reporte in ListaFacturas)
            {
                factura.WriteLine( " \t  "  + reporte.Fecha + "   \t    " + reporte.Reservador.Nombre + "   \t    " + reporte.Reservador.Apellido );
                factura.WriteLine("");
                factura.WriteLine("---------------------------------------------------------------------");
                factura.WriteLine(" \t  "  + "Cliente: " + reporte.Cliente.Nombre + "   \t    " + reporte.Cliente.Apellido);
                factura.WriteLine("---------------------------------------------------------------------");
                factura.WriteLine("");
                factura.WriteLine("---------------------------------------------------------------------");
                factura.WriteLine(" \t  " + "Numero de Habitacion: " + reporte.Habitacion.NumeroHabitacion);
                factura.WriteLine("---------------------------------------------------------------------");
                factura.WriteLine("");
                factura.WriteLine("---------------------------------------------------------------------");
                factura.WriteLine(" \t  " + "Codigo de Habitacion: " + reporte.ID);
                factura.WriteLine("---------------------------------------------------------------------");
                factura.WriteLine("");
                factura.WriteLine("SUBTOTAL: " + reporte.Subtotal);
                factura.WriteLine("IMPUESTO: " + reporte.Impuesto);
                factura.WriteLine("TOTAL: " + reporte.Total);
                factura.WriteLine("MONTO RECIBIDO: " + reporte.Monto);
                factura.WriteLine("CAMBIO: " + reporte.Cambio);
                factura.WriteLine("");
                factura.WriteLine("---------------------------------------------------------------------");
                factura.WriteLine(""); 

                foreach (var reporte2 in reporte.ListaDetalleFactura)
                {
                    factura.WriteLine( "  "  + reporte2.TipoHabitacion.Nombre + "      " + reporte2.Precio + "      " + reporte2.ID);
                    factura.WriteLine("---------------------------------------------------------------------");
                }
            }
            factura.Close();
            Console.Clear();
            Console.WriteLine("Factura impresa!");
            
            Console.Write("Desea imprimir otra factura s | n: ");
            string afirmar = Console.ReadLine();
            if (afirmar.ToLower() == "n")
            {
                break;
            }
        }
    }

    // menu de base datos 
    private void menuDatabase() 
    {
        string opcion = "";

        while (true)
        {   
            Console.Clear();
            Console.WriteLine("---CARGANDO BASE DE DATOS---");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("------------------------------");
            Console.WriteLine("   Hotel Guacamaya DataBase   ");
            Console.WriteLine("------------------------------");
            Console.WriteLine("");
            Console.WriteLine("1 - Reservadores (Trabajadores)");
            Console.WriteLine("2 - Clientes");
            Console.WriteLine("3 - Habitaciones");
            Console.WriteLine("4 - Categorias (Tipo Habitacion)");
            Console.WriteLine("5 - Paquetes (Servicio al Hospedaje)");
            Console.WriteLine("6 - Usuarios del Sistema");
            Console.WriteLine("0 - Salir del Sistema");
            Console.WriteLine("");
            Console.Write("COMMAND => ");
            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                menuReservadores();
                break;
                case "2":
                menuClientes();
                break;
                case "3":
                menuHabitaciones();
                break;
                case "4":
                menuTipoHabitaciones();
                break;
                case "5":
                menuPaquetes();
                break;
                case "6":
                menuUsuarios();
                break;
                default:
                break;
            }
            
            if (opcion == "0") {
                 break;
            }
        }
    }

    // base de datos del sistema
    public void dataBase() 
    {
        string user;
        string password;
    
        Console.Clear();
        Console.Write("Digite el codigo del usuario: ");
        string codigoUsuario = Console.ReadLine();
        
        Usuario usuario = ListadeUsuarios.Find(u => u.ID.ToString() == codigoUsuario); 

        if (usuario == null) {
            Console.WriteLine("Codigo invalido o no existente");
            Console.ReadLine();
        }
        else
        {
            Console.Write("userid: ");
            user = Console.ReadLine();
            Console.Write("password: ");
            password = Console.ReadLine();
            
            if (user == usuario.User && password == usuario.Password)
            {
                menuDatabase();
            }else
            {
                Console.WriteLine("Usuario o Password incorrectos");
                Console.ReadLine();
            }
        }  
    }
}