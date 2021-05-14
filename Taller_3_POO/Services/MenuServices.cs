using System;
using System.Collections.Generic;
using System.Text;
using Taller_3_POO.Entidades;

namespace Taller_3_POO.Services
{
    public class MenuServices
    {
        ClienteServices clientesServices = new ClienteServices();
        ProductoServices productoServices = new ProductoServices();
        VentaServices ventaServices = new VentaServices();

        byte op_menu;
        int cedula;
        int codigoProducto;
        int numFactura = 0;

        public void Iniciar()
        {
            do
            {
                MenuPrincipal();
            } while (op_menu != 0);
        }

        private void MenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("*** Menú Principal ***");
            Console.WriteLine("1. [Clientes]");
            Console.WriteLine("2. [Productos]");
            Console.WriteLine("3. [Ventas]");
            Console.WriteLine("4. [Reportes]");
            Console.WriteLine("5. [Configuración]");
            Console.WriteLine("0. [Salir]");
            Console.Write("Seleccione uno de los siguientes módulos: ");
            op_menu = byte.Parse(Console.ReadLine());
            SeleccionModulo(op_menu);
        }

        private void SeleccionModulo(byte op)
        {
            switch (op)
            {
                case 1:
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("*** Módulo Clientes ***");
                        Console.WriteLine("1. [Crear Cliente]");
                        Console.WriteLine("2. [Buscar Cliente]");
                        Console.WriteLine("3. [Modificar Cliente]");
                        Console.WriteLine("4. [Eliminar Cliente]");
                        Console.WriteLine("0. [Regresar al menú principal]");
                        Console.Write("Seleccione la acción a realizar: ");
                        op_menu = byte.Parse(Console.ReadLine());
                        ModuloClientes(op_menu);
                    } while (op_menu != 0);
                    break;
                case 2:
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("*** Módulo Productos ***");
                        Console.WriteLine("1. [Crear Producto]");
                        Console.WriteLine("2. [Buscar Producto]");
                        Console.WriteLine("3. [Modificar Producto]");
                        Console.WriteLine("4. [Eliminar Producto]");
                        Console.WriteLine("0. [Regresar al menú principal]");
                        Console.Write("Seleccione la acción a realizar: ");
                        op_menu = byte.Parse(Console.ReadLine());
                        ModuloProductos(op_menu);
                    } while (op_menu != 0);
                    break;
                case 3:
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("*** Módulo Ventas ***");
                        Console.WriteLine("1. [Realizar Venta]");
                        Console.WriteLine("2. [Buscar Factura]");
                        Console.WriteLine("3. [Eliminar Factura]");
                        Console.WriteLine("0. [Regresar al menú principal]");
                        Console.Write("Seleccione la acción a realizar: ");
                        op_menu = byte.Parse(Console.ReadLine());
                        ModuloVentas(op_menu);
                    } while (op_menu != 0);
                    break;
                case 4:
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("*** Módulo Reportes ***");
                        Console.WriteLine("1. [Listar Clientes]");
                        Console.WriteLine("2. [Listar Productos]");
                        Console.WriteLine("3. [Listar Facturas]");
                        Console.WriteLine("0. [Regresar al menú principal]");
                        Console.Write("Seleccione la acción a realizar: ");
                        op_menu = byte.Parse(Console.ReadLine());
                        ModuloReportes(op_menu);
                    } while (op_menu != 0);
                    break;
                case 5:
                    break;
                case 0:
                    Console.WriteLine("Gracias, vuelva pronto");
                    break;
                default:
                    Console.WriteLine("Opción Incorrecta, seleccione una opción válida");
                    break;
            }
        }

        private void ModuloClientes(byte op)
        {
            int index;

            switch (op)
            {
                case 1:
                    Console.WriteLine("\n*** Crear Cliente ***");
                    cedula = DocumentoCliente();

                    if (clientesServices.BuscarCliente(cedula) < 0)
                    {
                        Cliente clientes = new Cliente();

                        clientes.Cedula = cedula;
                        Console.Write("Nombre del cliente: ");
                        clientes.Nombre = Console.ReadLine();
                        Console.Write("Dirección: ");
                        clientes.Direccion = Console.ReadLine();
                        Console.Write("Teléfono: ");
                        clientes.Telefono = Console.ReadLine();

                        clientesServices.AgregarCliente(clientes);
                        Console.WriteLine("Cliente guardado correctamente");
                    }
                    else
                        Console.WriteLine("El cliente ya existe");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.WriteLine("\n*** Buscar Cliente ***");
                    cedula = DocumentoCliente();

                    Cliente clienteId = new Cliente();

                    clienteId = clientesServices.BuscarClientexId(cedula);
                    if (clienteId != null)
                    {
                        Console.WriteLine("*** Datos del Cliente ***");
                        Console.WriteLine($"Documento: {clienteId.Cedula} \nNombre: {clienteId.Nombre} \nDirección: {clienteId.Direccion} \nTeléfono: {clienteId.Telefono}");
                    }
                    else
                        Console.WriteLine("No hay registro del cliente");
                    Console.ReadKey();
                    break;
                case 3:
                    Console.WriteLine("\n*** Modificar Cliente ***");
                    cedula = DocumentoCliente();

                    if (clientesServices.BuscarCliente(cedula) >= 0)
                    {
                        Cliente clientes = new Cliente();

                        clientes.Cedula = cedula;
                        index = clientesServices.BuscarCliente(cedula);
                        Console.Write("Nombre del cliente: ");
                        clientes.Nombre = Console.ReadLine();
                        Console.Write("Dirección: ");
                        clientes.Direccion = Console.ReadLine();
                        Console.Write("Teléfono: ");
                        clientes.Telefono = Console.ReadLine();

                        clientesServices.ModificarCliente(clientes, index);
                        Console.WriteLine("Cliente modificado correctamente");
                    }
                    else
                        Console.WriteLine("El cliente no existe");
                    Console.ReadKey();
                    break;
                case 4:
                    Console.WriteLine("\n*** Eliminar Cliente ***");
                    cedula = DocumentoCliente();

                    clientesServices.EliminarCliente(cedula);
                    Console.ReadKey();
                    break;
                case 0:
                    MenuPrincipal();
                    break;
                default:
                    Console.WriteLine("Opción Incorrecta, seleccione una opción válida");
                    break;
            }
        }

        private void ModuloProductos(byte op)
        {
            int posicion;
            switch (op)
            {
                case 1:
                    Console.WriteLine("\n*** Crear Producto ***");
                    codigoProducto = CodigoProducto();

                    if (productoServices.BuscarProductos(codigoProducto) >= 0)
                    {
                        Console.WriteLine("El producto ya existe");
                    }
                    else
                    {
                        Producto moduloProductos = new Producto();

                        moduloProductos.CodigoProducto = codigoProducto;
                        Console.Write("Ingrese el nombre del producto: ");
                        moduloProductos.NombreProducto = Console.ReadLine();
                        Console.Write("Ingrese el precio del producto: ");
                        moduloProductos.PrecioProducto = double.Parse(Console.ReadLine());
                        Console.Write("Ingrese la cantidad del producto: ");
                        moduloProductos.CantidadProducto = int.Parse(Console.ReadLine());

                        productoServices.AgregarProductos(moduloProductos);
                        Console.WriteLine("Producto guardado correctamente");
                    }
                    Console.ReadKey();
                    break;
                case 2:
                    Console.WriteLine("\n*** Buscar Producto ***");
                    codigoProducto = CodigoProducto();

                    Producto moduloProductos1 = new Producto();

                    moduloProductos1 = productoServices.ConsultarProductoxCodigo(codigoProducto);
                    if (moduloProductos1 != null)
                    {
                        Console.WriteLine("\n*** Informacion del producto ***");
                        Console.WriteLine($"Código Producto: {moduloProductos1.CodigoProducto} \nNombre Producto: {moduloProductos1.NombreProducto} \nPrecio Unidad: {moduloProductos1.PrecioProducto} \nCantidad Producto: {moduloProductos1.CantidadProducto}");
                    }
                    else
                    {
                        Console.WriteLine("El producto no existe");
                    }
                    Console.ReadKey();
                    break;
                case 3:
                    Console.WriteLine("\n*** Modificar Producto ***");
                    codigoProducto = CodigoProducto();

                    if (productoServices.BuscarProductos(codigoProducto) >= 0)
                    {
                        Producto moduloProductos = new Producto();

                        moduloProductos.CodigoProducto = codigoProducto;
                        posicion = productoServices.BuscarProductos(codigoProducto);
                        Console.Write("Ingrese el nombre del producto: ");
                        moduloProductos.NombreProducto = Console.ReadLine();
                        Console.Write("Ingrese el precio del producto: ");
                        moduloProductos.PrecioProducto = double.Parse(Console.ReadLine());
                        Console.Write("Ingrese la cantidad del producto: ");
                        moduloProductos.CantidadProducto = int.Parse(Console.ReadLine());

                        productoServices.ModificarProductos(moduloProductos, posicion);
                        Console.WriteLine("Producto modificado correctamente");
                    }
                    else
                        Console.WriteLine("El producto no existe");
                    Console.ReadKey();
                    break;
                case 4:
                    Console.WriteLine("\n*** Eliminar Producto ***");
                    codigoProducto = CodigoProducto();

                    productoServices.EliminarProductos(codigoProducto);
                    Console.ReadKey();
                    break;
                case 0:
                    MenuPrincipal();
                    break;
                default:
                    Console.WriteLine("Opción Incorrecta, seleccione una opción válida");
                    break;
            }
        }

        private void ModuloVentas(byte op)
        {
            float acum = 0;
            string resp = "";
            switch (op)
            {
                case 1:
                    Console.WriteLine("\n*** Realizar Venta ***");
                    acum = 0;
                    cedula = DocumentoCliente();
                    if (clientesServices.BuscarCliente(cedula) >= 0)
                    {
                        numFactura += 1;
                        Venta venta = new Venta();
                        venta.NumeroFactura = numFactura;
                        venta.IdCliente = cedula;
                        venta.Fecha = DateTime.Now;
                        venta.Estado = true;
                        Console.WriteLine("Para realizar la venta de sebe de escoger el código del producto que desea comprar");
                        Console.WriteLine("** Lista de productos **");
                        foreach (var productoItem in productoServices.ListarProductos())
                        {
                            Console.WriteLine("Código   |   Nombre Producto  |   Cantidad   |   Valor");
                            Console.WriteLine($"  {productoItem.CodigoProducto}                {productoItem.NombreProducto}               {productoItem.CantidadProducto}           {productoItem.PrecioProducto} \n");
                        }
                        do
                        {
                            codigoProducto = CodigoProducto();
                            if (productoServices.BuscarProductos(codigoProducto) >= 0)
                            {
                                Producto p = productoServices.ConsultarProductoxCodigo(codigoProducto);
                                DetalleVenta detalleVenta = new DetalleVenta();
                                detalleVenta.NumeroFactura = venta.NumeroFactura;
                                detalleVenta.CodigoProducto = p.CodigoProducto;
                                detalleVenta.NombreProducto = p.NombreProducto;
                                detalleVenta.ValorProducto = Convert.ToSingle(p.PrecioProducto);
                                Console.Write("Ingrese la cantidad: ");
                                detalleVenta.CantidadProducto = int.Parse(Console.ReadLine());
                                if (detalleVenta.CantidadProducto > p.CantidadProducto)
                                {
                                    Console.WriteLine("No hay la cantidad requerida");
                                }
                                else
                                {
                                    ventaServices.GuardarDetalleVenta(detalleVenta);
                                    int posicion = productoServices.BuscarProductos(codigoProducto);
                                    p.CantidadProducto = p.CantidadProducto - detalleVenta.CantidadProducto;
                                    productoServices.ModificarProductos(p, posicion);
                                }
                            }
                            else
                            {
                                Console.WriteLine("El producto no existe");
                            }
                            Console.WriteLine("¿Desea ingresar otro producto? S/N");
                            resp = Console.ReadLine();
                        } while (!resp.Equals("n"));

                        foreach (var detalleVentaItem in ventaServices.ListarDetalleVenta())
                        {
                            if (detalleVentaItem.NumeroFactura == numFactura)
                            {
                                float calculo = 0;

                                calculo = detalleVentaItem.ValorProducto * detalleVentaItem.CantidadProducto;
                                acum += calculo;
                            }
                        }
                        venta.ValorTotalVenta = acum;
                        ventaServices.GuardarVenta(venta);
                        Console.WriteLine($"Factura # {numFactura} realizada correctamente");
                    }
                    else
                        Console.WriteLine("El cliente no existe");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.WriteLine("\n*** Buscar Factura ***");
                    Console.WriteLine("Ingrese el número de la factura");
                    numFactura = int.Parse(Console.ReadLine());
                    Venta venta1 = new Venta();

                    venta1 = ventaServices.ConsultarFacturaxId(numFactura);
                    if (venta1 != null)
                    {
                        Console.WriteLine("\n*** Informacion de la factura ***");
                        Console.WriteLine($"Nro Factura: {venta1.NumeroFactura} \nDocumento Cliente: {venta1.IdCliente} \nFecha: {venta1.Fecha}");
                        Console.WriteLine("** Detalle factura **");
                        Console.WriteLine("Item | Nombre | Cantidad | Valor Unidad");
                        int item = 1;
                        foreach (var detalleItem in ventaServices.ListarDetalleVenta())
                        {
                            if (detalleItem.NumeroFactura == numFactura)
                            {                                
                                Console.WriteLine($" {item++} \t{detalleItem.NombreProducto} \t  {detalleItem.CantidadProducto}\t\t{detalleItem.ValorProducto}");
                            }
                        }
                        Console.WriteLine($"Total a pagar: {venta1.ValorTotalVenta}");
                    }
                    else
                    {
                        Console.WriteLine("El número de factura no existe");
                    }
                    Console.ReadKey();
                    break;
                case 3:
                    Console.WriteLine("\n*** Eliminar Factura ***");
                    Console.WriteLine("Ingrese el número de factura");
                    numFactura = int.Parse(Console.ReadLine());
                    if (ventaServices.BuscarFactura(numFactura) >= 0)
                    {
                        Venta venta = new Venta();

                        venta.NumeroFactura = numFactura;
                        int index = ventaServices.BuscarFactura(numFactura);
                        Console.Write($"¿Desea deshabilitar la factura # {venta.NumeroFactura}? (S/N): ");
                        resp = Console.ReadLine();
                        if (!resp.Equals("n"))
                        {
                            venta.Estado = false;
                            ventaServices.ModificarFactura(venta, index);
                            Console.WriteLine("Factura inhabilitada correctamente");
                        }
                        else
                        {
                            Console.WriteLine("No se deshabilitó la factura");
                        }
                    }
                    else
                        Console.WriteLine("El producto no existe");
                    Console.ReadKey();
                    break;
                case 0:
                    MenuPrincipal();
                    break;
                default:
                    Console.WriteLine("Opción Incorrecta, seleccione una opción válida");
                    break;
            }
        }

        private void ModuloReportes(byte op)
        {
            int cont = 1;
            switch (op)
            {
                case 1:
                    Console.WriteLine("\n*** Listado de Clientes ***");
                    foreach (var clienteItem in clientesServices.ListarClientes())
                    {
                        Console.WriteLine($"Cliente #: {cont++} \nDocumento: {clienteItem.Cedula} \nNombre: {clienteItem.Nombre} \nDirección: {clienteItem.Direccion} \nTeléfono: {clienteItem.Telefono} \n");
                    }
                    Console.ReadKey();
                    break;
                case 2:
                    Console.WriteLine("\n*** Listado de Productos ***");
                    foreach (var productoItem in productoServices.ListarProductos())
                    {
                        Console.WriteLine($"Producto #: {cont++} \nCódigo Producto: {productoItem.CodigoProducto} \nNombre: {productoItem.NombreProducto} \nCantidad: {productoItem.CantidadProducto} \nPrecio Unidad: {productoItem.PrecioProducto} \n");
                    }
                    Console.ReadKey();
                    break;
                case 3:
                    Console.WriteLine("\n*** Listado de Facturas ***");
                    foreach (var ventaItem in ventaServices.ListarVenta())
                    {
                        Console.WriteLine($"Factura #: {cont++} \nNro Factura: {ventaItem.NumeroFactura} \nDocumento Cliente: {ventaItem.IdCliente} \nFecha: {ventaItem.Fecha} \nEstado: {ventaItem.Estado} \nTotal a pagar: {ventaItem.ValorTotalVenta}\n");
                    }
                    Console.ReadKey();
                    break;
                case 4:
                    break;
                case 0:
                    MenuPrincipal();
                    break;
                default:
                    Console.WriteLine("Opción Incorrecta, seleccione una opción válida");
                    break;
            }
        }

        private int DocumentoCliente()
        {
            int cedula;
            Console.WriteLine("Ingrese la cédula del cliente");
            cedula = int.Parse(Console.ReadLine());
            return cedula;
        }

        private int CodigoProducto()
        {
            int codigo;
            Console.WriteLine("Ingrese el código del producto");
            codigo = int.Parse(Console.ReadLine());
            return codigo;
        }
    }
}
