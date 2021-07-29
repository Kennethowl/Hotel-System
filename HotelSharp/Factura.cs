using System;
using System.Collections.Generic;

public class Factura
{
    public int ID { get; set; }
    public DateTime Fecha { get; set; }
    public Reservador Reservador { get; set; }
    public Cliente Cliente { get; set; }
    public Habitacion Habitacion { get; set; }
    public string NuevoCodigo { get; set; }
    public List<DetalleFactura> ListaDetalleFactura { get; set; }
    public double Subtotal { get; set; }
    public double Impuesto { get; set; }
    public double Total { get; set; }
    public double Monto { get; set; }
    public double Cambio { get; set; }
    //public double NuevoSubtotal { get; set; }

    public Factura(int id, DateTime fecha, Reservador reservador, Cliente cliente, Habitacion habitacion, string nuevoCodigo)
    {
        ID = id;
        Fecha = fecha;
        Reservador = reservador;
        Cliente = cliente;
        Habitacion = habitacion;
        NuevoCodigo = nuevoCodigo;
        ListaDetalleFactura = new List<DetalleFactura>();
    }

    public void crearFactura(TipoHabitacion tipoHabitacion)
    {
        int nuevoCodigo = ListaDetalleFactura.Count + 1;
        int cantidad = 1;

        DetalleFactura detalleFactura = new DetalleFactura(nuevoCodigo, 1, tipoHabitacion);
        ListaDetalleFactura.Add(detalleFactura);

        Subtotal += cantidad * tipoHabitacion.Precio;
        Impuesto = Subtotal * .15;
        Total = Subtotal + Impuesto;
    }
}