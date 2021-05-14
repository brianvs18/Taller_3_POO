using System;
using System.Collections.Generic;
using System.Text;

namespace Taller_3_POO.Entidades
{
    class DetalleVenta
    {
        public int IdDetalleVenta { get; set; }
        public int NumeroFactura { get; set; }
        public int CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public int CantidadProducto { get; set; }
        public float ValorProducto { get; set; }
    }
}
