using System;
using System.Collections.Generic;
using System.Text;
using Taller_3_POO.Entidades;

namespace Taller_3_POO.Services
{
    class VentaServices
    {
        List<Venta> listaVentas = new List<Venta>();
        List<DetalleVenta> listaDetalleVentas = new List<DetalleVenta>();

        public void GuardarVenta(Venta venta)
        {
            listaVentas.Add(venta);
        }

        public int BuscarFactura(int numFactura)
        {
            int index = -1;
            foreach (Venta ventas in listaVentas)
            {
                if (ventas.NumeroFactura == numFactura)
                    return listaVentas.IndexOf(ventas);
            }
            return index;
        }

        public Venta ConsultarFacturaxId(int numFactura)
        {
            if (BuscarFactura(numFactura) >= 0)
                if(listaVentas[BuscarFactura(numFactura)].Estado == true)
                {
                    return listaVentas[BuscarFactura(numFactura)];
                }
                else
                {
                    return null;
                }
            else
                return null;
        }

        public void GuardarDetalleVenta(DetalleVenta detalleVenta)
        {
            listaDetalleVentas.Add(detalleVenta);
        }        

        public void ModificarFactura(Venta venta, int index)
        {
            listaVentas[index].Estado = venta.Estado;

        }

        public List<DetalleVenta> ListarDetalleVenta()
        {
            return listaDetalleVentas;
        }

        public List<Venta> ListarVenta()
        {
            return listaVentas;
        }
    }
}
