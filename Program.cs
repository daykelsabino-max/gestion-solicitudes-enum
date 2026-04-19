using System;
using System.Collections.Generic;

// ENUM
public enum EstadoSolicitud
{
    Pendiente,
    EnProceso,
    Completada,
    Cancelada
}

// CLASE
public class Solicitud
{
    public int Id { get; set; }
    public string NombreCliente { get; set; } = "";
    public string Descripcion { get; set; } = "";
    public EstadoSolicitud Estado { get; set; }

    public void Mostrar()
    {
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Cliente: {NombreCliente}");
        Console.WriteLine($"Descripción: {Descripcion}");
        Console.WriteLine($"Estado: {Estado}");
        Console.WriteLine("------------------------");
    }
}

class Program
{
    static List<Solicitud> solicitudes = new List<Solicitud>();
    static int contadorId = 1;

    static void Main(string[] args)
    {
        Console.Clear(); // limpia pantalla al iniciar

        int opcion;
        do
        {
            Console.WriteLine("\n--- MENÚ ---");
            Console.WriteLine("1. Registrar solicitud");
            Console.WriteLine("2. Mostrar solicitudes");
            Console.WriteLine("3. Cambiar estado");
            Console.WriteLine("4. Buscar por ID");
            Console.WriteLine("5. Salir");
            Console.Write("Opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Entrada inválida.");
                continue;
            }

            Console.Clear(); // limpia cada vez (para que la captura se vea bonita)

            switch (opcion)
            {
                case 1:
                    RegistrarSolicitud();
                    break;
                case 2:
                    MostrarSolicitudes();
                    break;
                case 3:
                    CambiarEstado();
                    break;
                case 4:
                    BuscarPorId();
                    break;
                case 5:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

        } while (opcion != 5);
    }

    static void RegistrarSolicitud()
    {
        Solicitud s = new Solicitud();

        s.Id = contadorId++;

        Console.Write("Nombre del cliente: ");
        s.NombreCliente = Console.ReadLine() ?? "";

        Console.Write("Descripción: ");
        s.Descripcion = Console.ReadLine() ?? "";

        s.Estado = EstadoSolicitud.Pendiente;

        solicitudes.Add(s);

        Console.WriteLine("\nSolicitud registrada correctamente.");
    }

    static void MostrarSolicitudes()
    {
        if (solicitudes.Count == 0)
        {
            Console.WriteLine("No hay solicitudes registradas.");
            return;
        }

        foreach (var s in solicitudes)
        {
            s.Mostrar();
        }
    }

    static void CambiarEstado()
    {
        Console.Write("Ingrese ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        var solicitud = solicitudes.Find(s => s.Id == id);

        if (solicitud == null)
        {
            Console.WriteLine("Solicitud no encontrada.");
            return;
        }

        Console.WriteLine("\nSeleccione nuevo estado:");
        Console.WriteLine("0. Pendiente");
        Console.WriteLine("1. EnProceso");
        Console.WriteLine("2. Completada");
        Console.WriteLine("3. Cancelada");

        if (int.TryParse(Console.ReadLine(), out int opcion) &&
            Enum.IsDefined(typeof(EstadoSolicitud), opcion))
        {
            solicitud.Estado = (EstadoSolicitud)opcion;
            Console.WriteLine("Estado actualizado correctamente.");
        }
        else
        {
            Console.WriteLine("Opción inválida.");
        }
    }

    static void BuscarPorId()
    {
        Console.Write("Ingrese ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        var solicitud = solicitudes.Find(s => s.Id == id);

        if (solicitud != null)
        {
            solicitud.Mostrar();
        }
        else
        {
            Console.WriteLine("No encontrada.");
        }
    }
}
