using System;
using System.Collections.Generic;
using System.Text;

namespace Taller_3_POO
{
    class ClienteServices
    {
        private List<Cliente> listadoClientes = new List<Cliente>();

        public void AgregarCliente(Cliente clientes)
        {
            listadoClientes.Add(clientes);
        }

        public void ModificarCliente(Cliente clientes, int index)
        {
            listadoClientes[index].Nombre = clientes.Nombre;
            listadoClientes[index].Direccion = clientes.Direccion;
            listadoClientes[index].Telefono = clientes.Telefono;
        }

        public int BuscarCliente(int cedula)
        {
            foreach (Cliente clientes in listadoClientes)
            {
                if (clientes.Cedula == cedula)
                {
                    return listadoClientes.IndexOf(clientes);
                }
            }
            return -1;
        }

        public Cliente BuscarClientexId(int cedula)
        {
            if (BuscarCliente(cedula) >= 0)
                return listadoClientes[BuscarCliente(cedula)];
            else
                return null;
        }

        public void EliminarCliente(int cedula)
        {
            if (BuscarCliente(cedula) >= 0)
            {
                listadoClientes.RemoveAt(BuscarCliente(cedula));
                Console.WriteLine("Cliente eliminado correctamente");
            }
            else
                Console.WriteLine("El cliente no existe");
        }

        public List<Cliente> ListarClientes()
        {
            return listadoClientes;
        }
    }
}
