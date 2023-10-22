using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Examen
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Sistema de Gestión de Empleados");
            Console.Write("Ingrese la cantidad de empleados que desea gestionar: ");
            if (int.TryParse(Console.ReadLine(), out int cantidadEmpleados ))
            {
                Menu menu = new Menu(cantidadEmpleados);
                menu.MostrarMenu();
            }
            else
            {
                Console.WriteLine("Cantidad no válida. Saliendo del programa.");
            }
        }
    } 
}
