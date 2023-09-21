using System.Data.Common;

namespace GestionPedidos;

public class Cadeteria
{
    const int PRECIO_ENVIO = 500;
    private string nombre;
    private double telefono;
    private List<Cadete> cadetes;

    private List<Pedido> pedidos;

    

    public string Nombre { get => nombre;}
    public double Telefono { get => telefono;}
    public List<Cadete> Cadetes { get => cadetes; set => cadetes = value; }
    public List<Pedido> Pedidos { get => pedidos; set => pedidos = value; }

    /*--------------------------------------------------------------------------------------------*/

    public Cadeteria(string nombre, double telefono)
    {
        this.nombre = nombre;
        this.telefono = telefono;
        Pedidos = new List<Pedido>();
        cadetes = new List<Cadete>(); 
        
    }

    public void cambiarEstadoPedido(int nroPedido, EstadoPedido nuevoEstado)
    {
        var pedidoAcambiarEstado = Pedidos.Find(pedido => pedido.NroPedido == nroPedido);
        pedidoAcambiarEstado.Estado=nuevoEstado;
    }   
    public Pedido BuscarEnIngresados(int nroPedido)
    {
        return Pedidos.Find(pedido => pedido.NroPedido == nroPedido);   
    }
    public  void DarDeAltaPedidio(int nroPedido, string observacionPedido,string nombreCliente,string direccionCliente,long telefonoCliente, string datosReferencia)
    {
        var pedido = new Pedido(nroPedido,observacionPedido,nombreCliente,direccionCliente,telefonoCliente,datosReferencia,EstadoPedido.Ingresado);
        Pedidos.Add(pedido);
    }
    public bool AsignarCadeteAPedido(int idPedido, int idCadete){

        var cad = cadetes.Find(cadete => cadete.Id == idCadete);
        var ped = Pedidos.Find(pedido => pedido.NroPedido == idPedido);
        if (cad != null && ped != null)
        {
            ped.Cadete = cad;
            return true;
        }else
        {
            return false;
        }
        
    }


    public double JornalACobrar(int idCadete)
    {
        return CantidadPedidosEntregados(idCadete)*PRECIO_ENVIO;
    }
    
    public int CantidadPedidosEntregados(int idCadete)
    {
        int cantPedidos = 0;
        foreach (var pedido in Pedidos)
        {
            if (pedido.Cadete?.Id == idCadete && pedido.Estado == EstadoPedido.Entregado )
            {
                cantPedidos++;
            }
        }
        return cantPedidos;
    }


    public bool ReasignarPedidoCadete(int idPedido, int idCadete){

        var cadeteBuscado = cadetes.Find(cadete => cadete.Id == idCadete);
        var pedidoBuscado = Pedidos.Find(pedido => pedido.NroPedido == idPedido);
        if (cadeteBuscado != null && pedidoBuscado != null)
        {
            pedidoBuscado.Cadete = cadeteBuscado;
            return true;
        }else
        {
            return false;
        }
    }



}