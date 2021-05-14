using System;
using System.Collections.Generic;
using System.Text;
using Taller_3_POO.Entidades;

namespace Taller_3_POO.Services
{
    class ProductoServices
    {
        List<Producto> listaProductos = new List<Producto>();


        public void AgregarProductos(Producto moduloProductos)
        {
            listaProductos.Add(moduloProductos);
        }

        public int BuscarProductos(int codigoProducto)
        {
            int posicion = -1;
            foreach (var moduloProductos in listaProductos)
            {
                if (moduloProductos.CodigoProducto == codigoProducto)
                {
                    return listaProductos.IndexOf(moduloProductos);
                }
            }
            return posicion;
        }

        public Producto ConsultarProductoxCodigo(int codigoProducto)
        {
            if (BuscarProductos(codigoProducto) >= 0)
                return listaProductos[BuscarProductos(codigoProducto)];
            else
                return null;
        }

        public void ModificarProductos(Producto moduloProductos, int posicion)
        {
            listaProductos[posicion].NombreProducto = moduloProductos.NombreProducto;
            listaProductos[posicion].PrecioProducto = moduloProductos.PrecioProducto;
            listaProductos[posicion].CantidadProducto = moduloProductos.CantidadProducto;

        }

        public void EliminarProductos(int codigoProducto)
        {
            if (BuscarProductos(codigoProducto) >= 0)
            {
                listaProductos.RemoveAt(BuscarProductos(codigoProducto));
                Console.WriteLine("Producto eliminado correctamente");
            }
            else
            {
                Console.WriteLine("El producto no existe");
            }
        }

        public List<Producto> ListarProductos() {
            return listaProductos;
        }
    }
}
