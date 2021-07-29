public class TipoHabitacion:Categoria
{
    public string CuentaPaquete { get; set; }

    public TipoHabitacion(int id, string nombre, double precio, string cuentaPaquete)
    {
        ID = id;
        Nombre = nombre;
        Precio = precio;
        CuentaPaquete = cuentaPaquete;
    }
}