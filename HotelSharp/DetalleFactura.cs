using System;
using System.Collections.Generic;

public class DetalleFactura
{
    public int ID { get; set; }
    public int  Cantidad { get; set; }
    public double Precio { get; set; }
    //public double Precio_PaqueteOferta { get; set; }
    public TipoHabitacion TipoHabitacion { get; set; }
    //public PaqueteOferta PaqueteOferta { get; set; }

    public DetalleFactura(int id, int cantidad, TipoHabitacion tipoHabitacion/*, PaqueteOferta paquete*/)
    {
        ID = id;
        Cantidad = cantidad;
        TipoHabitacion = tipoHabitacion;
        Precio = tipoHabitacion.Precio;
        //Precio = paquete.Precio;
    }
}