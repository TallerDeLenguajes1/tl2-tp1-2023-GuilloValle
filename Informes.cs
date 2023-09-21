using GestionPedidos;

public class Informes
{
    public static void InformeFinalJornada(Cadeteria cadeteria)
    {
        var informeCadetes = cadeteria.Cadetes.Select(cadete => new
        {   Cadete = cadete, 
            CantidadPedidosRecibidos = cadeteria.Pedidos.Count(pedido => pedido.Cadete == cadete),
            CantidadPedidosEntregados = cadeteria.CantidadPedidosEntregados(cadete.Id),
            MontoGanado = cadeteria.JornalACobrar(cadete.Id)
        }).ToList();

        int totalPedidosRecidos = informeCadetes.Sum(infoCadete => infoCadete.CantidadPedidosRecibidos); // Pedidos recibido por cada cadete (la suma de todos los pedidos de recibido de cada cadete, son los pedidos en total de la cadeteria)
        int totalPedidosEntregados = informeCadetes.Sum(infoCadete => infoCadete.CantidadPedidosEntregados);
        double totalPagado = informeCadetes.Sum(infoCadete => infoCadete.MontoGanado); // gasto en pago a todos los cadetes

        Console.WriteLine("***** Informe de Pedidos al Finalizar la Jornada *****");
        foreach (var infoCadete in informeCadetes)
        {
            int PromedioPedidosEntregados;
            if (infoCadete.CantidadPedidosRecibidos!=0)
            {
                PromedioPedidosEntregados = infoCadete.CantidadPedidosEntregados/infoCadete.CantidadPedidosRecibidos; 
            }else
            {
                PromedioPedidosEntregados = 0;
            }
            
            Console.WriteLine("\t\tId:{0} || Nombre:{1}", infoCadete.Cadete.Id,infoCadete.Cadete.Nombre);
            Console.WriteLine("\t\t\tCantidad de pedidos asignados:"+infoCadete.CantidadPedidosRecibidos);
            Console.WriteLine("\t\t\tCantidad de pedidos entregados:"+infoCadete.CantidadPedidosEntregados);
            Console.WriteLine("\t\t\tPromedio de pedidos entregados:"+PromedioPedidosEntregados);
            Console.WriteLine("\t\tMonto pagado:"+infoCadete.MontoGanado);
            Console.WriteLine();
        }  
        
        Console.WriteLine("\tTotal de pedidos recibidos:"+totalPedidosRecidos);
        Console.WriteLine("\tTotal de pedidos entregados:"+totalPedidosEntregados);
        Console.WriteLine("\tTotal pagado a cadetes:"+totalPagado);
        Console.WriteLine("***** Fin informe *****");


    }
}