using System;
using System.Collections.Generic;

namespace TiendaConsola
{
    class Program
    {
        const decimal IVA = 0.21m;

        static void Main(string[] args)
        {
            List<Producto> inventario = new List<Producto>();
            inventario.Add(new Producto("Teclado", 25000m, 5));
            inventario.Add(new Producto("Mouse", 12000m, 3));
            inventario.Add(new Producto("Monitor", 180000m, 2));

            Pedido pedido = new Pedido();
            bool ejecutando = true;

            while (ejecutando)
            {
                Console.WriteLine("\n1. Ver inventario");
                Console.WriteLine("2. Agregar producto al pedido");
                Console.WriteLine("3. Ver resumen");
                Console.WriteLine("4. Pagar");
                Console.WriteLine("0. Salir");
                Console.Write("Opción: ");

                if (!int.TryParse(Console.ReadLine(), out int opcion))
                {
                    Console.WriteLine("Ingresá un número válido.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        MostrarInventario(inventario);
                        break;

                    case 2:
                        MostrarInventario(inventario);
                        Console.Write("Número de producto: ");
                        bool numeroOk = int.TryParse(Console.ReadLine(), out int numero);
                        Console.Write("Cantidad: ");
                        bool cantidadOk = int.TryParse(Console.ReadLine(), out int cantidad);

                        if (!numeroOk || !cantidadOk || numero < 1 || numero > inventario.Count)
                        {
                            Console.WriteLine("Datos inválidos.");
                        }
                        else if (pedido.AgregarProducto(inventario[numero - 1], cantidad))
                        {
                            Console.WriteLine("Producto agregado.");
                        }
                        else
                        {
                            Console.WriteLine("Stock insuficiente.");
                        }
                        break;

                    case 3:
                        MostrarResumen(pedido);
                        break;

                    case 4:
                        pedido.Pagar();
                        MostrarResumen(pedido);
                        pedido = new Pedido();
                        break;

                    case 0:
                        ejecutando = false;
                        break;

                    default:
                        Console.WriteLine("Opción inexistente.");
                        break;
                }
            }
        }

        static void MostrarInventario(List<Producto> inventario)
        {
            for (int i = 0; i < inventario.Count; i++)
            {
                Producto p = inventario[i];
                Console.WriteLine($"{i + 1}. {p.Nombre} - ${p.Precio:F2} (stock: {p.Stock})");
            }
        }

        static void MostrarResumen(Pedido pedido)
        {
            Console.WriteLine($"Estado: {pedido.Estado}");
            Console.WriteLine($"Total: ${pedido.CalcularTotal(IVA):F2}");
        }
    }
}
