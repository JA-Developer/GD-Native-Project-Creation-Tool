// See https://aka.ms/new-console-template for more information
//Personalizar tema de la consola

using GDNative_Project_Creator;

Console.BackgroundColor = ConsoleColor.Gray;
Console.Clear();
Console.ForegroundColor = ConsoleColor.Black;

//Imprimir pantalla de inicio

Console.WriteLine("¡Bienvenido al asistente de creación de proyectos GD Native!");

Console.Write('\n');

Console.WriteLine("Presiona cualquier tecla para continuar...");
Console.ReadKey();

//Obtener archivo de configuración
DataAndFilesDownloader downloader = new DataAndFilesDownloader("https://drive.google.com/u/0/uc?id=1D9d3ZGLcrOYb7_z9-UiZ95MbIXiE3z42&export=download", "Lista de versiones");
Console.WriteLine(await downloader.DownloadString());
