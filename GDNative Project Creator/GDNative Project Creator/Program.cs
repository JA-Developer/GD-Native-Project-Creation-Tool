// See https://aka.ms/new-console-template for more information
//Personalizar tema de la consola

using System.Net;

WebClient Client = new WebClient();
string ConfigFileUrl = "https://drive.google.com/uc?id=1D9d3ZGLcrOYb7_z9-UiZ95MbIXiE3z42&export=download";

async Task<string> DownloadData(string URL)
{
    Client.DownloadProgressChanged+= DownloadProgressChanged;
    byte[] DownloadedData = await Client.DownloadDataTaskAsync(URL);

    return System.Text.Encoding.UTF8.GetString(DownloadedData);
}

void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
{
    Console.WriteLine(e.ProgressPercentage);
}

Console.BackgroundColor = ConsoleColor.Gray;
Console.Clear();
Console.ForegroundColor = ConsoleColor.Black;

//Imprimir pantalla de inicio

Console.WriteLine("¡Bienvenido al asistente de creación de proyectos GD Native!");

Console.Write('\n');

Console.WriteLine("Presiona cualquier tecla para continuar...");
Console.ReadKey();

await DownloadData(ConfigFileUrl);