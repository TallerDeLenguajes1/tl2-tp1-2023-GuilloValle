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


            var Helper = new HelperDeArchivo();
            var cadeteria = Helper.CrearCadeteria(rutaDatosCadeteria);
            Helper.CargarListaCadetes(rutaDatosCadetes,cadeteria.Cadetes);

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
                
                

                if ( 1 <= opcionMenu && opcionMenu <= 5 )
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
                                Helper.DarDeAltaPedidio(nroPedido,observacionPedido,nombreCliente,direccionCliente,telefonoCliente,datosReferenciaDireccion, EstadoPedido.Ingresado);
                                Console.WriteLine("Pedido ingresado con exito!\n");
                            }else
                            {
                                Console.WriteLine("No se pudo recibir pedido");
                            }
                            break;
                        case 2:
                            
                            if (Helper.PedidosIngresados.Count() >= 1) //Para comprobara que ya se cargo un pedido antes de elegir otra opcion
                            {
                                int idCadete;
    
                                Console.WriteLine("Ingrese el ID del cadete a asignar pedido:");
                                    string inputIdCadete = Console.ReadLine();
    
                                Console.WriteLine("Ingrese el Nro del pedido:");
                                    inputNroPedido = Console.ReadLine();
                                
                                bool resultadoIdCadete = int.TryParse(inputIdCadete,out idCadete);
                                resultadoNroPedido = int.TryParse(inputNroPedido,out nroPedido);
    
                                if (resultadoNroPedido && resultadoIdCadete)
                                {
                                    var pedido = Helper.BuscarEnIngresados(nroPedido);
                                    cadeteria.AsignarPedidoCadete(idCadete,pedido);
                                    Console.WriteLine("Pedido asignado con exito!");
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
                        case 3:
                            if (Helper.PedidosIngresados.Count() >= 1)
                            {
                                int numeroEstado;
    
                                Console.WriteLine("Ingrese el Nro del pedido:");
                                    inputNroPedido = Console.ReadLine();
    
                                Console.WriteLine("Seleccione el nuevo estado:\n1-Entregado\n2-En Camino\n3-Cancelado");
                                    string inputNumeroEstado = Console.ReadLine();
    
                                resultadoNroPedido = int.TryParse(inputNroPedido,out nroPedido);
                                bool resultadoNumeroEstado = int.TryParse(inputNumeroEstado,out numeroEstado);
    
                                if (resultadoNroPedido && resultadoNumeroEstado && 1 <= numeroEstado && numeroEstado<=3)
                                {
                                    EstadoPedido nuevoEstado = (EstadoPedido)numeroEstado;
                                    cadeteria.CambiarEstado(nroPedido,nuevoEstado);
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
                            if (Helper.PedidosIngresados.Count() >= 1)
                            {
                                Console.WriteLine("Ingrese el Nro del pedido:");
                                    inputNroPedido = Console.ReadLine();
                                Console.WriteLine("Ingrese el ID del cadete a reasignar pedido:");
                                    string inputIdCadete = Console.ReadLine();
                                
                                resultadoNroPedido = int.TryParse(inputNroPedido,out nroPedido);
                                bool resultadoIdCadete = int.TryParse(inputIdCadete,out int idCadete);
    
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
            Informes.InformeFinalJornada(cadeteria.Cadetes);

        }

        

    
    }