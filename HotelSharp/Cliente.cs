public class Cliente:Persona
{
    public string Direccion { get; set; }
    public string Nacionalidad { get; set; }
    public string Identidad { get; set; }

    public Cliente(int id, string nombre, string apellido, string numeroTelefono,
    string direccion, string nacionalidad, string identidad)
    {
        ID = id;
        Nombre = nombre;
        Apellido = apellido;
        NumeroTelefono = numeroTelefono;
        Direccion = direccion;
        Nacionalidad = nacionalidad;
        Identidad = identidad;
    }
}