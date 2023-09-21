    namespace GestionPedidos;
    internal class Program
    {
        private static void Main(string[] args)
        {
            string rutaDatosCadeteria = "cadeteria.csv";
            string rutaDatosCadetes = "cadetes.csv";
            string inputMenu;
            int opcionMenu;
            bool programaEnUso = true;
            int eleccion;
            Cadeteria cadeteria = null;
            int nuevoBranch;
            do
            {
                System.Console.WriteLine("Ingrese 1 para trabajar con csv y 2 con JSON");
                string num = Console.ReadLine();
                bool opcion = int.TryParse(num,out eleccion);
            } while (eleccion != 1 && eleccion != 2);

        
           if (eleccion == 1)
            {
                var Helper = new AccesoCSV();
                cadeteria = Helper.CrearCadeteria(rutaDatosCadeteria);
                Helper.CargarListaCadetes(rutaDatosCadetes, cadeteria.Cadetes);
            }
            else if (eleccion == 2) 
            {
                var Helper = new AccesoJSON();
                cadeteria = Helper.CrearCadeteria("cadeteria.json");
                Helper.CargarListaCadetes("cadetes.json", cadeteria.Cadetes);
            }


            Console.WriteLine(cadeteria.Nombre);

            while (programaEnUso)
            {
                Console.WriteLine("***** Gestión de pedidos *****");
                Console.WriteLine("1:Dar de alta un pedido");
                Console.WriteLine("2:Asignar pedido a un cadete");
                Console.WriteLine("3:Cambiar estado del pedido");
                Console.WriteLine("4:Reasignar pedido a otro cadete");
                Console.WriteLine("5:Finalizar gestion");

                do
                {
                    Console.WriteLine("Ingrese una opcion:");
                    inputMenu = Console.ReadLine();
                    bool resultado  = int.TryParse(inputMenu , out opcionMenu);
                } while (opcionMenu < 1 && opcionMenu < 5);
                
                

                if (1<= opcionMenu && opcionMenu<=5 )
                {
                    switch (opcionMenu)
                    {
                        case 1:
                            int nroPedido;
                            string observacionPedido;
                            string nombreCliente,direccionCliente,datosReferenciaDireccion;
                            long telefonoCliente;

                            Console.WriteLine("Ingrese los siguientes datos del pedido:");
                            Console.WriteLine("-Nro pedido:");
                                string inputNroPedido = Console.ReadLine();
                            Console.WriteLine("-Observación Pedido:");
                                observacionPedido = Console.ReadLine();
                            Console.WriteLine("-Nombre Cliente:");
                                nombreCliente = Console.ReadLine();
                            Console.WriteLine("-Dirección Cliente:");
                                direccionCliente = Console.ReadLine();
                            Console.WriteLine("-Telefono Cliente");
                                string inputNroTel = Console.ReadLine();
                            Console.WriteLine("-Datos de referencia:");
                                datosReferenciaDireccion = Console.ReadLine();

                            bool resultadoNroPedido = int.TryParse(inputNroPedido,out nroPedido);
                            bool resultadoTel = long.TryParse(inputNroTel,out telefonoCliente);

                            if (resultadoNroPedido && resultadoTel)
                            {
                                cadeteria.DarDeAltaPedidio(nroPedido,observacionPedido,nombreCliente,direccionCliente,telefonoCliente,datosReferenciaDireccion);
                                Console.WriteLine("Pedido ingresado con exito!\n");
                            }else
                            {
                                Console.WriteLine("No se pudo recibir pedido");
                            }
                            break;
                        case 2:
                            
                            int idCadete;
                            if (cadeteria.Pedidos.Count() >= 1)
                            {
    
                                Console.WriteLine("Ingrese el ID del cadete a asignar pedido:");
                                    string inputIdCadete = Console.ReadLine();
    
                                Console.WriteLine("Ingrese el Nro del pedido:");
                                    inputNroPedido = Console.ReadLine();
                                
                                bool resultadoIdCadete = int.TryParse(inputIdCadete,out idCadete);
                                resultadoNroPedido = int.TryParse(inputNroPedido,out nroPedido);
    
                                if (resultadoNroPedido && resultadoIdCadete) //Controlo que se casteo bien
                                {   
                                        var pedido = cadeteria.BuscarEnIngresados(nroPedido); //COMO HAGO PARA PASARLE DIRECTAMENTE EL NRO DE PEDIDO
                                        cadeteria.AsignarCadeteAPedido(pedido.NroPedido,idCadete);
                                        Console.WriteLine("Pedido asignado con exito!");
                            
                                }else
                                {
                                    if (resultadoNroPedido)
                                    {
                                        Console.WriteLine("----- Ingrese correctamente el nro de pedido -----");
                                    }else
                                    {
                                        Console.WriteLine("----- Ingrese correctamente el nro de cadete -----");
                                    }
                                }
                            }else
                            {
                                System.Console.WriteLine("No se ingresó ningun pedido aún");
                            }
                            break;
                        case 3:
                            int numeroEstado;

                            if (cadeteria.Pedidos.Count() >= 1)
                            {
                                Console.WriteLine("Ingrese el Nro del pedido:");
                                    inputNroPedido = Console.ReadLine();
    
                                Console.WriteLine("Seleccione el nuevo estado:\n1-Entregado\n2-En Camino\n3-Cancelado");
                                    string inputNumeroEstado = Console.ReadLine();
    
                                resultadoNroPedido = int.TryParse(inputNroPedido,out nroPedido);
                                bool resultadoNumeroEstado = int.TryParse(inputNumeroEstado,out numeroEstado);
    
                                if (resultadoNroPedido && resultadoNumeroEstado && 1 <= numeroEstado && numeroEstado<=3)
                                {
                                    EstadoPedido nuevoEstado = (EstadoPedido)numeroEstado;
                                    cadeteria.cambiarEstadoPedido(nroPedido,nuevoEstado);
                                    Console.WriteLine("Estado del pedido cambiado con exito!");
                                }else
                                {
                                    if (resultadoNroPedido)
                                    {
                                        Console.WriteLine("No se encontro pedido");
                                    }else
                                    {
                                        Console.WriteLine("Ingreso un estado invalido");
                                    }
                                }
                            }else
                            {
                                System.Console.WriteLine("No se ingresó ningun pedido aún");
                            }
                            break;
                        case 4:
                           if (cadeteria.Pedidos.Count() >= 1)
                           {
                             Console.WriteLine("Ingrese el Nro del pedido:");
                                 inputNroPedido = Console.ReadLine();
                             Console.WriteLine("Ingrese el ID del cadete a reasignar pedido:");
                                string inputIdCadete = Console.ReadLine();
                             
                             resultadoNroPedido = int.TryParse(inputNroPedido,out nroPedido);
                             bool resultadoIdCadete = int.TryParse(inputIdCadete,out idCadete);
 
                             if (resultadoNroPedido && resultadoIdCadete)
                             {
                             cadeteria.ReasignarPedidoCadete(idCadete,nroPedido);
                             Console.WriteLine("Pedido reasignado con exito!");
                             }else
                             {
                                 if (resultadoNroPedido)
                                 {
                                     Console.WriteLine("----- No se encontro pedido -----");
                                 }else
                                 {
                                     Console.WriteLine("----- No se encontro el cadete -----");
                                 }
                             }
                           }else
                            {
                                System.Console.WriteLine("No se ingresó ningun pedido aún");
                            }
                            break;
                        case 5:
                            programaEnUso = false;
                            break;
                    }
                }
            }
            Informes.InformeFinalJornada(cadeteria);

        }

        

    
    }