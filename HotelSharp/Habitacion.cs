public class Habitacion
{
    public int ID { get; set; }
    public string NumeroHabitacion { get; set; }
    
    public Habitacion(int id, string numeroHabitacion)
    {
        ID = id;
        NumeroHabitacion = numeroHabitacion;
    }
}