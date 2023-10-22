using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen
{

    internal class Menu
    {
        private Empleado[] empleados;

        public Menu(int cantidadEmpleados)
        {
            empleados = new Empleado[cantidadEmpleados];
        }

        public void MostrarMenu()
        {
            int opcion;
            do
            {
                Console.WriteLine("\nMenú Principal");
                Console.WriteLine("1. Agregar Empleados");
                Console.WriteLine("2. Consultar Empleados");
                Console.WriteLine("3. Modificar Empleados");
                Console.WriteLine("4. Borrar Empleados");
                Console.WriteLine("5. Inicializar Arreglos");
                Console.WriteLine("6. Reportes");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");
                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            AgregarEmpleado();
                            break;
                        case 2:
                            ConsultarEmpleados();
                            break;
                        case 3:
                            ModificarEmpleado();
                            break;
                        case 4:
                            BorrarEmpleado();
                            break;
                        case 5:
                            InicializarArreglo();
                            break;
                        case 6:
                            MostrarMenuReportes();
                            break;
                        case 0:
                            Console.WriteLine("Saliendo del programa.");
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                }
            } while (opcion != 0);
        }

        private void AgregarEmpleado()
        {
            for (int i = 0; i < empleados.Length; i++)
            {
                if (empleados[i] == null)
                {
                    Console.WriteLine("\nAgregar Empleado");
                    Console.Write("Cédula: ");
                    string cedula = Console.ReadLine();
                    Console.Write("Nombre: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Dirección: ");
                    string direccion = Console.ReadLine();
                    Console.Write("Teléfono: ");
                    string telefono = Console.ReadLine();
                    Console.Write("Salario: ");
                    if (double.TryParse(Console.ReadLine(), out double salario))
                    {
                        empleados[i] = new Empleado(cedula, nombre, direccion, telefono, salario);
                        Console.WriteLine("Empleado agregado exitosamente.");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Salario no válido. Inténtelo de nuevo.");
                    }
                }
            }
            Console.WriteLine("No hay espacio para más empleados.");
        }

        private void ConsultarEmpleados()
        {
            Console.WriteLine("\nConsultar Empleados");
            Console.Write("Ingrese la cédula del empleado: ");
            string cedula = Console.ReadLine();
            Empleado empleado = ConsultarEmpleadosPorCedula(cedula);
            if (empleado != null)
            {
                Console.WriteLine("Información del empleado:");
                Console.WriteLine($"Cédula: {empleado.Cedula}");
                Console.WriteLine($"Nombre: {empleado.Nombre}");
                Console.WriteLine($"Dirección: {empleado.Direccion}");
                Console.WriteLine($"Teléfono: {empleado.Telefono}");
                Console.WriteLine($"Salario: {empleado.Salario}");
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
        }

        private Empleado ConsultarEmpleadosPorCedula(string cedula)
        {
            for (int i = 0; i < empleados.Length; i++)
            {
                if (empleados[i] != null && empleados[i].Cedula == cedula)
                {
                    return empleados[i];
                }
            }
            return null;
        }

        private void ModificarEmpleado()
        {
            Console.WriteLine("\nModificar Empleados");
            Console.Write("Ingrese la cédula del empleado a modificar: ");
            string cedula = Console.ReadLine();
            Empleado empleado = ConsultarEmpleadosPorCedula(cedula);
            if (empleado != null)
            {
                Console.WriteLine("\nInformación actual del empleado:");
                Console.WriteLine($"Cédula: {empleado.Cedula}");
                Console.WriteLine($"Nombre: {empleado.Nombre}");
                Console.WriteLine($"Dirección: {empleado.Direccion}");
                Console.WriteLine($"Teléfono: {empleado.Telefono}");
                Console.WriteLine($"Salario: {empleado.Salario}");
                Console.WriteLine("\nIngrese los nuevos datos:");
                Console.Write("Nombre: ");
                empleado.Nombre = Console.ReadLine();
                Console.Write("Dirección: ");
                empleado.Direccion = Console.ReadLine();
                Console.Write("Teléfono: ");
                empleado.Telefono = Console.ReadLine();
                Console.Write("Salario: ");
                if (double.TryParse(Console.ReadLine(), out double salario))
                {
                    empleado.Salario = salario;
                    Console.WriteLine("Empleado modificado exitosamente.");
                }
                else
                {
                    Console.WriteLine("Salario no válido. No se realizó la modificación.");
                }
            }
            else
            {
                Console.WriteLine("Empleado no encontrado. No se realizó la modificación.");
            }
        }

        private void BorrarEmpleado()
        {
            Console.WriteLine("\nBorrar Empleados");
            Console.Write("Ingrese la cédula del empleado a borrar: ");
            string cedula = Console.ReadLine();
            Empleado empleado = ConsultarEmpleadosPorCedula(cedula);
            if (empleado != null)
            {
                for (int i = 0; i < empleados.Length; i++)
                {
                    if (empleados[i] != null && empleados[i].Cedula == cedula)
                    {
                        empleados[i] = null;
                        Console.WriteLine("Empleado borrado exitosamente.");
                        return;
                    }
                }
            }
            Console.WriteLine("Empleado no encontrado. No se realizó la eliminación.");
        }

        private void InicializarArreglo()
        {
            Console.WriteLine("\nInicializar Arreglo");
            Console.Write("Ingrese la cantidad de empleados: ");
            if (int.TryParse(Console.ReadLine(), out int cantidadEmpleados))
            {
                empleados = new Empleado[cantidadEmpleados];
                Console.WriteLine($"Arreglo inicializados con {cantidadEmpleados} empleados.");
            }
            else
            {
                Console.WriteLine("Cantidad no válida. Inténtelo de nuevo.");
            }
        }

        private void MostrarMenuReportes()
        {
            int opcion;
            do
            {
                Console.WriteLine("\nMenú de Reportes");
                Console.WriteLine("1. Consultar empleados con número de cédula");
                Console.WriteLine("2. Listar todos los empleados ordenados por nombre");
                Console.WriteLine("3. Calcular y mostrar el promedio de los salarios");
                Console.WriteLine("4. Calcular y mostrar el salario más alto y el más bajo");
                Console.WriteLine("0. Volver al Menú Principal");
                Console.Write("Seleccione una opción: ");
                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            ConsultarEmpleados();
                            break;
                        case 2:
                            ListarEmpleadosOrdenadosPorNombre(empleados);
                            break;
                        case 3:
                            CalcularPromedioSalarios(empleados);
                            break;
                        case 4:
                            CalcularSalarioMaximoMinimo(empleados);
                            break;
                        case 0:
                            Console.WriteLine("Volviendo al Menú Principal.");
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                }
            } while (opcion != 0);
        }

        private void ListarEmpleadosOrdenadosPorNombre(Empleado[] empleados)
        {
            Console.WriteLine("\nListar Empleados Ordenados por Nombre");

            Empleado[] empleadosNoNulos = new Empleado[empleados.Length];
            int contador = 0;
            for (int i = 0; i < empleados.Length; i++)
            {
                if (empleados[i] != null)
                {
                    empleadosNoNulos[contador] = empleados[i];
                    contador++;
                }
            }

            for (int i = 0; i < contador - 1; i++)
            {
                for (int j = i + 1; j < contador; j++)
                {
                    if (string.Compare(empleadosNoNulos[i].Nombre, empleadosNoNulos[j].Nombre, StringComparison.OrdinalIgnoreCase) > 0)
                    {
                        Empleado temp = empleadosNoNulos[i];
                        empleadosNoNulos[i] = empleadosNoNulos[j];
                        empleadosNoNulos[j] = temp;
                    }
                }
            }

            // Imprimir empleados ordenados por nombre
            for (int i = 0; i < contador; i++)
            {
                Console.WriteLine($"Cédula: {empleadosNoNulos[i].Cedula}, Nombre: {empleadosNoNulos[i].Nombre}");
            }
        }

        private void CalcularPromedioSalarios(Empleado[] empleados)
        {
            Console.WriteLine("\nCalcular Promedio de Salarios");

            double totalSalarios = 0;
            int contador = 0;

            for (int i = 0; i < empleados.Length; i++)
            {
                if (empleados[i] != null)
                {
                    totalSalarios += empleados[i].Salario;
                    contador++;
                }
            }

            if (contador > 0)
            {
                double promedio = totalSalarios / contador;
                Console.WriteLine($"El promedio de salarios es: {promedio:C}");
            }
            else
            {
                Console.WriteLine("No hay empleados registrados para calcular el promedio.");
            }
        }

        private void CalcularSalarioMaximoMinimo(Empleado[] empleados)
        {
            Console.WriteLine("\nCalcular Salario Máximo y Mínimo");

            double salarioMaximo = 0; 
            double salarioMinimo = 0; 
            bool hayEmpleados = false;

            for (int i = 0; i < empleados.Length; i++)
            {
                if (empleados[i] != null)
                {
                    double salario = empleados[i].Salario;
                    if (salario > salarioMaximo)
                    {
                        salarioMaximo = salario;
                    }
                    if (salario < salarioMinimo)
                    {
                        salarioMinimo = salario;
                    }
                    hayEmpleados = true;
                }
            }

            if (hayEmpleados)
            {
                Console.WriteLine($"Salario más alto: {salarioMaximo:C}");
                Console.WriteLine($"Salario más bajo: {salarioMinimo:C}");
            }
            else
            {
                Console.WriteLine("No hay empleados registrados para calcular salarios.");
            }
        }
    }
}
