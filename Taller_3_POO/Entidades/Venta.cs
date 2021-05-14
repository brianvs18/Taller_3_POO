using System;
using System.Collections.Generic;
using System.Text;

namespace Taller_3_POO.Entidades
{
    class Venta
    {
        public int NumeroFactura { get; set; }
        public int IdCliente { get; set; }
        public DateTime Fecha { get; set; }
        public float ValorTotalVenta { get; set; }
        public bool Estado { get; set; }
    }
}
