namespace GestionPedidos;

public class Cadete
{

    private int id;
    private string nombre;
    private string direccion;
    private long  telefono;

    public Cadete(int id, string nombre, string direccion, long telefono)
    {
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        
    }

    public int Id { get => id; }
    public string Nombre { get => nombre;}
    public string Direccion { get => direccion;}
    public long Telefono { get => telefono;}


  
  /*  public int CantidadDePedidosRecibidos()
    {
        return pedidos.Count();
    }*/

  /*  public void RecibirPedido(Pedido nuevoPedido)
    {
        pedidos.Add(nuevoPedido);
    }
    
   */

   /* public void EliminarPedido(Pedido pedido)
    {
        pedidos.Remove(pedido);
    }*/
}

/* tp 2*/