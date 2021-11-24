// See https://aka.ms/new-console-template for more information

using GDNative_Project_Creator;
using Newtonsoft.Json;

//Variable que se debe activar para cerrar el programa

bool Finalizar = false;

//Personalizar tema de la consola

Console.BackgroundColor = ConsoleColor.Gray;
Console.Clear();
Console.ForegroundColor = ConsoleColor.Black;

//Imprimir pantalla de inicio

Console.WriteLine("¡Bienvenido al asistente de creación de proyectos GD Native!");

Console.Write('\n');

Console.WriteLine("Presiona cualquier tecla para continuar...");
Console.ReadKey();

while(!Finalizar)
{
    Console.Clear();

    Console.WriteLine("Seleccione una opción:\n");
    Console.WriteLine("1. Nuevo proyecto");
    Console.WriteLine("2. Salir");
    Console.Write("\nIngrese su respuesta: ");

    var RespuestaStr = Console.ReadLine();
    int result = 0;

    if (int.TryParse(RespuestaStr, out result))
    {
        switch (result)
        {
            case 1:
                OpcionesMenu.NuevoProyecto();
                break;
            case 2:
                Finalizar = true;
                break;
            default:
                break;
        }
    }
}