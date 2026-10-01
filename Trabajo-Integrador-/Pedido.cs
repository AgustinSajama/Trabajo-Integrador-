using System.Collections.Generic;

namespace TiendaConsola
{
    public class Pedido
    {
        private List<Producto> _productos = new List<Producto>();

        public string Estado { get; private set; } = "Pendiente";

        public bool AgregarProducto(Producto p, int cant)
        {
            if (!p.DescontarStock(cant))
            {
                return false;
            }

            for (int i = 0; i < cant; i++)
            {
                _productos.Add(p);
            }
            return true;
        }

        public decimal CalcularTotal(decimal impuesto)
        {
            decimal subtotal = 0m;
            foreach (Producto p in _productos)
            {
                subtotal += p.Precio;
            }
            return subtotal * (1 + impuesto);
        }

        public void Pagar()
        {
            Estado = "Completado";
        }
    }
}
