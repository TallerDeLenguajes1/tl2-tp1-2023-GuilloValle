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

/*--------------------------------------------------------------------------------------------*/

     public void cambiarEstadoPedido(int nroPedido, EstadoPedido nuevoEstado)
    {
        var pedidoAcambiarEstado = pedidos.Find(pedido => pedido.NroPedido == nroPedido);
        pedidoAcambiarEstado.Estado=nuevoEstado;
    }   
    public Pedido BuscarEnIngresados(int nroPedido)
    {
        return pedidos.Find(pedido => pedido.NroPedido == nroPedido);   
    }
    public  void DarDeAltaPedidio(int nroPedido, string observacionPedido,string nombreCliente,string direccionCliente,long telefonoCliente, string datosReferencia)
    {
        var pedido = new Pedido(nroPedido,observacionPedido,nombreCliente,direccionCliente,telefonoCliente,datosReferencia,EstadoPedido.Ingresado);
        pedidos.Add(pedido);
    }
    public void AsignarCadeteAPedido(int idPedido, int idCadete){

        var cad = cadetes.Find(cadete => cadete.Id == idCadete);
        var ped = pedidos.Find(pedido => pedido.NroPedido == idPedido);
        ped.Cadete = cad;
    }


    public double JornalACobrar(int idCadete)
    {
        return CantidadPedidosEntregados(idCadete)*PRECIO_ENVIO;
    }
    
    public int CantidadPedidosEntregados(int idCadete)
    {
        int cantPedidos = 0;
        foreach (var pedido in pedidos)
        {
            if (pedido.Cadete.Id == idCadete && pedido.Estado == EstadoPedido.Entregado )
            {
                cantPedidos++;
            }
        }
        return cantPedidos;
    }

    // private Cadete BuscarCadeteXId(int idCadete)
    // {
    //     return cadetes.Find(cadete => cadete.Id == idCadete);
    // }

    public Cadeteria(string nombre, double telefono)
    {
        this.nombre = nombre;
        this.telefono = telefono;
        pedidos = new List<Pedido>();
        cadetes = new List<Cadete>(); 
        
    }


    /*private Pedido BuscarPededido(int nroPedido)
    {
        Pedido pedidoBuscado = null;

        foreach (var cadete in cadetes)
        {
            foreach (var pedido in cadete.Pedidos )
            {
                if (pedido.NroPedido == nroPedido)
                {
                    return pedido;
                }
            }
        }

        return pedidoBuscado;
    }*/

   /* private int GetIdCadeteXPedido(int nroPedido)
    {
        int idCadete1=0;

        foreach (var cadete in cadetes)
        {
            foreach (var pedido in cadete.Pedidos)
            {
                if (pedido.NroPedido == nroPedido)
                {
                    return cadete.Id;
                }
            }
        }
        return idCadete1;
    }*/

   /* public void AsignarPedidoCadete(int idCadete, Pedido pedido)
    {
        var cadete = cadetes.Find(cadete => cadete.Id == idCadete); // es una forma mas pro de buscar objetos en una lista que usar el forech (principiantes)
        if (cadete != null)
        {
            cadete.RecibirPedido(pedido);
        }
    }*/

    /*public void CambiarEstado(int nroPedido,EstadoPedido nuevoEstado)
    {

        var PedidoAcambiarEstdo = BuscarPededido(nroPedido);

        if (PedidoAcambiarEstdo != null)
        {
           PedidoAcambiarEstdo.Estado = nuevoEstado; 
        } 
    }*/

   /* public void ReasignarPedidoCadete(int idCadete2, int nroPedido) // idCadete1 : cadete que tiene el pedido || idCadete2: cadete al que le asignare el pedido
    {
        
        var pedido1 = BuscarPededido(nroPedido);
        var cadete2 = BuscarCadeteXId(idCadete2);

        if (cadete2 != null)
        {
            cadete2.RecibirPedido(pedido1);
        }
        
        var cadete1 = cadetes.Find(cadete => cadete.Id == GetIdCadeteXPedido(nroPedido));
        cadete1.EliminarPedido(pedido1);


    }*/

 

    /*private Pedido BuscarPed(int idCadete, int nroPedido)
    {
        Pedido pedidoBuscado = null;

        Cadete cadeteBuscado = BuscarCadeteXId(idCadete);

        if (cadeteBuscado != null)
        {
            pedidoBuscado = cadeteBuscado.Pedidos.Find(pedido => pedido.NroPedido == nroPedido);
        }


        return pedidoBuscado;
    }*/

    /* public void RecibirPedido(int idCadete, int nroPedido, string observacionPedido,string nombreCliente,string direccionCliente,long telefonoCliente, string datosReferencia)
   {
       var nuevoPedido = darDeAltaPedidio(nroPedido,observacionPedido,nombreCliente,direccionCliente,telefonoCliente,datosReferencia,EstadoPedido.Ingresado);
       asignarPedidoCadete(idCadete,nuevoPedido);
   }*/

    /*private Pedido BuscarPed(int idCadete, int idPedido)
    {   
        Pedido pedidoBuscado = null;
        foreach (var cadete in cadetes)
        {
            if (cadete.Id == idCadete)
            {
                foreach (var pedido in cadete.Pedidos)
                {
                    if (pedido.NroPedido == idPedido)
                    {
                       pedidoBuscado = pedido;
                    }
                }
            }
        }
        return pedidoBuscado;
    }*/



}