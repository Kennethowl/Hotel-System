public class Reservador:Persona
{
    public string Cargo { get; set; }
    public string Usuario { get; set; }

    public Reservador(int id, string nombre, string apellido, string cargo, string usuario)
    {
        ID = id;
        Nombre = nombre;
        Apellido = apellido;
        Cargo = cargo;
        Usuario = usuario;
    }
}